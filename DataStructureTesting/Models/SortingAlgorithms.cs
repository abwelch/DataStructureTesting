﻿using System;

namespace RunTimeAnalyzer.Models
{
    public class SortingAlgorithms
    {
        // Used to specifiy how elements should be generated
        public enum Options
        {
            ASCENDING,
            DESCENDING,
            RANDOM
        }

        private int[] array { get; }

        // Instantiates array with inputted size
        public SortingAlgorithms(int size, Options choice)
        {
            array = new int[size];
            switch (choice)
            {
                case Options.ASCENDING:
                    for (int i = 0; i < size; i++)
                    {
                        array[i] = i + 1;
                    }
                    break;
                case Options.DESCENDING:
                    for (int i = size - 1; i >= 0; i--)
                    {
                        array[i] = i + 1;
                    }
                    break;
                case Options.RANDOM:
                    var rand = new Random();
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = rand.Next(0, size + 1);
                    }
                    break;
            }
        }

        public void PrintArray()
        {
            Console.Write("{ ");
            for (int i = 0; i < array.Length - 1; i++)
            {
                Console.Write(array[i] + ", ");
            }
            Console.Write(array[array.Length - 1]);
            Console.WriteLine(" }");
        }

        // Time Complexity: O(n)
        public void InsertionSort()
        {
            // Outer loop traverses entire array, starting at second element
            for (int i = 1; i < array.Length; i++)
            {
                int current = array[i];
                int j = i - 1;
                // Move all elements in sorted portion of array greater than current forward by one
                while (j >= 0 && array[j] > current)
                {
                    // current is stored above bc this statement can erase current
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = current;
            }
        }

        public void BubbleSort()
        {

        }

        public void SelectionSort()
        {

        }

        public void MergeSort()
        {

        }

        public void QuickSort()
        {

        }
    }
}
