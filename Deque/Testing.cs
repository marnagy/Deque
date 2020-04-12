using System;
using System.Collections.Generic;
using System.Text;

class Testing
{
	public static void Main(string[] args)
	{
		Deque<int> deque = new Deque<int>();

		int number = 50;
		for (int k = 0; k < number; k++)
		{
			deque.Add( k);
		}

		foreach (int item in deque)
		{
			Console.WriteLine("Item -> " + item);

		}

		deque.Reversed.Insert(50, -1);

		foreach (int item in deque)
		{
			Console.WriteLine("Item -> " + item);

		}

		deque.Clear();
		
	}
}

