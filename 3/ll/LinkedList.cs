using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public class LinkedList : IEnumerable<int>
{
    private Node<int> head;
    private Node<int> tail;

    private Node<int> max;
    private Node<int> min;

    public LinkedList() {

        head = null;
        tail = head;
        max = head;
        min = head;
    }

    public void Append(int item)
    {
        if (tail == head)
        {
            tail = new Node<int>(item, null);
            head = tail;
            max = tail;
            min = tail;
            return;
        } else
        {
            tail.Next = new Node<int>(item, null);
            tail = tail.Next;
        }
        int max_value = Math.Max(item, max.Value);
        if (max_value != max.Value)
        {
            max = tail;
        }
        int min_value = Math.Min(item, min.Value);
        if (min_value != min.Value)
        {
            min = tail;
        }
    }

    public void Prepend(int item)
    {
        head = new Node<int>(item, head);
        if (item > max.Value)
        {
            max = head;
        }
        if (item < min.Value)
        {
            min = head;
        }
    }

    private Node<int> Find(Func<int, int, int> cmp)
    {
        Node<int> runner = head;
        Node<int> res = new(0, null);
        while (runner != null)
        {
            if (cmp(res.Value, runner.Value) > 0)
            {
                res = runner;
            }
        }
        return res;
    }
    public int Dequeue() {
        int val = head.Value;
        head = head.Next;
        if (val == max.Value)
        {
            max = Find((a, b) => a - b);
        }
        else if (val == min.Value)
        {
            min = Find((a, b) => b - a);
        }
        return val;
    }

    public int Pop()
    {
        Node<int> runner = head;
        if (runner == null)
        {
            return -1;
        }
        if (runner.Next == null) {
        
        }
        while (runner.Next.Next != null)
        {
            runner = runner.Next;
        }
        int val = runner.Next.Value;
        runner.Next = null;

        if (val == max.Value)
        {
            max = Find((a, b) => a - b);
        }
        else if (val == min.Value)
        {
            min = Find((a, b) => b - a);
        }
        return val;
    }

    public bool IsCircular()
    {
        if (head == null) return false;

        Node<int> slow = head;
        Node<int> fast = head.Next;

        while (fast != null && fast.Next != null)
        {
            if (fast == slow) return true;
            fast = fast.Next.Next;
            slow = slow.Next;
        }
        return false;
    }

    public void Sort()
    {
        if (head == null)
        {
            return;
        }
        Node<int> current = head;
        while (current != null)
        {

            Node<int> second = current.Next;
            while (second != null)
            {

                if (current.Value > second.Value)
                {
                    int tmp = current.Value;
                    current.Value = second.Value;
                    second.Value = tmp;
                }
                second = second.Next;
            }
            current = current.Next;
        }
    }

    public Node<int> GetMaxNode()
    {
        return max;
    }
    public Node<int> GetMinNode()
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
    public Node<int> Head { get; set; }
    public Node<int> Runner { get; set; }
    public LinkedListIterator(Node<int> head)
    {
        this.Head = head;
        this.Runner = head;
    }

    object IEnumerator.Current
    {
        get
        {
            return Head;
        }
    }


    public bool MoveNext()
    {
        Runner = Runner.Next;
        return Runner != null;
    }

    public void Reset()
    {
        Runner = Head;
    }

    public int Current
    {
        get
        {
            try
            {
                return Runner.Value;
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}

