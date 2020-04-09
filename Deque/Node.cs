using System;
using System.Collections.Generic;
using System.Text;

internal class Node
{
    public const int size = 64;
    internal byte? start, end;
    public Node previous { get; private set; }
    public Node next { get; private set; }

    internal Node(Node previous = null, Node next = null, byte? start = null, byte? end = null)
    {
        this.previous = previous;
        this.next = next;
        this.start = start;
        this.end = end;
    }
    internal void Init()
    {

    }
}
