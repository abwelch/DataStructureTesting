using System.Collections.Generic;

namespace RunTimeAnalyzer.ViewModels
{
    public static class InteractiveOptions
    {
        public static List<string> Options { get; }
        static InteractiveOptions()
        {
            Options = new List<string>
            {
                "Singly Linked List",
                "Doubly Linked List",
                "Stack",
                "Queue",
                "Circular Queue",
                "Binary Tree",
                "Binary Search Tree"
            };
        }
    }
}
