using System;
using System.Collections.Generic;
using System.Text;

class Testing
{
	public static void Main(string[] args)
	{
		Deque<int> deque = new Deque<int>();

		for (int i = 0; i < 10_000; i++)
		{
			deque.Add(i+1);
		}

		foreach (int value in deque)
		{
			Console.WriteLine("Item -> " + value);
		}
	}
}

