using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunTimeAnalyzer.Models
{
    // Implemented using static array
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

        public bool IsEmpty()
            => (Head == -1);

        public bool IsFull()
            => ((Tail + 1 == Size && Head == 0) || Tail + 1 == Head);

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

        public int? Peek()
        {
            if (IsEmpty())
                return null;
            return Array[Head];
        }

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
