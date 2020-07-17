using Microsoft.AspNetCore.Http;
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

        public int? Peek()
        {
            return Zelda.RetrieveAtPosition(0);
        }


        // returns number of elements in the stack
        public int Size()
        {
            return Zelda.NodeCount;
        }
        // returns bool if the stack is empty or not
        public bool IsEmpty()
        {
            if(Zelda.NodeCount == 0)
            {
                return true;
            }
            return false;
        }


        //scans the stack for a certain value, returns true or false 
        public bool Contains(int val)
        {
            return Zelda.Contains(val);

        }
        // returns value in a certain position
        public int? ValueAtPosition(int pos)
        {
            return Zelda.RetrieveAtPosition(pos);
        }
    }


}
