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

		Console.WriteLine("Item0 -> " + deque[0]);
		Console.WriteLine("ItemLast -> " + deque[number-1]);
		Console.WriteLine("IndexTest -> " + deque.IndexOf(number));
		deque.Remove(number);

		foreach (int item in deque)
		{
			Console.WriteLine("Item -> " + item);
			deque.Add(2);
		}
	}
}

