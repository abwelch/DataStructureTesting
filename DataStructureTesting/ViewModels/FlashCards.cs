﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunTimeAnalyzer.ViewModels
{
    public static class FlashCards
    {
        public static List<Tuple<string, string>> Cards { get; }

        static FlashCards()
        {
            Cards = new List<Tuple<string, string>>
            {
                #region [Singly Linked List]
                new Tuple<string, string>("Singly Linked List: Search", "Time Complexity: O(n). Explanation: Starting at the head node, there is potential for the entire list to be traversed."),
                new Tuple<string, string>("Singly Linked List: Append", "Time Complexity: O(1). Explanation: Because a Tail property was implemented and maintained, this operation can occur in consant time. However, if a Tail is not implemented, this operation is O(n) time."),
                new Tuple<string, string>("Singly Linked List: Insert", "Time Complexity: O(n). Explanation: Even with Tail, going to second to last node in singly list can lead to n time with n is exceptionally large."),
                new Tuple<string, string>("Singly Linked List: Remove", "Time Complexity: O(n). Explanation: Even with Tail, going to second to last node in singly list can lead to n time with n is exceptionally large."),
                new Tuple<string, string>("Singly Linked List: Insert at Head", "Time Complexity: O(1). Explanation: Because we have a reference to Head, this operation is constant."),
                new Tuple<string, string>("Singly Linked List: Remove at Head", "Time Complexity: O(1). Explanation: Because we have a reference to Head, this operation is constant."),
                new Tuple<string, string>("Singly Linked List: Reverse", "Time Complexity: O(n). Explanation: This requires traversing the entire list to change the references at each node."),
                #endregion

                #region [Stack]
                new Tuple<string, string>("Stack: Push", "Time Complexity: O(1). Explanation: Our implementation of stack utilizes a singly linked list. Push occurs at the top of the stack (head of list) and is therefore constant time."),
                new Tuple<string, string>("Stack: Pop", "Time Complexity: O(1). Explanation: Our implementation of stack utilizes a singly linked list. Pop occurs at the top of the stack (head of list) and is therefore constant time."),
                #endregion
            };
        }

    }
}
