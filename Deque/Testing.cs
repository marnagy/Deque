using System;
using System.Collections.Generic;
using System.Text;

class Testing
{
	public static void Main(string[] args)
	{
		Deque<int> deque = new Deque<int>();

		int number = 5;

		for (int i = 0; i < number; i++)
		{
			deque.Add(i+1);
		}

		var rev = deque.Reversed;

		for (int i = 0; i < number; i++)
		{
			rev.Add(-(i+1));
		}

		foreach (int value in deque)
		{
			Console.WriteLine("Item -> " + value);
		}

		deque.Insert( 1, number*10);
		deque.Reversed.Insert( 1, -number*10);
		Console.WriteLine("Insert");

		foreach (int value in deque)
		{
			Console.WriteLine("Item -> " + value);
		}

		deque.Clear();
		Console.WriteLine("Cleared");

		foreach (int value in deque)
		{
			Console.WriteLine("Item -> " + value);
		}

		for (int i = 0; i < number; i++)
		{
			deque.Add(i+1);
		}

		foreach (int value in deque)
		{
			Console.WriteLine("Item -> " + value);
		}
	}
}

