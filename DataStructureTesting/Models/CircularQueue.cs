using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunTimeAnalyzer.Models
{
    /* DESCRIPTION:
     * A circular queue is one in which the the tail can "wrap around" to the front of the queue if space is available
     * In a simple static queue, once elements are dequeued, the space is no longer available for use.
     * In a circular queue, the tail can utiilze elements at the front of the queue if it detects the space is unoccupied
     * Implemented using static array
     */
    public class CircularQueue
    {
        private int[] Array { get; }
        private int Size { get; }
        private int Head { get; set; }
        private int Tail { get; set; }

        public CircularQueue(int size)
        {
            Array = new int[size];
            Head = -1;
            Tail = -1;
            Size = size;
        }

        // Time Complexity: O(1)
        public bool IsEmpty()
            => (Head == -1);

        // Time Complexity: O(1)
        public bool IsFull()
            => ((Tail + 1 == Size && Head == 0) || Tail + 1 == Head);

        // Inserts a new element at tail of the queue and returns bool indicating if operation was successful
        // Time Complexity: O(1)
        public bool Enqueue(int val)
        {
            if (IsFull())
                return false;
            if (Tail + 1 == Size)
            {
                Tail = 0;
                Array[Tail] = val;
            }
            else if (Head != -1)
            {
                Tail++;
                Array[Tail] = val;
            }
            // Queue was empty
            else
            {
                Head = 0;
                Tail = 0;
                Array[Tail] = val;
            }
            return true;
        }

        // Removes element at the head of the queue. Returns null if queue is empty
        // Time Complexity: O(1)
        public int? Dequeue()
        {
            if (IsEmpty())
                return null;
            int val = Array[Head];
            if (Head == Tail)
            {
                Head = -1;
                Tail = -1;
            }
            else
            {
                Head = (Head + 1 == Size) ? 0 : ++Head;
            }
            return val;
        }

        // Returns element at the head of the queue, without removing it from the queue. Returns null if queue is empty
        // Time Complexity: O(1)
        public int? Peek()
        {
            if (IsEmpty())
                return null;
            return Array[Head];
        }

        // Prints all elements within the queue, starting at the head
        // Time Complexity: O(n)
        public void PrintContents()
        {
            if (Head == -1)
                return;
            Console.Write("{");
            int traverse = Head;
            while (traverse != Tail)
            {
                Console.Write($" {Array[traverse]},");
                traverse = (traverse == Size - 1) ? 0 : ++traverse;
            }
            Console.Write($" {Array[traverse]}");
            Console.WriteLine(" }");
        }
    }
}
