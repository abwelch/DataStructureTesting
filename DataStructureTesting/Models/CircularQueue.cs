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
        {
            if (Head == -1)
                return true;
            return false;
        }

        public bool IsFull()
        {
            if ((Tail + 1 == Size && Head == 0) || Tail + 1 == Head)
                return true;
            return false;
        }

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
            if (Head + 1 == Size)
            {
                Head = 0;
            }
            else
            {
                Head++;
            }
            return val;
        }

    }
}
