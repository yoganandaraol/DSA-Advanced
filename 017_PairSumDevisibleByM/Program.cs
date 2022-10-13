using System;
using System.Collections.Generic;

namespace _017_PairSumDevisibleByM
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputA = new List<int> { 5, 17, 100, 11 };
            Console.WriteLine(PairSumDvisibleV2(inputA, 28) == 1 ? "Passed" : "Failed");

            inputA = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine(PairSumDvisibleV2(inputA, 2) == 4 ? "Passed" : "Failed");
        }
        
        /*
            Bruteforce - 
        
                TC = O(N^2)
                SC = O(1)
         */
        public static int PairSumDvisible(List<int> A, int B)
        {
            int count = 0;
            for (int i = 0; i < A.Count; i++)
            {
                for (int j = i + 1; j < A.Count; j++)
                {
                    int sum = (A[i] % 1000000007 + A[j] % 1000000007) % 1000000007;
                    if (sum % B == 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }


        /*
            Efficient - 
        
                TC = O(N)
                SC = O(K)
         */
        public static int PairSumDvisibleV1(List<int> A, int B)
        {
            var freqs = new int[B];
            for (int i = 0; i < A.Count; i++)
            {
                freqs[A[i] % B]++;
            }

            int count = freqs[0] * (freqs[0] - 1) / 2;

            for (int i = 1; i <= B / 2 && i != (B - i); i++)
            {
                count += freqs[i] * freqs[B - i];
            }

            if (B % 2 == 0)
            {
                count += (freqs[B / 2] * (freqs[B / 2] - 1)) / 2;
            }
            return count;
        }


        // For count value too large
        public static int PairSumDvisibleV2(List<int> A, int B)
        {
            var freqs = new int[B];
            for (int i = 0; i < A.Count; i++)
            {
                freqs[A[i] % B]++;
            }

            int count = (freqs[0] * (freqs[0] - 1) / 2) % 1000000007;

            for (int i = 1; i <= B / 2 && i != (B - i); i++)
            {
                count = (count % 1000000007 + ((freqs[i] * freqs[B - i]) % 1000000007)) % 1000000007;
            }

            if (B % 2 == 0)
            {
                count = (count % 1000000007 + ((freqs[B / 2] * (freqs[B / 2] - 1)/2) % 1000000007)) % 1000000007;
            }
            return count % 1000000007;
        }
    }
}
