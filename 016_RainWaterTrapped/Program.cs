/*
 
    Problem Description
        Given a vector A of non-negative integers representing an elevation map where the width of each bar is 1, 
        compute how much water it is able to trap after raining.

    Problem Constraints
        1 <= |A| <= 100000

    Input Format
        First and only argument is the vector A

    Output Format
        Return one integer, the answer to the question

    Example Input

        Input 1:
            A = [0, 1, 0, 2]
        Output:
            1
        Explanation:
            1 unit is trapped on top of the 3rd element.


        Input 2:
            A = [1, 2]
        Output:
            0
        Explanation:
            No water is trapped.
 
 */

using System;
using System.Collections.Generic;

namespace _016_RainWaterTrapped
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputA = new List<int> { 6, 4, 3, 5, 1, 7, 3, 5 };
            Console.WriteLine(RainWaterTrap(inputA) == 13 ? "Passed" : "Failed");
        }

        public static int RainWaterTrap(List<int> A)
        {
            int ans = 0;
            var maxR = new List<int>(A);
            var maxL = new List<int>(A);
            for (int i = 0; i < A.Count; i++)
            {
                if (i == 0 || i == A.Count - 1)
                    continue;

                maxR[A.Count - 1 - i] = Math.Max(A[A.Count - 1 - i], maxR[A.Count - i]);
                maxL[i] = Math.Max(A[i], maxL[i-1]);
            }

            for (int i = 0; i < A.Count; i++)
            {
                ans += Math.Min(maxR[i], maxL[i]) - A[i];
            }
            return ans;
        }
    }
}
