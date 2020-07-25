﻿using System;
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

        public void InsertIterative(int val)
        {
            Node ptr = Root;
            while (true)
            {
                if (val > ptr.Value)
                {
                    if (ptr.RightChild == null)
                        ptr.RightChild = new Node(val);
                }
                else
                {

                }
            }

        }

        // Publicly accessible method to call InsertRecursive bc Root and Node are not publicly exposed
        public void CallInsertRecursive(int val)
            => InsertRecursive(val, Root);

        protected void InsertRecursive(int val, Node ptr)
        {
            // Base case
            if (ptr == null)
            {
                ptr = new Node(val);
                return;
            }

            if (val > ptr.Value)
            {
                //ptr = 
            }
            else
            {

            }
        }

        public bool Search(int val)
        {
            return true;
        }
    }
}
