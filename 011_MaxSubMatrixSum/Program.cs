/*
 
    Problem Description
        Given a row-wise and column-wise sorted matrix A of size N * M.
        Return the maximum non-empty submatrix sum of this matrix.


    Problem Constraints
        1 <= N, M <= 1000
        -10^9 <= A[i][j] <= 10^9


    Input Format
        The first argument is a 2D integer array A.


    Output Format
        Return a single integer that is the maximum non-empty submatrix sum of this matrix.


    Example Input
        Input 1:-
                -5 -4 -3
            A = -1  2  3
                 2  2  4
        
        Output 1:-
            12
        
        Expanation 1:-
            The submatrix with max sum is 
            -1 2 3
             2 2 4
             Sum is 12.

        Input 2:-
                1 2 3
            A = 4 5 6
                7 8 9
        
        Output 2:-
            45

        Explanation 2:-
            The largest submatrix with max sum is 
            1 2 3
            4 5 6
            7 8 9
            The sum is 45.
 
 */

using System;
using System.Collections.Generic;

namespace _011_MaxSubMatrixSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputA = new List<List<int>>() {
                new List<int>{ 1, 2, 3 },
                new List<int>{ 4, 5, 6 },
                new List<int>{ 7, 8, 9 }
            };

            Console.WriteLine(MaximumSubMatrixSum(inputA) == 45 ? "Passed" : "Failed");

            inputA = new List<List<int>>() {
                new List<int>{ -5, -4, -3 },
                new List<int>{ -1,  2,  3 },
                new List<int>{  2,  2,  4 }
            };

            Console.WriteLine(MaximumSubMatrixSum(inputA) == 12 ? "Passed" : "Failed");
        }

        public static long MaximumSubMatrixSum(List<List<int>> A)
        {
            long result = long.MinValue;
            var p = new long[A.Count, A[0].Count];

            for (int i = 0; i < A.Count; i++)
            {
                for (int j = 0; j < A[i].Count; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        p[i, j] = A[i][j];
                    }
                    else if (i == 0)
                    {
                        p[i, j] = p[i, j - 1] + A[i][j];
                    }
                    else if (j == 0)
                    {
                        p[i, j] = p[i - 1, j] + A[i][j];
                    }
                    else
                    {
                        p[i, j] = p[i - 1, j] + p[i, j - 1] - p[i - 1, j - 1] + A[i][j];
                    }

                }
            }

            for (int i = 0; i < A.Count; i++)
            {
                for (int j = 0; j < A[i].Count; j++)
                {
                    int sx = i;
                    int sy = j;
                    int ex = A.Count - 1;
                    int ey = A[i].Count - 1;
                    long sum;
                    if (sx == 0 && sy == 0)
                    {
                        sum = p[ex, ey];
                    }
                    else if (sx == 0)
                    {
                        sum = p[ex, ey] - p[ex, sy - 1];
                    }
                    else if (sy == 0)
                    {
                        sum = p[ex, ey] - p[sx - 1, ey];
                    }
                    else
                    {
                        sum = p[ex, ey] - p[ex, sy - 1] - p[sx - 1, ey] + p[sx - 1, sy - 1];
                    }

                    result = Math.Max(result, sum);
                }
            }

            return result;
        }
    }
}
