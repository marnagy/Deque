using System;
using System.Collections.Generic;
using System.Text;

class Testing
{
	public static void Main(string[] args)
	{
		Deque<int> deque = new Deque<int>();

		int number = 5;
		for (int k = 0; k < number; k++)
		{
			deque.Reversed.Add( k);
		}

		foreach (int item in deque.Reversed)
		{
			Console.WriteLine("Item -> " + item);

		}

		deque.Reversed.Insert(0, 100);

		Console.WriteLine("Inserted 100 to index 2");

		foreach (int item in deque.Reversed)
		{
			Console.WriteLine("Item -> " + item);

		}

		deque.Clear();
		
	}
}

