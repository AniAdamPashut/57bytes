﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Node<T>
{
    public T? Value { get; set; }
    public Node<T>? Next { get; set; }
    public Node ()
    {

    }
    public Node(T value, Node<T>? next)
    {
        this.Value = value;
        this.Next = next;
    }
}
