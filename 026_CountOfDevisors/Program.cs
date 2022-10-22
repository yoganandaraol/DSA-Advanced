using System;
using System.Collections.Generic;

namespace _026_CountOfDevisors
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputA = new List<int> { 8, 9, 10 };
            var output = Solve(inputA);

            foreach (var item in output)
            {
                Console.WriteLine(item);
            }
        }

        static List<int> Solve(List<int> A)
        {
            int max = -1;
            for (int i = 0; i < A.Count; i++)
            {
                max = Math.Max(A[i], max);
            }

            int[] factors = new int[max + 1];
            factors[1] = 1;
            for (int i = 2; i <= max; i++)
            {
                factors[i] = 2;
            }

            for (int i = 2; i <= max; i++)
            {
                for (int j = 2 * i; j <= max; j += i)
                {
                    factors[j] = factors[j] + 1;
                }
            }

            List<int> ans = new List<int>(A);
            for (int i = 0; i < A.Count; i++)
            {
                ans[i] = factors[A[i]];
            }

            return ans;
        }
    }
}
