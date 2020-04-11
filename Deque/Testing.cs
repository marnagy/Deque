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

		foreach (int value in deque)
		{
			Console.WriteLine("Item -> " + value);
		}

		Console.WriteLine("Reversed");

		deque.Reversed.Add(0);

		deque.Reversed.RemoveAt(1);

		foreach (int value in deque.Reversed)
		{
			Console.WriteLine("Item -> " + value);
		}

		//deque.Remove(3);

		Console.WriteLine("Regular");

		foreach (int value in deque)
		{
			Console.WriteLine("Item -> " + value);
		}
	}
}

