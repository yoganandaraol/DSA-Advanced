/*
 
    Problem Description
        Given a matrix of integers A of size N x M and multiple queries Q, for each query, find and return the submatrix sum.

        Inputs to queries are top left (b, c) and bottom right (d, e) indexes of submatrix whose sum is to find out.

        NOTE:
            Rows are numbered from top to bottom, and columns are numbered from left to right.
            Sum may be large, so return the answer mod 10^9 + 7.


    Problem Constraints
        1 <= N, M <= 1000
        -100000 <= A[i] <= 100000
        1 <= Q <= 100000
        1 <= B[i] <= D[i] <= N
        1 <= C[i] <= E[i] <= M

    Input Format
        The first argument given is the integer matrix A.
        The second argument given is the integer array B.
        The third argument given is the integer array C.
        The fourth argument given is the integer array D.
        The fifth argument given is the integer array E.
        (B[i], C[i]) represents the top left corner of the i'th query.
        (D[i], E[i]) represents the bottom right corner of the i'th query.

    Output Format
        Return an integer array containing the submatrix sum for each query.

    Example Input
        Input 1:

             A = [   [1, 2, 3]
                     [4, 5, 6]
                     [7, 8, 9]   ]
             B = [1, 2]
             C = [1, 2]
             D = [2, 3]
             E = [2, 3]

        Input 2:

             A = [   [5, 17, 100, 11]
                     [0, 0,  2,   8]    ]
             B = [1, 1]
             C = [1, 4]
             D = [2, 2]
             E = [2, 4]


        Example Output
            Output 1:
                [12, 28]

            Explanation:
                 For query 1: Submatrix contains elements: 1, 2, 4 and 5. So, their sum is 12.
                 For query 2: Submatrix contains elements: 5, 6, 8 and 9. So, their sum is 28.


            Output 2:
                [22, 19]

            Explanation:
                 For query 1: Submatrix contains elements: 5, 17, 0 and 0. So, their sum is 22.
                 For query 2: Submatrix contains elements: 11 and 8. So, their sum is 19.
 
 
 */



using System;
using System.Collections.Generic;
using System.Linq;

namespace _010_SubMatrixSumQueries
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

            var inputB = new List<int>() { 1, 2 };
            var inputC = new List<int>() { 1, 2 };
            var inputD = new List<int>() { 2, 3 };
            var inputE = new List<int>() { 2, 3 };
            var output = new List<int>() { 12, 28 };

            Console.WriteLine(Enumerable.SequenceEqual(SubMatrixSumQueries(inputA, inputB, inputC, inputD, inputE), output) ? "Passed" : "Failed");

            inputA = new List<List<int>>() {
                new List<int>{ 5, 17, 100, 11 },
                new List<int>{ 0, 0, 2, 8 },
            };

            inputB = new List<int>() { 1, 1 };
            inputC = new List<int>() { 1, 4 };
            inputD = new List<int>() { 2, 2 };
            inputE = new List<int>() { 2, 4 };
            output = new List<int>() { 22, 19 };

            Console.WriteLine(Enumerable.SequenceEqual(SubMatrixSumQueries(inputA, inputB, inputC, inputD, inputE), output) ? "Passed" : "Failed");
        }

        public static List<int> SubMatrixSumQueries(List<List<int>> A, List<int> B, List<int> C, List<int> D, List<int> E)
        {
            var p = new List<List<int>>(A);
            var ans = new List<int>();

            // TC of prefix sum O(N x M)
            // SC of prefix sum O(N x M) -- using seperate memory p here.
            for (int i = 0; i < A.Count; i++)
            {
                for (int j = 0; j < A[i].Count; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        p[i][j] = A[i][j];
                    }
                    else if (i == 0)
                    {
                        p[i][j] = p[i][j - 1] + A[i][j];
                    }
                    else if (j == 0)
                    {
                        p[i][j] = p[i - 1][j] + A[i][j];
                    }
                    else
                    {
                        p[i][j] = p[i - 1][j] + p[i][j - 1] - p[i - 1][j - 1] + A[i][j];
                    }
                    p[i][j] = ((p[i][j] % 1000000007 + 1000000007) % 1000000007); // handling modulus for too large numbers
                }
            }

            int result;
            for (int q = 0; q < B.Count; q++)
            {
                int sx = B[q] - 1;
                int sy = C[q] - 1;
                int ex = D[q] - 1;
                int ey = E[q] - 1;

                if (sx == 0 && sy == 0)
                {
                    result = p[ex][ey];
                }
                else if (sx == 0)
                {
                    result = p[ex][ey] - p[ex][sy - 1];
                }
                else if (sy == 0)
                {
                    result = p[ex][ey] - p[sx - 1][ey];
                }
                else
                {
                    result = p[ex][ey] - p[ex][sy - 1] - p[sx - 1][ey] + p[sx - 1][sy - 1];
                }

                ans.Add((result % 1000000007 + 1000000007) % 1000000007); // handling modulus for too large numbers

            }

            return ans;
        }
    }
}
