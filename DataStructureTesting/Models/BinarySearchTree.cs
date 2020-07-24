using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunTimeAnalyzer.Models
{
    // BST is a binary tree that satisfies the BST invariant: left subtree has smaller elements than the right subtree
    public class BinarySearchTree : BinaryTree
    {
        public BinarySearchTree() : base()
        { }

        public BinarySearchTree(int val) : base(val)
        { }

    }
}
