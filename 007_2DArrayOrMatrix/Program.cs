/*
 * Q -  Given a matrix of integers A[N][M]
 *      Find the sum of given submatrix
 * 
 * 
 * 
*/

using System;
using System.Collections.Generic;

namespace _007_2DArrayOrMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private static int SumOfSubMatrix(List<List<int>> A, int sx, int sy, int ex, int ey)
        {
            int ans = 0;
            for (int i = sx; i < ex; i++)
            {
                for (int j = sy; j < ey; j++)
                {
                    ans += A[i][j];
                }
            }
            return ans;
        }
    }
}
