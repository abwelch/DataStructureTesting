using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunTimeAnalyzer.Models
{
    // Binary Tree is a tree for which every node has at most two children
    public class BinaryTree
    {
        protected class Node
        {
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }
            public Node Parent { get; set; }
            public int Value { get; set; }


            public Node()
            {

            }

            public Node(int val)
            {
                Value = val;
            }
        }

        protected Node Root { get; }

        public BinaryTree()
        {
            Root = null;
        }

        public BinaryTree(int val)
        {
            Root = new Node(val);
        }
    }
}
