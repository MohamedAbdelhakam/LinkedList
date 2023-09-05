
public class LinkedList<T>
{
    private Node Head { get; set; }
    private Node Tail { get; set; }
    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
    }
    public void AddFirst(T value)
    {
        if (Head == null)
        {
            Head = new Node { Value = value, Next = null };
            Tail = Head;
        }
        else
        {
            Head = new Node { Value = value, Next = Head };
        }
    }
    public void AddLast(T value)
    {
        if (Tail == null)
        {
            AddFirst(value);
            return;
        }
        else
        {

            var newNode = new Node { Value = value, Next = null };
            Tail.Next = newNode;
            Tail = newNode;
        }
    }
    public void InsertAt(int position, T value)
    {
        if (position == 0)
        {
            AddFirst(value);
            return;
        }
        Node tempNode = Head;

        while (position != 1) //1 for previus position of the target position
        {
            try
            {
                tempNode = tempNode.Next;
                position--;
            }
            catch
            {
                Console.WriteLine($"index out of range");
                return;
            }
        }

        tempNode.Next = new Node { Value = value, Next = tempNode.Next };

        if (tempNode == Tail)
        {
            Tail = tempNode.Next;
        }
    }
    public bool delete(T value)
    {
        if (Head == null)
        {
            return false;
        }
        else if (Head.Value.Equals(value))
        {
            DeleteFirst();
            return true;
        }
        else
        {
            Node TempNode = Head;
            while (TempNode!=Tail && !TempNode.Next.Value.Equals(value))
            {
                TempNode = TempNode.Next;
            }
            if (TempNode == Tail)
            {
                return false;
            }
            TempNode.Next = TempNode.Next.Next;
            return true;
        }

    }
    public void DeleteFirst()
    {
        if (Head == null)
        {
            Console.WriteLine("Its is Empty");
            return;
        }

        Node TempNode = Head;
        Head = Head.Next;
        TempNode.Next = null;

    }
    public void DeleteLast()
    {
        if (Head == null)
        {
            Console.WriteLine("Its is Empty");
            return;
        }
        else if (Head == Tail)
        {
            this.DeleteFirst();
            return;
        }
        Node TempNode = Head;
        while (TempNode.Next != Tail)
        {
            TempNode = TempNode.Next;
        }
        Tail = TempNode;
        TempNode.Next = null;
    }
    public void Display()
    {
        Node node = Head;
        while (node != null)
        {
            Console.Write($"{node.Value}->");
            node = node.Next;
        }
        Console.WriteLine("End");
    }
}