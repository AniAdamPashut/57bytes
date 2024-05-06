using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public class LinkedList : IEnumerable
{
    private Node<int>? head;
    private Node<int>? tail;

    private Node<int> max;
    private Node<int> min;

    public LinkedList() {

        head = new Node<int>();
        tail = head;
        max = new Node<int>(int.MinValue, null);
        min = new Node<int>(int.MaxValue, null); 
    }

    public void Append(int item)
    {
        if (tail == null)
        {
            tail = new Node<int>(item, null);
            head = tail;
        } else
        {
            tail.next = new Node<int>(item, null);
        }
        max = new Node<int>(Math.Max(item, max.value), max);
        min = new Node<int>(Math.Min(item, min.value), min);
        tail = tail.next;
    }

    public void Prepend(int item)
    {
        head = new Node<int>(item, head);
        max = new Node<int>(Math.Max(item, max.value), max);
        min = new Node<int>(Math.Min(item, min.value), min);
    }
    public int Dequeue() {
        int value = head.value;
        head = head.next;
        max = max.next;
        min = min.next;
        return value;
    }

    public int Pop()
    {
        Node<int> runner = head;
        while (runner.next.next != null)
        {
            runner = runner.next;
        }
        int val = runner.next.value;
        runner.next = null;
        max = max.next;
        min = min.next;
        return val;
    }

    public bool isCircular()
    {
        if (head == null) return false;

        Node<int> slow = head;
        Node<int> fast = head.next;

        while (fast != null && fast.next != null)
        {
            if (fast == slow) return true;
            fast = fast.next.next;
            slow = slow.next;
        }
        return false;
    }

    public void Sort()
    {
        Node<int> current = head;
        while (current != null)
        {

            Node<int> second = current.next;
            while (second != null)
            {

                if (current.value > second.value)
                {
                    int tmp = current.value;
                    current.value = second.value;
                    second.value = tmp;
                }
                second = second.next;
            }
            current = current.next;
        }
    }

    public int GetMaxNode()
    {
        return max.value;
    }
    public int GetMinNode()
    {
        return min.value;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }

    public LinkedListIterator GetEnumerator()
    {
        return new LinkedListIterator(head);
    }
}

public class LinkedListIterator : IEnumerator
{
    public Node<int> head { get; set; }
    public Node<int> runner { get; set; }
    public LinkedListIterator(Node<int> head)
    {
        this.head = head;
        this.runner = head;
    }

    object IEnumerator.Current
    {
        get
        {
            return head;
        }
    }


    public bool MoveNext()
    {
        runner = runner.next;
        return runner != null;
    }

    public void Reset()
    {
        runner = head;
    }

    public int Current
    {
        get
        {
            try
            {
                return runner.value;
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}

