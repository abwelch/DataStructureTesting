﻿using System;

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
        private Node Tail { get; set; }
        public int NodeCount { get; set; }

        public SinglyLinkedList()
        {
            Tail = null;
            Head = null;
            NodeCount = 0;
        }

        public SinglyLinkedList(int val)
        {
            Head = new Node(val);
            Tail = Head;
            NodeCount = 1;
        }

        // Returns a bool indicating if the list is empty or not
        // Time Complexity: O(1)
        public bool IsEmpty()
        {
            if (Head == null)
                return true;
            return false;
        }

        // Time Complexity: O(1)
        public void Append(int val)
        {
            if (Head == null)
            {
                Head = new Node(val);
                Tail = Head;
                NodeCount++;
                return;
            }
            Tail.Next = new Node(val);
            Tail = Tail.Next;
            NodeCount++;
        }

        // Create and insert a node with the passed value
        // Note: position indexing is zero-based
        // Time Complexity: O(n)
        public bool Insert(int val, int position)
        {
            // Attempt to insert a node in a position that does not exist
            if (position > NodeCount || position < 0)
                return false;
            if (position == NodeCount)
            {
                Tail.Next = new Node(val);
                Tail = Tail.Next;
            }
            else if (position == 0)
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

        // Return a bool indicating if the specified argument value exists in the list
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
            if (pos == NodeCount - 1 || pos < 0)
            {
                return Tail.Value;
            }
            Node ptr = Head;
            for (int i = 0; i < pos && ptr != null; i++)
            {
                ptr = ptr.Next;
            }
            if (ptr != null)
                return ptr.Value;
            return null;
        }

        // Prints all node values starting at Head
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

        // Remove the first occurence of node containing specified value
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
                    if (ptr == Tail)
                    {
                        Tail = prev;
                        Tail.Next = null;
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

        // Remove node at specified position
        // Note: zero-based index
        // Time Complexity: O(n)
        public bool RemoveAt(int? pos)
        {
            if (pos == null || pos >= NodeCount || pos < 0)
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
            if (ptr.Next == Tail)
            {
                Tail = ptr;
                Tail.Next = null;
                NodeCount--;
                return true;
            }
            ptr.Next = ptr.Next.Next;
            NodeCount--;
            return true;
        }

        // Replaces the value of node at specified position with new value
        // Time Complexity: O(n)
        public bool Replace(int pos, int val)
        {
            if (pos >= NodeCount || pos < 0)
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
            Tail = Head;
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
