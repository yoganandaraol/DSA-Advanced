using System;
using System.Collections.Generic;

namespace _008_SumOfAllSubMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputA = new List<List<int>>
            {
                new List<int> { 1, 1 },
                new List<int> { 1, 1 }
            };

            Console.WriteLine(SumOfAllSubMatrix(inputA) == 16 ? "Passed" : "Failed");
        }

        public static int SumOfAllSubMatrix(List<List<int>> A)
        {
            int N = A.Count;
            int res = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    int elementContribution = A[i][j] * (i + 1) * (j + 1) * (N - i) * (N - j);
                    res += elementContribution;
                }
            }
            return res;
        }
    }
}
