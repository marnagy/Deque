using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Deque<T> : IDeque<T>
{
	int frontBlock = -1, endBlock = -1;
	Data<T>[] map = new Data<T>[1];
	private int size = 0;
	public int version { get; private set; } = 0;

	public T this[int index] { 
		get {
				if (!CheckIndex(index))
				{
					throw new IndexOutOfRangeException();
				}
				int firstSize = map[frontBlock].currentSize;
				if (index < firstSize)
				{
					return map[frontBlock][index];
				}
				else
				{
					index = index - firstSize;
					int outsideIndex = index / Data<T>.size;
					int insideIndex = index % Data<T>.size;
					return map[frontBlock + 1 + outsideIndex][insideIndex];
				}
			}
		set {
				if (!CheckIndex(index))
				{
					throw new IndexOutOfRangeException();
				}
				int firstSize = map[frontBlock].currentSize;
				if (index < firstSize)
				{
					map[frontBlock][index] = value;
				}
				else
				{
					index = index - firstSize;
					int outsideIndex = index / Data<T>.size;
					int insideIndex = index % Data<T>.size;
					map[frontBlock + 1 + outsideIndex].arr[insideIndex] = value;
				}
			} }

	private bool CheckIndex(int index)
	{
		return !(index < 0 || index >= this.size);
	}

	public int Capacity => Data<T>.size * map.Length;

	public bool IsEmpty => size == 0;

	public IList<T> Reversed => new ReversedView<T>(this);

	public int Count => size;

	public bool IsReadOnly => false;

	public void Add(T item)
	{
		if (size == 0)
		{
			map[0] = new Data<T>(item);
			frontBlock = 0;
			endBlock = 0;
			size = 1;
			version++;
		}
		else
		{
			AddLast(item);
		}
	}

	public void AddFirst(T item)
	{
		if (map[frontBlock].start == 0)
		{
			while (frontBlock == 0)
			{
				MakeLarger();
			}
			map[--frontBlock] = new Data<T>(item,indexOnEnd: true);
		}
		else
		{
			map[frontBlock].Add(item, true);
		}
		size++;
		version++;
	}

	public void AddLast(T item)
	{
		if (map[endBlock].end == Data<T>.size - 1)
		{
			while (endBlock == map.Length - 1)
			{
				MakeLarger();
			}
			map[++endBlock] = new Data<T>(item,indexOnStart: true);
		}
		else
		{
			map[endBlock].Add(item, false);
		}
		size++;
		version++;
	}

	private void MakeLarger()
	{
		Data<T>[] newMap = new Data<T>[map.Length * 2];
		Array.Copy(map, 0, newMap, map.Length / 2, map.Length);
		this.frontBlock = frontBlock + map.Length / 2;
		this.endBlock = endBlock + map.Length / 2;
		map = newMap;
	}

	public void Clear()
	{
		frontBlock = -1;
		endBlock = -1;
		map = new Data<T>[1];
		size = 0;
		version++;
	}

	public bool Contains(T item)
	{
		foreach (T thing in this)
		{
			if (item == null)
			{
				if (thing == null)
				{
					return true;
				}
			}
			else
			{
				if ( item.Equals(thing) )
				{
					return true;
				}
			}
		}
		return false;
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		foreach (T item in this)
		{
			array[arrayIndex++] = item; 
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		 return new MyEnumerator<T>(this);
	}

	private class MyEnumerator<T> : IEnumerator<T>
	{
		int stepConst;
		int currentIndex;
		Deque<T> deque;
		int version;
		internal MyEnumerator(Deque<T> deque)
		{
			this.deque = deque;
			this.version = deque.version;
			stepConst = 1;
			currentIndex = -1;
		}

		public T Current { 
			get {
				if (deque.version != this.version)
				{
					throw new InvalidOperationException();
				}
				return deque[currentIndex];
				} 
			}

		object IEnumerator.Current => Current;

		public void Dispose()
		{
			//throw new NotImplementedException();
		}

		public bool MoveNext()
		{
			if (deque.version != this.version)
			{
				throw new InvalidOperationException();
			}
			if (currentIndex < deque.size - 1)
			{
				currentIndex++;
				return true;
			}
			return false;
		}

		public void Reset()
		{
			currentIndex = -1;
		}
	}

	public int IndexOf(T item)
	{
		Deque<T> list = this;
		for (int i = 0; i < list.Count; i++)
		{
			if (item == null)
			{
				if ( list[i] == null )
				{
					return i;
				}
			}
			else
			{
				if ( item.Equals(list[i]) )
				{
					return i;
				}
			}
		}
		return -1;
	}

	public void Insert(int index, T item)
	{
		if (!CheckIndex(index) && index != size)
		{
			throw new IndexOutOfRangeException();
		}

		if (index < size / 2)
		{
			AddFirst(item);
			Move(from: 0, to: index);
		}
		else
		{
			Add(item);
			Move(from: size - 1, to: index);
		}
	}

	public T PeekFirst()
	{
		return this[0];
	}

	public T PeekLast()
	{
		return this[size - 1];
	}

	public T PopFirst()
	{
		int innerIndex = map[frontBlock].start;
		T item = map[frontBlock].arr[innerIndex];
		if (innerIndex == Data<T>.size - 1)
		{
			frontBlock++;
		}
		else
		{
			map[frontBlock].Remove(inverted: false);
		}
		size--;
		version++;
		return item;
	}

	public T PopLast()
	{
		int innerIndex = map[endBlock].end;
		T item = map[endBlock].arr[innerIndex];
		if (innerIndex == 0)
		{
			endBlock--;
		}
		else
		{
			map[endBlock].Remove(inverted: true);
		}
		size--;
		version++;
		return item;
	}

	public bool Remove(T item)
	{
		bool res = false;
		int i;
		for ( i = 0; i < this.size; i++)
		{
			if (item == null)
			{
				if (this[i] == null)
				{
					res = true;
					break;
				}
			}
			else
			{
				if (this[i].Equals(item))
				{
					res = true;
					break;
				}
			}
		}
		if (res)
		{
			RemoveAt(i);
		}
		return res;
	}

	public void Move(int from, int to)
	{
		if (!CheckIndex(from) || !CheckIndex(to))
		{
			throw new IndexOutOfRangeException();
		}

		T temp;
		if (from < to)
		{
			// this ensures item is on "to" index
			for (int i = from; i < to; i++)
			{
				temp = this[i];
				this[i] = this[i+1];
				this[i+1] = temp;
			}
		}
		else if (from > to)
		{
			for (int i = from; i > to; i--)
			{
				temp = this[i];
				this[i] = this[i-1];
				this[i-1] = temp;
			}
		}
	}

	public void RemoveAt(int index)
	{
		if (!CheckIndex(index))
		{
			throw new IndexOutOfRangeException();
		}

		if (index < size / 2)
		{
			Move(from: index, to: 0);
			PopFirst();
		}
		else
		{
			Move(from: index, to: size - 1);
			PopLast();
		}
	}

	public void Reverse()
	{
		throw new NotImplementedException();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		throw new NotImplementedException();
	}
}

public static class DequeTest {
	public static IList<T> GetReverseView<T>(Deque<T> d) {
		return d.Reversed;
	}
}
