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

        // Inserts a new node at the end(tail) of the list
        // Time Complexity: O(n)
        public void Append(int val)
        {
            // If list is empty
            if (Head == null)
            {
                Head = new Node(val);
                Tail = Head;
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
            }
            NodeCount++;
        }

        // Returns a bool indicating whether the passed argument exists within the list or not
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

        // Returns the val of the node at specified position (zero-based indexing)
        // Returns null if provided pos value is invalid
        // Time Complexity: O(n)
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

        // Print the value of each node in the list, starting at the head
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

        // Print the entire list, starting at the tail
        // Used to ensure Previous links are properly aligned
        // Time Complexity: O(n)
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

        // Replaces the value of node at specified position with passed argument value
        // Time Complexity: O(n)
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

        // Inserts node a specified index (zero-based). Nodes after the specified index are all moved back one.
        // Time Complexity: O(n)
        public bool Insert(int val, int position)
        {
            // Attempt to insert a node in a position that does not exist
            if (position > NodeCount)
                return false;
            // Insert at tail
            if (position == NodeCount)
            {
                Tail.Next = new Node(val);
                Tail.Next.Previous = Tail;
                Tail = Tail.Next;
                Tail.Next = Head;
                Head.Previous = Tail;
            }
            // Insert at head
            else if (position == 0)
            {
                Node newHead = new Node(val);
                newHead.Previous = Tail;
                Tail.Next = newHead;
                newHead.Next = Head;
                Head.Previous = newHead;
                Head = newHead;
            }
            else
            {
                Node ptr = Head;
                // Traverse through list until at new node position
                for (int i = 0; i < position; i++)
                {
                    ptr = ptr.Next;
                }
                Node newNode = new Node(val);
                Node temp = ptr.Previous;
                ptr.Previous = newNode;
                newNode.Next = ptr;
                newNode.Previous = temp;
                temp.Next = newNode;
            }
            NodeCount++;
            return true;
        }
    }
}
