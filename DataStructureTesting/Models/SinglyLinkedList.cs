using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;

namespace DataStructureTesting.Models
{
    public class SinglyLinkedList
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

        public SinglyLinkedList()
        {
            Head = null;
            NodeCount = 0;
        }

        public SinglyLinkedList(int val)
        {
            Head = new Node(val);
            NodeCount = 1;
        }

        // Time Complexity: O(n)
        public void Append(int val)
        {
            if (Head == null)
            {
                Head = new Node(val);
                NodeCount++;
                return;
            }
            Node ptr = Head;
            // Traverse to end of list
            while (ptr.Next != null)
            {
                ptr = ptr.Next;
            }
            ptr.Next = new Node(val);
            NodeCount++;
        }

        // Time Complexity: O(n)
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
                for (int i = 0; i < position - 1; i++)
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

        // Time Complexity: O(n)
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

        // Time Complexity: O(n)
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

        // Time Complexity: O(n)
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

        // Time Complexity: O(n)
        public bool Remove(int val)
        {
            Node ptr = Head;
            Node prev = null;
            while (ptr != null)
            {
                if (ptr.Value == val)
                {
                    // If very first element
                    if (ptr == Head)
                    {
                        Head = Head.Next;
                        NodeCount--;
                        return true;
                    }
                    // If later in list
                    prev.Next = ptr.Next;
                    NodeCount--;
                    return true;
                }
                prev = ptr;
                ptr = ptr.Next;
            }
            return false;
        }

        public bool RemoveAt(int pos)
        {

            if (pos > NodeCount)
                return false;
            if (pos == 0)
            {
                Head = Head.Next;
                NodeCount--;
                return true;
            }
            Node ptr = Head;
            int counter = 0;
            while (counter != pos - 1)
            {
                ptr = ptr.Next;
                counter++;

            }
            ptr.Next = ptr.Next.Next;
            NodeCount--;
            return true;
        }

        public bool Replace(int pos, int val)
        {
            if (pos > NodeCount)
                return false;
            if (pos == 0)
            {
                Head.Value = val;
                return true;
            }
            Node ptr = Head;
            int counter = 0;
            while (counter != 0)
            {
                ptr = ptr.Next;
                counter++;
            }
            ptr.Value = val;
            return true;
        }

        // Reverses the order of the nodes
        // Time Complexity: O(n)
        public void Reverse()
        {
            Node current = Head;
            Node prev = null;
            Node next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            // Assign head to final valid node in list (now considered the new Head)
            Head = prev;
        }
    }
}

