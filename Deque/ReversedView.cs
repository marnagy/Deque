using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

class ReversedView<T> : IList<T>
{
	readonly IDeque<T> deque;
	public ReversedView(IDeque<T> deque)
	{
		this.deque = deque;
	}
	public T this[int index] { get => deque[deque.Count - 1 - index]; set => deque[deque.Count - 1 - index] = value; }

	public int Count => deque.Count;

	public bool IsReadOnly => deque.IsReadOnly;

	public void Add(T item)
	{
		deque.AddFirst(item);
	}

	public void Clear()
	{
		deque.Clear();
	}

	public bool Contains(T item)
	{
		return deque.Contains(item);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		deque.CopyTo(array, arrayIndex);
	}

	public IEnumerator<T> GetEnumerator()
	{
		return new ReversedEnumerator<T>(this.deque);
	}

	private class ReversedEnumerator<T> : IEnumerator<T>
	{
		readonly IDeque<T> deque;
		int index;
		internal ReversedEnumerator(IDeque<T> deque)
		{
			this.deque = deque;
			this.index = deque.Count;
		}
		public T Current => deque[index];

		object IEnumerator.Current => throw new NotImplementedException();

		public void Dispose()
		{
			//throw new NotImplementedException();
		}

		public bool MoveNext()
		{
			if (index > 0)
			{
				index--;
				return true;
			}
			return false;
		}

		public void Reset()
		{
			throw new NotImplementedException();
		}
	}


	public int IndexOf(T item)
	{
		int i = 0;
		foreach (T item2 in this)
		{
			if (item2.Equals(item))
			{
				return i;
			}
			i++;
		}
		return -1;
	}

	public void Insert(int index, T item)
	{
		// to be tested
		deque.Insert(deque.Count - 1 - index, item);
	}

	public bool Remove(T item)
	{
		return deque.Remove(item);
	}

	public void RemoveAt(int index)
	{
		deque.RemoveAt(deque.Count - 1 - index);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		throw new NotImplementedException();
	}
}
