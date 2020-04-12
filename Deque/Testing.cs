using System;
using System.Collections.Generic;
using System.Text;

class Testing
{
	public static void Main(string[] args)
	{
		Deque<int> deque = new Deque<int>();

		int number = 10;

		for (int i = 0; i < number; i++)
		{
			deque.Insert(i,i+1);
		}

		deque.Reversed.Insert(deque.Count, -1);

		Console.WriteLine("Item0 -> " + deque[0]);
		Console.WriteLine("ItemLast -> " + deque[number-1]);

		foreach (int item in deque)
		{
			Console.WriteLine("Item -> " + item);
		}
	}
}

