using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Node<T>
{
    public T? value { get; set; }
    public Node<T>? next { get; set; }
    public Node ()
    {

    }
    public Node(T value, Node<T>? next)
    {
        this.value = value;
        this.next = next;
    }
}
