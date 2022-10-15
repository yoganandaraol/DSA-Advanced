/*
    Problem Description
        Given an array of positive integers A, two integers appear only once, and all the other integers appear twice.
        Find the two integers that appear only once.

        Note: Return the two numbers in ascending order.


    Problem Constraints
        2 <= |A| <= 100000
        1 <= A[i] <= 10^9

    Input Format
        The first argument is an array of integers of size N.

    Output Format
        Return an array of two integers that appear only once.



    Example Input
        Input 1:
            A = [1, 2, 3, 1, 2, 4]
    
        Input 2:
            A = [1, 2]


    Example Output
        Output 1:
            [3, 4]

        Output 2:
            [1, 2]

 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace _021_SingleNumberIII
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputA = new List<int> { 1, 2, 3, 1, 2, 4 };
            List<int> output = new List<int> { 3, 4 };
            Console.WriteLine(Enumerable.SequenceEqual(SingleOccuranceElements(inputA), output) ? "Passed" : "Failed");

            inputA = new List<int> { 1, 2, 3, 1 };
            output = new List<int> { 2, 3 };
            Console.WriteLine(Enumerable.SequenceEqual(SingleOccuranceElements(inputA), output) ? "Passed" : "Failed");
        }

        public static List<int> SingleOccuranceElements(List<int> A)
        {
            var ans = new List<int>();
            var xor = 0;
            for (int i = 0; i < A.Count; i++)
            {
                xor ^= A[i];
            }

            int setBitPos = -1;
            for (int i = 0; i < 31; i++)
            {
                if (((xor >> i) & 1) == 1)
                {
                    setBitPos = i;
                    break;
                }
            }

            var xor1 = 0;
            var xor0 = 0;
            for (int i = 0; i < A.Count; i++)
            {
                if (((A[i] >> setBitPos) & 1) == 1)
                {
                    xor1 ^= A[i];
                }
                else
                {
                    xor0 ^= A[i];
                }
            }

            ans.Add(Math.Min(xor1, xor0));
            ans.Add(Math.Max(xor1, xor0));
            return ans;
        }
    }
}
