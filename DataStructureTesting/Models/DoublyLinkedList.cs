using System;

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

        // Returns a bool indicating if the list is empty or not
        // Time Complexity: O(1)
        public bool IsEmpty()
        {
            if (Head == null)
                return true;
            return false;
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
            if (pos >= NodeCount || pos < 0)
                return null;
            Node ptr;
            // Determine if starting at Head or Tail is faster
            if (pos < NodeCount / 2)
            {
                // Traverse down list, starting at Head
                ptr = Head;
                for (int i = 0; i < pos; i++)
                    ptr = ptr.Next;
            }
            else
            {
                // Traverse up list, starting at Tail
                ptr = Tail;
                for (int i = NodeCount - 1; i > pos; i--)
                    ptr = ptr.Previous;
            }
            return ptr.Value;
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
            if (pos >= NodeCount || pos < 0)
                return false;
            if (pos == 0)
            {
                Head.Value = val;
                return true;
            }
            Node ptr;
            // Determine if starting at Head or Tail is faster
            if (pos < NodeCount / 2)
            {
                // Traverse down list, starting at Head
                ptr = Head;
                for (int i = 0; i < pos; i++)
                    ptr = ptr.Next;
            }
            else
            {
                // Traverse up list, starting at Tail
                ptr = Tail;
                for (int i = NodeCount - 1; i > pos; i--)
                    ptr = ptr.Previous;
            }
            ptr.Value = val;
            return true;
        }

        // Inserts node a specified index (zero-based). Nodes after the specified index are all moved back one.
        // Time Complexity: O(n)
        public bool Insert(int val, int position)
        {
            // Attempt to insert a node in a position that does not exist
            if (position > NodeCount || position < 0)
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

        // Remove the first occurrence of the node with specified value
        // Time Complexity: O(n)
        public bool Remove(int val)
        {
            Node ptr = Head;
            while (ptr != null)
            {
                if (ptr.Value == val)
                {
                    if (ptr == Head)
                    {
                        Head = Head.Next;
                        Head.Previous = Tail;
                        Tail.Next = Head;
                    }
                    else if (ptr == Tail)
                    {
                        Tail = Tail.Previous;
                        Tail.Next = Head;
                        Head.Previous = Tail;
                    }
                    else
                    {
                        ptr.Previous.Next = ptr.Next;
                        ptr.Next.Previous = ptr.Previous;
                    }
                    NodeCount--;
                    return true;
                }
                ptr = ptr.Next;
            }
            return false;
        }

        // Remove node at specified position
        // Time Complexity: O(n-1)
        public bool RemoveAt(int pos)
        {
            // Index out-of-bounds
            if (pos >= NodeCount || pos < 0)
                return false;
            // Remove at head
            if (pos == 0)
            {
                Head = Head.Next;
                Head.Previous = Tail;
                Tail.Next = Head;
            }
            // Removal at Tail
            else if (pos == NodeCount - 1)
            {
                Tail = Tail.Previous;
                Tail.Next = Head;
                Head.Previous = Tail;
            }
            // Removal elsewhere in list
            else
            {
                Node ptr;
                // Determine if starting at Head or Tail is faster
                if (pos < NodeCount / 2)
                {
                    // Traverse down list, starting at Head
                    ptr = Head;
                    for (int i = 0; i < pos; i++)
                        ptr = ptr.Next;
                }
                else
                {
                    // Traverse up list, starting at Tail
                    ptr = Tail;
                    for (int i = NodeCount - 1; i > pos; i--)
                        ptr = ptr.Previous;
                }
                ptr.Previous.Next = ptr.Next;
                ptr.Next.Previous = ptr.Previous;
            }
            return true;
        }
    }
}
