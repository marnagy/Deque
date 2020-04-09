using System;
using System.Collections.Generic;
using System.Text;

internal class Node
{
    public const int size = 64;
    internal byte start, end;
    public Node previous { get; private set; } = null;
    public Node next { get; private set; } = null;

    internal Node()
    {

    }
}
