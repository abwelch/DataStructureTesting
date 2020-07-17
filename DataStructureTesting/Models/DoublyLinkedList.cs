using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructureTesting.Models
{
    public class DoublyLinkedList
    {
        private class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }

            public Node(int val)
            {
                Value = val;
                Next = null;
                Previous = null;
            }
        }

        private Node Head { get; set; }
        private Node Tail { get; set; }
        public int NodeCount { get; set; }

        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
            NodeCount = 0;
        }

        public DoublyLinkedList(int val)
        {
            Head = new Node(val);
            Tail = Head;
            NodeCount = 1;
        }

        // Time Complexity: O(n)
        public void Append(int val)
        {
            // If list is empty
            if (Head == null)
            {
                Head = new Node(val);
                Tail = Head;
                NodeCount++;
            }
            else
            {
                Tail.Next = new Node(val);
                // Assign Previous on new final Node to point back to Tail
                Tail.Next.Previous = Tail;
                // Move Tail to new final node
                Tail = Tail.Next;
                // Update Head as well
                Head.Previous = Tail;
                NodeCount++;
            }
        }

        // Time Complexity: O(n)
        public bool Contains(int val)
        {
            Node ptr = Head;
            do
            {
                if (ptr.Value == val)
                    return true;
                ptr = ptr.Next;
            } while (ptr != Head);
            return false;
        }

        // Time Complexity: O(n)
        // Returns null if provided pos value is invalid
        public int? RetrieveAtPosition(int pos)
        {
            // Make this "smarter" by checking against totalNodes to determine if it's quicker to go backwards or forwards to the specified position
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
                if (ptr.Next == Tail.Next)
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

        // Used to ensure Previous links are properly aligned
        public void PrintListContentsReverse()
        {
            if (Head == null)
                return;
            Node ptr = Tail;
            Console.Write("{ ");
            while (true)
            {
                if (ptr.Previous == Head.Previous)
                {
                    Console.Write(ptr.Value);
                    break;
                }
                else
                {
                    Console.Write(ptr.Value + ", ");
                }
                ptr = ptr.Previous;
            }
            Console.Write(" }");
            Console.Write("\n");
        }

        public bool Replace(int pos, int val)
        {
            // Make this smarter as well by checking nodeCount to determine which direction to search in
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
    }
}
