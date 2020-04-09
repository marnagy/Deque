using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Deque<T> : IList<T>
{
    bool inverted = false;
    Dictionary<int, Data<T>> map = new Dictionary<int, Data<T>>();
    int front, end;
    public uint size {get; private set;} = 0;

    public Deque()
    {

    }
    public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public int Count { get {
            int sum = 0;
            foreach( var Value in map.Values)
            {
                sum += Value.currentSize;
            }
            return sum;
    } }

    public bool IsReadOnly => false;

    public void Add(T item)
    {
        if (size != 0)
        {
            var dataNode = map[end];
            if (dataNode.end == Data<T>.size - 1)
            {
                map.Add(++end, new Data<T>(item, inverted));
            }
            else
            {
                dataNode.
            }
        }
        else
        {
            var node = new Data<T>(item, inverted);
            front = 0;
            end = 0;
            map.Add(0, node);
            size++;
        }
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public int IndexOf(T item)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, T item)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
