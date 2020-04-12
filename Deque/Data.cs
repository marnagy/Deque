using System;
using System.Collections.Generic;
using System.Text;

internal class Data<T>
{
    public static readonly int size = 64;
    public bool IsValid = false;
    public int currentSize { 
        get {
            if (start == -1 || end == -1)
            {
                return 0;
            }
            else
            {
                return end - start + 1;
            }
        }
    }
    // indicis of first and last ALREADY OCCUPIED places in array
    internal int start = -1, end = -1;
    // initialized with nulls inside
    internal T[] arr = new T[size];

    public Data(T item, bool indexOnStart = false, bool indexOnEnd = false)
    {
        if (indexOnStart && indexOnEnd)
        {
            throw new ArgumentException("Cannot be on start and on end at the same time.");
        }

        if (indexOnStart)
        {
            this.start = 0;
        }
        else
        {
            if (indexOnEnd)
            {
                this.start = size - 1;
            }
            else
            {
                this.start = size / 2;
            }
        }
        IsValid = true;
        this.end = start;
        arr[this.start] = item;
    }

    public T Get(int index, bool inversed)
    {
        if (!inversed)
        {
            return arr[start + index];
        }
        else
        {
            return arr[end - index];
        }
    }

    public T this[int index] {  get {
            if (index < 0 || start + index > end)
            {
                throw new IndexOutOfRangeException();
            }
            // CONTINUE HERE
            return arr[start + index];
        } }

    public void Add(T data, bool inverted)
    {
        if (inverted)
        {
            if (start == 0)
            {
                throw new InvalidOperationException("Cannot add more data here.");
            }
            else
            {
                arr[--start] = data;
            }
        }
        else
        {
            if (end == size - 1)
            {
                throw new InvalidOperationException("Cannot add more data here.");
            }
            else
            {
                arr[++end] = data;
            }
        }
    }

    public void Remove(bool inverted)
    {
        if (inverted)
        {
            if ( end < 0 )
            {
                throw new InvalidOperationException("Cannot add more data here.");
            }
            else
            {
                // remove last item in Data Node
                if (start == end)
                {
                    start = -1;
                    end = -1;
                }
                else
                {
                    end--;
                }
            }
        }
        else
        {
            if (start == size - 1)
            {
                throw new InvalidOperationException("Cannot add more data here.");
            }
            else
            {
                start++;
            }
        }
    }
    public T[] GetStoredValues()
    {
        if ( IsValid ){
            T[] res = new T[currentSize];
            Array.Copy(arr, start, res, 0, currentSize);
            return res;
        }
        else
        {
            throw new InvalidOperationException("This is invalid Data Node.");
        }
    }
}
