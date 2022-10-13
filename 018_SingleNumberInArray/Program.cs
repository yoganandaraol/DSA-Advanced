/*
 *  Problem Description
        Given an array of integers A, every element appears twice except for one. Find that integer that occurs once.

        NOTE: Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?
  
    Output Format
        Return a single integer denoting the single element.


    Example Input
        Input:
            A = [1, 2, 2, 3, 1]
        Output:
            3

        Input:
            A = [1, 2, 2]
        Output:
            1
 */

using System;
using System.Collections.Generic;

namespace _018_SingleNumberInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputA = new List<int> { 1, 2, 3, 4, 5, 1, 2, 3, 4 };
            Console.WriteLine(SingleElementInArray(inputA) == 5 ? "Passed" : "Failed");
        }

        public static int SingleElementInArray(List<int> A)
        {
            var ans = 0;
            foreach (var item in A)
            {
                ans ^= item;            // A ^ A = 0 ==> XOR of all array elements results the element of single occurance.
            }

            return ans;
        }
    }
}
