/*
 
    Problem Description
        Given 4 array of integers A, B, C and D of same size, 
        find and return the maximum value of 
            | A [ i ] - A [ j ] | + | B [ i ] - B [ j ] | + | C [ i ] - C [ j ] | + | D [ i ] - D [ j ] | + | i - j| 
        where i != j and |x| denotes the absolute value of x.

    Problem Constraints
        2 <= length of the array A, B, C, D <= 100000
        -10^6 <= A[i] <= 10^6

    Input Format
        The arguments given are the integer arrays A, B, C, D.

    Output Format
        Return the maximum value of | A [ i ] - A [ j ] | + | B [ i ] - B [ j ] | + | C [ i ] - C [ j ] | + | D [ i ] - D [ j ] | + | i - j|


    Example Input
        Input 1:
             A = [1, 2, 3, 4]
             B = [-1, 4, 5, 6]
             C = [-10, 5, 3, -8]
             D = [-1, -9, -6, -10]

        Input 2:
             A = [1, 2]
             B = [3, 6]
             C = [10, 11]
             D = [1, 6]


    Example Output
        Output 1:
            30
        
        Output 2:
            11


    Example Explanation

    Explanation 1:
        Maximum value occurs for i = 0 and j = 1.

    Explanation 2:
        There is only one possibility for i, j as there are only two elements in the array.
 
 
 */

using System;
using System.Collections.Generic;

namespace _006_AbsoluteMaximum
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputA = new List<int> { 1, 2, 3, 4 };
            List<int> inputB = new List<int> { -1, 4, 5, 6 };
            List<int> inputC = new List<int> { -10, 5, 3, -8 };
            List<int> inputD = new List<int> { -1, -9, -6, -10 };
            Console.WriteLine(AbsMaximumV1(inputA, inputB, inputC, inputD) == 30 ? "Passed" : "Failed");
        }

        /*
         *  Q - if f(i, j) = | A [ i ] - A [ j ] | + | B [ i ] - B [ j ] | + | C [ i ] - C [ j ] | + | D [ i ] - D [ j ] | + | i - j|
         *      then what is Max(f(i, j) ?
         *      
         *      f(i, j) = | A [ i ] - A [ j ] | + | B [ i ] - B [ j ] | + | C [ i ] - C [ j ] | + | D [ i ] - D [ j ] | + | i - j|
         *              = 
         * 
         * 
         */
        public static int AbsMaximum(List<int> A, List<int> B, List<int> C, List<int> D)
        {
            int res = int.MinValue;
            int min1 = int.MaxValue, min2 = int.MaxValue;
            int max1 = int.MinValue, max2 = int.MinValue;

            for (int i = 0; i < A.Count; i++)
            {
                int currentSum = A[i] + B[i] + C[i] + D[i];

                max1 = Math.Max(currentSum + i, max1);
                min1 = Math.Min(currentSum + i, min1);
                max2 = Math.Max(currentSum - i, max2);
                min2 = Math.Min(currentSum - i, min2);

                res = Math.Max(max1 - min1, max2 - min2);
            }
            return res;
        }

        // Work on the solution
        public static int AbsMaximumV1(List<int> A, List<int> B, List<int> C, List<int> D)
        {
            int res = int.MinValue;
            for (int i = 0; i < 16; i++)
            {
                int max = int.MinValue;
                int min = int.MaxValue;
                for (int j = 0; j < A.Count; j++)
                {
                    int sum = A[j];
                    for (int m = 0; m < 4; m++)
                    {
                        int tmp;
                        if (m == 0)
                            tmp = B[j];
                        else if (m == 1)
                            tmp = C[j];
                        else if (m == 2)
                            tmp = D[j];
                        else
                            tmp = j;

                        if ((i & (1 << m)) != 0)
                            sum += tmp;
                        else
                            sum -= tmp;
                    }
                    max = Math.Max(max, sum);
                    min = Math.Min(min, sum);
                }
                res = Math.Max(res, Math.Abs(max - min));
            }
            return res;
        }

    }
}
