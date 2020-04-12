﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

class ReversedView<T> : IList<T>
{
	readonly Deque<T> deque;
	public ReversedView(Deque<T> deque)
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
		readonly Deque<T> deque;
		int index;
		int version;
		internal ReversedEnumerator(Deque<T> deque)
		{
			this.deque = deque;
			this.index = deque.Count;
			this.version = deque.version;
		}
		public T Current { get {
			if (this.version != deque.version)
			{
				throw new InvalidOperationException();
			}
			return deque[index];
		} }

		object IEnumerator.Current => throw new NotImplementedException();

		public void Dispose()
		{
			//throw new NotImplementedException();
		}

		public bool MoveNext()
		{
			if (this.version != deque.version)
			{
				throw new InvalidOperationException();
			}
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
		int res = deque.IndexOf(item);
		if (res >= 0)
		{
			res = deque.Count - 1 - res;
		}
		return res;
	}

	public void Insert(int index, T item)
	{
		if (!CheckIndex(deque.Count - 1 - index) && index != deque.Count)
		{
			throw new IndexOutOfRangeException();
		}

		if (index != deque.Count)
		{
			deque.Insert(deque.Count - 1 - index, item);
		}
		else
		{
			deque.AddFirst(item);
		}
		
	}

	public bool Remove(T item)
	{
		bool res = false;
		int i;
		for (i = deque.Count - 1; i >= 0; i--)
		{
			if (deque[i].Equals(item))
			{
				res = true;
				break;
			}
		}
		if (res)
		{
			deque.RemoveAt(i);
		}
		return res;
	}

	public void RemoveAt(int index)
	{
		deque.RemoveAt(deque.Count - 1 - index);
	}

	private bool CheckIndex(int index)
	{
		return !(index < 0 || index >= deque.Count);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		throw new NotImplementedException();
	}
}
