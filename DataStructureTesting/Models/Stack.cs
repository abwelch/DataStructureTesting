namespace DataStructureTesting.Models
{
    // A standard Stack data structure implemented with a singly linked list
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

        // Time Complexity: O(n)
        public bool Push(int val)
        {
            return Zelda.Insert(val, 0);
        }

        // Time Complexity: O(1)
        public int? Pop()
        {
            int? x = Zelda.RetrieveAtPosition(0);
            Zelda.RemoveAt(x);

            return x;
        }

        // Time Complexity: O(1)
        public int? Peek()
        {
            return Zelda.RetrieveAtPosition(0);
        }


        // returns number of elements in the stack
        // Time Complexity: O(n)
        public int Size()
        {
            return Zelda.NodeCount;
        }

        // returns bool if the stack is empty or not
        // Time Complexity: O(1)
        public bool IsEmpty()
        {
            if (Zelda.NodeCount == 0)
            {
                return true;
            }
            return false;
        }

        // scans the stack for a certain value, returns true or false 
        // Time Complexity: O(n)
        public bool Contains(int val)
        {
            return Zelda.Contains(val);

        }
        // returns value in a certain position
        // Time Complexity: O(n)
        public int? ValueAtPosition(int pos)
        {
            return Zelda.RetrieveAtPosition(pos);
        }
    }
}
