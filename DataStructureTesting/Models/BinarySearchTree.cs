using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunTimeAnalyzer.Models
{
    // BST is a binary tree that satisfies the BST invariant: left subtree has smaller elements than the right subtree
    // This implementation allows for duplicate values
    // Time Complexity: Average: O(log n). Worst: O(n) if tree degenerates to linked list (all elements increasing/decreasing)
    public class BinarySearchTree : BinaryTree
    {
        public BinarySearchTree() : base()
        { }

        public BinarySearchTree(int val) : base(val)
        { }

        // Iterative insert
        // Time Complexity: Average O(log n). Worst O(n)
        // Worst occurs if tree has degenerated into a list due to ever increasing or decreasing values inserted
        public void InsertIterative(int val)
        {
            Node ptr = Root;
            // Traverse until a leaf is reached
            while (true)
            {
                // Disallow duplicates
                if (val == ptr.Value)
                    return;
                if (val > ptr.Value)
                {
                    if (ptr.RightChild == null)
                    {
                        ptr.RightChild = new Node(val);
                        TotalNodes++;
                        return;
                    }
                    else
                    {
                        ptr = ptr.RightChild;
                    }
                }
                else
                {
                    if (ptr.LeftChild == null)
                    {
                        ptr.LeftChild = new Node(val);
                        TotalNodes++;
                        return;
                    }
                    else
                    {
                        ptr = ptr.LeftChild;
                    }
                }
            }
        }

        // Recursively insert
        // Time Complexity: Average O(log n). Worst O(n)
        // Worst occurs if tree has degenerated into a list due to ever increasing or decreasing values inserted
        protected Node InsertRecursive(int val, Node ptr)
        {
            // Base case
            if (ptr == null)
            {
                ptr = new Node(val);
                TotalNodes++;
            }
            else if (val > ptr.Value)
            {
                ptr.RightChild = InsertRecursive(val, ptr.RightChild);
            }
            else if (val < ptr.Value)
            {
                ptr.LeftChild = InsertRecursive(val, ptr.LeftChild);
            }
            return ptr;
        }

        // Publicly accessible method to InsertRecursive bc Root and Node are not publicly exposed
        public void CallInsertRecursive(int val)
            => InsertRecursive(val, Root);

        // Conduct a binary search for specified value
        // Time Complexity: Average O(log n). Worst O(n) if tree degrades into a list
        public bool Search(int val)
        {
            Node ptr = Root;
            while (ptr != null)
            {
                if (val == ptr.Value)
                {
                    return true;
                }
                else if (val > ptr.Value)
                {
                    ptr = ptr.RightChild;
                }
                else
                {
                    ptr = ptr.LeftChild;
                }
            }
            return false;
        }
    }
}
