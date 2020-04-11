﻿using System;
using System.Collections.Generic;
using System.Text;

public interface IDeque<T> : IList<T>
{
	int Capacity { get; }
	bool IsEmpty { get; }
	IDeque<T> Reversed { get; }

	public void AddFirst(T item);
	public void AddLast(T item);
	public T PeekFirst();
	public T PeekLast();
	public T PopFirst();
	public T PopLast();
	public void Reverse();
}