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

	public Deque()
	{

	}

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
			// TO DO
			} }

	private bool CheckIndex(int index)
	{
		return !(index < 0 || index >= this.size);
	}

	public int Capacity => Data<T>.size * map.Length;

	public bool IsEmpty => size == 0;

	public IDeque<T> Reversed => throw new NotImplementedException();

	public int Count => size;

	public bool IsReadOnly => false;

	public void Add(T item)
	{
		if (size == 0)
		{
			map[0] = new Data<T>(item);
			frontBlock = 0;
			endBlock = 0;
		}
		else
		{
			AddLast(item);
		}
		size++;
	}

	public void AddFirst(T item)
	{
		throw new NotImplementedException();
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
		internal MyEnumerator(Deque<T> deque)
		{
			this.deque = deque;
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

		public T Current => deque[currentIndex];

		object IEnumerator.Current => throw new NotImplementedException();

		public void Dispose()
		{
			//throw new NotImplementedException();
		}

		public bool MoveNext()
		{
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
		int index = 0;
		foreach (T thing in this)
		{
			if ( thing.Equals(item) )
			{
				return index;
			}
			index++;
		}
		return -1;
	}

	public void Insert(int index, T item)
	{
		throw new NotImplementedException();
	}

	public T PeekFirst()
	{
		throw new NotImplementedException();
	}

	public T PeekLast()
	{
		throw new NotImplementedException();
	}

	public T PopFirst()
	{
		throw new NotImplementedException();
	}

	public T PopLast()
	{
		throw new NotImplementedException();
	}

	public bool Remove(T item)
	{
		throw new NotImplementedException();
	}

	public void RemoveAt(int index)
	{
		throw new NotImplementedException();
	}

	public void Reverse()
	{
		inversed = !inversed;
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
