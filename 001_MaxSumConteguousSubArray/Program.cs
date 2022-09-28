using System;
using System.Collections.Generic;

namespace _001_MaxSumConteguousSubArray
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputA = new List<int> {-1000, -1000, -1000, -1000, -1000, -1000, -1000, -1000, -1000 };
            Console.WriteLine(MaxSubArr(inputA) == -1000 ? "Passed":"Failed");

            inputA = new List<int> { -1000, -1000, -1000, -1000, -1000, -1000, -1000, -1000, -10 };
            Console.WriteLine(MaxSubArr(inputA) == -10 ? "Passed" : "Failed");
        }

        // Bruteforce
        // TC - O(N^2)
        // SC - O(1)
        public static int MaxSubArray(List<int> A)
        {
            int max = int.MinValue;

            for (int i = 0; i < A.Count; i++)
            {
                int sumSubArray = 0;
                for (int j = i; j < A.Count; j++)
                {
                    sumSubArray += A[j];
                    max = Math.Max(sumSubArray, max);
                }
            }

            return max;
        }

        // Better Approach
        // TC - O(N)
        // SC - O(1)
        public static int MaxSubArr(List<int> A)
        {
            int max = int.MinValue;
            int sum = 0;
            for (int i = 0; i < A.Count; i++)
            {
                sum += A[i];
                max = Math.Max(max, sum);
                if (sum < 0)
                    sum = 0;
            }
            return max;
        }

    }
}
