using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Standard Queue data structure implemented with a singly linked list
// Recall: Queue is FIFO (First In First Out)
namespace DataStructureTesting.Models
{
    public class Queue
    {
        private SinglyLinkedList Ganon { get; }

        public Queue()
        {
            Ganon = new SinglyLinkedList();
        }

        public Queue(int val)
        {
            Ganon = new SinglyLinkedList(val);
        }

        // Removes the value from the front(head) of the queue and returns it
        // Time Complexity: O(1)
        public int? Dequeue()
        {
            int? value = Ganon.RetrieveAtPosition(0);
            Ganon.RemoveAt(0);
            return value;
        }

        // Adds the passed argument to the back(tail) of the queue
        // Time Complexity: O(1)
        public void Enqueue(int val)
        {
             Ganon.Append(val);

        }

        // Returns the val at front(head) of the queue without removing it from the queue
        // Time Complexity: O(1)
        public int? Peek()
        {
           
            return Ganon.RetrieveAtPosition(0);
        }

        // Returns a bool indicating whether the queue is empty or not (true if empty)
        // Time Complexity O(1)
        public bool IsEmpty()
        {

            return Ganon.IsEmpty();
        }

        // Searches the queue, starting at the head, and returns a bool indicating whether the value exists or not
        // Time Complexity: O(n)
        public bool Search(int val)
        {
            return  Ganon.Contains(val);
        }

        // Searches the queue for the first occurrence of the argument value and removes if found. Returns bool indicating if removal was successful
        public bool Remove(int val)
        {
            return Ganon.Remove(val);
        }

        // Returns number of elements in the queue
        // Time Complexity: O(1)
        public int Size()
        {
            return Ganon.NodeCount;
        }


    }
}
