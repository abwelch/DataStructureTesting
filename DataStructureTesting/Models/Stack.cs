namespace DataStructureTesting.Models
{
    // A standard Stack data structure implemented with a singly linked list
    // Recall: Stacks are LIFO (Last In First Out)
    public class Stack
    {
        private SinglyLinkedList Zelda { get; }

        public Stack()
        {
            Zelda = new SinglyLinkedList();
        }

        public Stack(int val)
        {
            Zelda = new SinglyLinkedList(val);
        }

        // Adds the new value to the top of the stack
        // Time Complexity: O(1)
        public bool Push(int val)
        {
            return Zelda.Insert(val, 0);
        }

        // Removes value from the top of the stack and returns
        // Time Complexity: O(1)
        public int? Pop()
        {
            int? x = Zelda.RetrieveAtPosition(0);
            Zelda.RemoveAt(x);
            return x;
        }

        // View value at top of the stack
        // Time Complexity: O(1)
        public int? Peek()
        {
            return Zelda.RetrieveAtPosition(0);
        }


        // Returns number of elements in the stack
        // Time Complexity: O(1)
        public int Size()
        {
            return Zelda.NodeCount;
        }

        // Returns bool if the stack is empty or not
        // Time Complexity: O(1)
        public bool IsEmpty()
        {
            if (Zelda.NodeCount == 0)
            {
                return true;
            }
            return false;
        }

        // Scans the stack for a certain value, returns true or false 
        // Time Complexity: O(n)
        public bool Contains(int val)
        {
            return Zelda.Contains(val);

        }
        // Returns value in a certain position
        // Time Complexity: O(n)
        public int? ValueAtPosition(int pos)
        {
            return Zelda.RetrieveAtPosition(pos);
        }

        // Prints elements in the stack, starting at Head
        // Time Complexity: O(n)
        public void PrintStackContent()
        {
            Zelda.PrintListContents();
        }
    }
}
