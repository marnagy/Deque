using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Deque<T> : IDeque<T>
{
	bool inversed = false;
	int frontBlock = -1, endBlock = -1;
	Data<T>[] map = new Data<T>[1];
	private int size = 0;
	private int version = 0;

	public T this[int index] { 
		get {
				if (!CheckIndex(index))
				{
					throw new IndexOutOfRangeException();
				}
				int firstSize = map[frontBlock].currentSize;
				if (index < firstSize)
				{
					return map[frontBlock].arr[ map[frontBlock].start + index];
				}
				else
				{
					index = index - firstSize;
					int outsideIndex = index / Data<T>.size;
					int insideIndex = index % Data<T>.size;
					return map[frontBlock + 1 + outsideIndex].arr[insideIndex];
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
					map[frontBlock].arr[ map[frontBlock].start + index] = value;
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
			size++;
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
			if (frontBlock == 0)
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
			if (endBlock == map.Length - 1)
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
		frontBlock = frontBlock + map.Length / 2;
		endBlock = endBlock + map.Length / 2;
		map = newMap;
	}

	public void Clear()
	{
		frontBlock = -1;
		endBlock = -1;
		map = new Data<T>[1];
		size = 0;
	}

	public bool Contains(T item)
	{
		foreach (T thing in this)
		{
			if ( thing.Equals(item) )
			{
				return true;
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
			if (!deque.inversed)
			{
				stepConst = 1;
				currentIndex = -1;
			}
			else
			{
				stepConst = -1;
				currentIndex = deque.size;
			}
		}

		public T Current { 
			get {
				if (deque.version != this.version)
				{
					throw new InvalidOperationException("Collection has been modified.");
				}
				return deque[currentIndex];
				} 
			}

		object IEnumerator.Current => throw new NotImplementedException();

		public void Dispose()
		{
			//throw new NotImplementedException();
		}

		public bool MoveNext()
		{
			if (deque.version != this.version)
			{
				throw new InvalidOperationException("Collection has been modified.");
			}
			if (currentIndex == deque.size - 1)
			{
				return false;
			}
			currentIndex++;
			return true;
		}

		public void Reset()
		{
			if (!deque.inversed)
			{
				currentIndex = -1;
			}
			else
			{
				currentIndex = deque.size;
			}
		}
	}

	public int IndexOf(T item)
	{
		Deque<T> list = this;
		for (int i = 0; i < list.Count; i++)
		{
			T thing = list[i];
			if ( thing.Equals(item) )
			{
				return i;
			}
		}
		return -1;
	}

	public void Insert(int index, T item)
	{
		throw new NotImplementedException();
		version++;
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
		T item;
		int innerIndex = map[frontBlock].start;
		item = map[frontBlock].arr[innerIndex];
		if (innerIndex == Data<T>.size)
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
		T item;
		int innerIndex = map[endBlock].end;
		item = map[endBlock].arr[innerIndex];
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
			if (this[i].Equals(item))
			{
				res = true;
				break;
			}
		}
		if (res)
		{
			Move(from: i, to: size - 1);
			PopLast();
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

		Move(from: index, to: size - 1);
		PopLast();
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
