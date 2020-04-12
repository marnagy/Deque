using System;
using System.Collections.Generic;
using System.Text;

class Testing
{
	public static void Main(string[] args)
	{
		Deque<int> deque = new Deque<int>();

		int number = 40;
		for (int k = 0; k < number; k++)
		{
			deque.Add( k+1);
		}
		for (int k = 0; k < number; k++)
		{
			Console.WriteLine("Index -> " + deque.IndexOf(k+1));
		}

		foreach (int item in deque)
		{
			Console.WriteLine("Item -> " + item);
		}

		deque.Clear();
		
	}
}

