using System;
using System.Collections.Generic;
using System.Text;

class Testing
{
	public static void Main(string[] args)
	{
		Deque<int> deque = new Deque<int>();

		int number = 1000;

		for (int i = 0; i < number; i++)
		{
			deque.Add(i+1);
		}

		foreach (int value in deque)
		{
			Console.WriteLine("Item -> " + value);
		}

		Console.WriteLine("Pause");
		Console.ReadLine();

		for (int i = 0; i < number; i++)
		{
			deque[i] = -(i+1);
		}

		foreach (int value in deque)
		{
			Console.WriteLine("Item -> " + value);
		}
	}
}

