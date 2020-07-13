using System;
using System.Collections.Generic;
using System.Linq;
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
