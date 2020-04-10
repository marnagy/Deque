using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Deque<T> : IDeque<T>
{
	public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public int Capacity => throw new NotImplementedException();

	public bool IsEmpty => throw new NotImplementedException();

	public IDeque<T> Reversed => throw new NotImplementedException();

	public int Count => throw new NotImplementedException();

	public bool IsReadOnly => throw new NotImplementedException();

	public void Add(T item)
	{
		throw new NotImplementedException();
	}

	public void AddFirst(T item)
	{
		throw new NotImplementedException();
	}

	public void AddLast(T item)
	{
		throw new NotImplementedException();
	}

	public void Clear()
	{
		throw new NotImplementedException();
	}

	public bool Contains(T item)
	{
		throw new NotImplementedException();
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		throw new NotImplementedException();
	}

	public IEnumerator<T> GetEnumerator()
	{
		throw new NotImplementedException();
	}

	public int IndexOf(T item)
	{
		throw new NotImplementedException();
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
		throw new NotImplementedException();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		throw new NotImplementedException();
	}
}
