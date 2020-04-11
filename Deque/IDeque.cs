using System;
using System.Collections.Generic;
using System.Text;

public interface IDeque<T> : IList<T>
{
	int Capacity { get; }
	bool IsEmpty { get; }
	IList<T> Reversed { get; }

	void AddFirst(T item);
	void AddLast(T item);
	T PeekFirst();
	T PeekLast();
	T PopFirst();
	T PopLast();
	void Reverse();
	void Move(int from, int to);
}
