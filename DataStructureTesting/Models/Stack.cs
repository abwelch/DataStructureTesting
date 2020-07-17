using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DataStructureTesting.Models
{
    public class Stack
    {
        public SinglyLinkedList Zelda { get; }

        public Stack()
        {
            Zelda = new SinglyLinkedList();

        }
        public Stack(int val)
        {
            Zelda = new SinglyLinkedList(val);
        }

        public bool Push(int val)
        {
            return Zelda.Insert(val, 0);
        }

        public int? Pop()
        {
            int? x = Zelda.RetrieveAtPosition(0);
            Zelda.RemoveAt(x);

            return x;
        }
        //scans the stack for a certain value, returns true or false 
        public bool Contains(int val)
        {
            return true;
        }
        // scans the stack for certain val, returns position of first instance ofthat value
        public int FindPosition(int val)
        {
            return 0;
        }
    }


}
