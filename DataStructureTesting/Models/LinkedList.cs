using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataStructureTesting.Models
{
    public class LinkedList
    {
        private class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }

            public Node(int val)
            {
                Value = val;
                Next = null;
            }
        }

        private Node Head { get; set; }
        public int NodeCount { get; set; }

        public LinkedList()
        {
            Head = null;
            NodeCount = 0;
        }

        public LinkedList(int val)
        {
            Head = new Node(val);
            NodeCount = 1;
        }

        public void Append(int val)
        {
            Node ptr = Head;
            // Traverse to end of list
            while (ptr.Next != null)
            {
                ptr = ptr.Next;
            }
            ptr.Next = new Node(val);
            NodeCount++;
        }
        
        // Note: position indexing is zero-based
        public bool Insert(int val, int position)
        {
            // Attempt to insert a node in a position that does not exist
            if (position > NodeCount)
                return false;
            if (position == 0)
            {
                Node newHead = new Node(val);
                newHead.Next = Head;
                Head = newHead;
            }
            else
            {
                Node ptr = Head;
                // Iterate to the node proceeding desired position to insert (ex: if index 2, iterate to second node)
                for (int i = 0; i < position-1; i++)
                {
                    ptr = ptr.Next;
                }
                Node temp = ptr.Next;
                ptr.Next = new Node(val);
                ptr = ptr.Next;
                ptr.Next = temp;
            }
            NodeCount++;
            return true;
        }

        public bool Contains(int val)
        {
            Node ptr = Head;
            while (ptr != null)
            {
                if (ptr.Value == val)
                    return true;
                ptr = ptr.Next;
            }
            return false;
        }

        // Returns null if provided pos value is invalid
        public int? RetrieveAtPosition(int pos)
        {
            Node ptr = Head;
            for (int i = 0; i < pos && ptr != null; i++)
            {
                ptr = ptr.Next;
            }
            if (ptr != null)
                return ptr.Value;
            return null;
        }

        public void PrintListContents()
        {
            if (Head == null)
                return;
            Node ptr = Head;
            Console.Write("{ ");
            while (true)
            {
                if (ptr.Next == null)
                {
                    Console.Write(ptr.Value);
                    break;
                }
                else
                {
                    Console.Write(ptr.Value + ", ");
                }
                ptr = ptr.Next;
            }
            Console.Write(" }");
            Console.Write("\n");
        }
    }
}
