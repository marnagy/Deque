using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

class DequeObj<T> : IList<T>
{
	Dictionary<int, Data<T>> map = new Dictionary<int, Data<T>>();
    int front, end;
    public uint size {get; private set;} = 0;

    public DequeObj()
    {

    }

    public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public int Count { get => (int)size; }

    public bool IsReadOnly => false;

    public void Add(T item)
    {
        //if (size != 0)
        //{
        //    var dataNode = map[end];
        //    if (dataNode.end == Data<T>.size - 1)
        //    {
        //        map.Add(++end, new Data<T>(item, inverted));
        //    }
        //    else
        //    {
        //        dataNode.Add(item, this.inverted);
        //    }
        //}
        //else
        //{
        //    var node = new Data<T>(item, inverted);
        //    front = 0;
        //    end = 0;
        //    map.Add(0, node);
        //}
        //size++;
    }

    public void AddFront(T item)
    {

    }

    public void AddEnd(T item)
    {

    }

    public void Clear()
    {
        map.Clear();
        this.size = 0;
        front = -1;
        end = -1;
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

    internal void RemoveFront()
    {
        throw new NotImplementedException();
    }

    internal void RemoveEnd()
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
        return GetEnumerator(inverted: false);
    }
    internal IEnumerator<T> GetEnumerator(bool inverted)
    {
        throw new NotImplementedException();
    }
}
