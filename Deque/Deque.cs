using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Deque<T> : IList<T>
{
    bool inverted;
    private DequeObj<T> obj;
    public Deque( bool inverted = false)
    {
        this.inverted = inverted;
    }

    private Deque( Deque<T> deque, bool inverted)
    {
        this.obj = deque.obj;
        this.inverted = inverted;
    }

    public T this[int index] { get => obj[index]; set => obj[index] = value; }

    public int Count => obj.Count;

    public bool IsReadOnly => obj.IsReadOnly;

    public static Deque<T> Invert(Deque<T> deque)
    {
        return new Deque<T>(deque, !deque.inverted);
    }

    public void Add(T item)
    {
        if (inverted)
        {
            obj.AddFront(item);
        }
        else
        {
            obj.AddEnd(item);
        }
    }

    public void Clear()
    {
        obj.Clear();
    }

    public bool Contains(T item)
    {
        foreach (T item2 in obj)
        {
            if (item2.Equals(item))
            {
                return true;
            }
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return obj.GetEnumerator(inverted);
    }

    public int IndexOf(T item)
    {
        return obj.IndexOf(item);
    }

    public void Insert(int index, T item)
    {
        obj.Insert(index, item);
    }

    public bool Remove(T item)
    {
        return obj.Remove(item);
    }

    public void RemoveAt(int index)
    {
        obj.RemoveAt(index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return obj.GetEnumerator(inverted);
    }
}

public static class DequeTest {
	public static IList<T> GetReverseView<T>(Deque<T> d) {
		return Deque<T>.Invert(d);
	}
}