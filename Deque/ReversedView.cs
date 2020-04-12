using System;
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
		if (deque.Count == 0)
		{
			deque.Add(item);
		}
		else
		{
			deque.AddFirst(item);
		}
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
		int myVersion = deque.version;
		for (int i = 0; i < deque.Count; i++)
		{
			if (myVersion != deque.version)
			{
				throw new InvalidOperationException();
			}
			yield return this[i];
		}
	}

	public int IndexOf(T item)
	{
		for (int i = deque.Count - 1; i >= 0; i--)
		{
			if (item == null)
			{
				if ( deque[i] == null )
				{
					return deque.Count - 1 - i;
				}
			}
			else
			{
				if ( item.Equals(deque[i]) )
				{
					return deque.Count - 1 - i;
				}
			}
		}
		return -1;
	}

	public void Insert(int index, T item)
	{
		if (!CheckIndex(deque.Count - index) && index != 0)
		{
			throw new IndexOutOfRangeException();
		}

		if (index != 0)
		{
			deque.Insert(deque.Count - index, item);
		}
		else
		{
			deque.AddLast( item);
		}
		
	}

	public bool Remove(T item)
	{
		bool res = false;
		int i;
		for (i = deque.Count - 1; i >= 0; i--)
		{
			if (item == null)
			{
				if (deque[i] == null)
				{
					res = true;
					break;
				}
			}
			else
			{
				if (item.Equals(deque[i]))
				{
					res = true;
					break;
				}
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
