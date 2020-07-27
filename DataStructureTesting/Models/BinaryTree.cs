using System;
using System.Collections.Generic;

namespace RunTimeAnalyzer.Models
{
    public class BinaryTree
    {
        protected class Node
        {
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }
            public int Value { get; set; }


            public Node()
            { }

            public Node(int val)
            {
                Value = val;
            }
        }

        protected Node Root { get; }
        protected int TotalNodes { get; set; }

        public BinaryTree()
        {
            Root = null;
        }

        public BinaryTree(int val)
        {
            Root = new Node(val);
            TotalNodes++;
        }

        #region [Traversal Methods]

        // Also referred to as Breath First traversal
        // Visits all nodes at a each level prior to moving to next level
        // Time Complexity: O(n)
        public void LevelOrderTraversalPrint()
        {
            Queue<Node> traversingQueue = new Queue<Node>();
            Queue<Node> storageQueue = new Queue<Node>();
            traversingQueue.Enqueue(Root);
            while (traversingQueue.Count > 0)
            {
                Node current = traversingQueue.Dequeue();
                if (current == null)
                    continue;
                traversingQueue.Enqueue(current.LeftChild);
                traversingQueue.Enqueue(current.RightChild);

                storageQueue.Enqueue(current);
            }
            while (storageQueue.Count > 0)
            {
                Console.WriteLine(storageQueue.Dequeue().Value);
            }
        }

        // A DFS (Depth First Search) traversal technique
        // Visit current node, then left, then right (NLR)
        // Time Complexity: O(n)
        protected void PreOrderTraversalRecursive(Node ptr)
        {
            Console.WriteLine(ptr.Value);
            if (ptr.LeftChild != null)
            {
                PreOrderTraversalRecursive(ptr.LeftChild);
            }
            if (ptr.RightChild != null)
            {
                PreOrderTraversalRecursive(ptr.RightChild);
            }
        }

        // Publicly accessible method to PreOrderTraversalRecursive bc Root and Node are not publicly exposed
        public void CallPreOrderTraversalRecursive()
            => PreOrderTraversalRecursive(Root);

        // A DFS (Depth First Search) traversal technique
        // Visit left node, then current, then right (LNR)
        // Time Complexity: O(n)
        protected void InOrderTraversalRecursive(Node ptr)
        {
            if (ptr.LeftChild != null)
            {
                InOrderTraversalRecursive(ptr.LeftChild);
            }
            Console.WriteLine(ptr.Value);
            if (ptr.RightChild != null)
            {
                InOrderTraversalRecursive(ptr.RightChild);
            }
        }

        // Publicly accessible method to InOrderTraversalRecursive bc Root and Node are not publicly exposed
        public void CallInOrderTraversalRecursive()
            => InOrderTraversalRecursive(Root);

        // A DFS (Depth First Search) traversal technique
        // Visit left node, right node, then current (LRN)
        // Time Complexity: O(n)
        protected void PostOrderTraversalRecursive(Node ptr)
        {
            if (ptr.LeftChild != null)
            {
                PostOrderTraversalRecursive(ptr.LeftChild);
            }
            if (ptr.RightChild != null)
            {
                PostOrderTraversalRecursive(ptr.RightChild);
            }
            Console.WriteLine(ptr.Value);
        }

        // Publicly accessible method to PostOrderTraversalRecursive bc Root and Node are not publicly exposed
        public void CallPostOrderTraversalRecursive()
            => PostOrderTraversalRecursive(Root);

        #endregion [Traversal Methods]

        // Calculates the height of the binary tree by traversing Root's left and right subtrees
        // Time Complexity: O(n)
        protected int FindHeight(Node ptr)
        {
            if (ptr == null)
                return -1;
            int left = FindHeight(ptr.LeftChild);
            int right = FindHeight(ptr.RightChild);
            if (left > right)
                return left + 1;
            return right + 1;
        }

        // Publicly accessible method to FindHeight bc Root and Node are not publicly exposed
        public int CallFindHeight() => FindHeight(Root);

        // Determines if the tree has degenerated into a linked list
        public bool IsDegenerated() => TotalNodes - 1 == FindHeight(Root);
    }
}
