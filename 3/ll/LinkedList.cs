using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public class LinkedList : IEnumerable<int>
{
    private Node<int>? head;
    private Node<int>? tail;

    private int max;
    private int min;

    public LinkedList() {

        head = new Node<int>();
        tail = head;
        max = int.MinValue;
        min = int.MaxValue;
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
        max = Math.Max(item, max);
        min = Math.Min(item, min);
        tail = tail.next;
    }

    public void Prepend(int item)
    {
        head = new Node<int>(item, head);
        max = Math.Max(item, max);
        min = Math.Min(item, min);
    }
    public int Dequeue() {
        int val = head.value;
        head = head.next;
        if (val == max)
        {
            max = this.Max();
        }
        else if (val == min)
        {
            min = this.Min();
        }
        return val;
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

        if (val == max)
        {
            max = this.Max();
        } else if (val == min)
        {
            min = this.Min();
        }
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
        return max;
    }
    public int GetMinNode()
    {
        return min;
    }

    IEnumerator<int> IEnumerable<int>.GetEnumerator()
    {
        return (IEnumerator<int>)GetEnumerator();
    }

    public LinkedListIterator GetEnumerator()
    {
        return new LinkedListIterator(head);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
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

