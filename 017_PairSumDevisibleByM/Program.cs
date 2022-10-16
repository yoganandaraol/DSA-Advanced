/*
 
    Problem Description
        Given an array of integers A and an integer B, find and return the number of pairs in A whose sum is divisible by B.

        Since the answer may be large, return the answer modulo (109 + 7).



    Problem Constraints
        1 <= length of the array <= 100000
        1 <= A[i] <= 10^9
        1 <= B <= 10^6



    Input Format
        The first argument given is the integer array A.
        The second argument given is the integer B.



    Output Format
        Return the total number of pairs for which the sum is divisible by B modulo (109 + 7).



    Example Input
    Input 1:

        A = [1, 2, 3, 4, 5]
        B = 2

    Input 2:

        A = [5, 17, 100, 11]
        B = 28


    Example Output
    Output 1:
        4

    Output 2:
        1


    Example Explanation
    Explanation 1:

        All pairs which are divisible by 2 are (1,3), (1,5), (2,4), (3,5). 
        So total 4 pairs.
 
 
 
 */



using System;
using System.Collections.Generic;

namespace _017_PairSumDevisibleByM
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputA = new List<int> { 5, 17, 100, 11 };
            Console.WriteLine(PairSumDvisibleV4(inputA, 28) == 1 ? "Passed" : "Failed");

            inputA = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine(PairSumDvisibleV4(inputA, 2) == 4 ? "Passed" : "Failed");
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
        
        public static int PairSumDvisibleV4(List<int> A, int B)
        {
            int[] freqs = new int[B];

            for (int k = 0; k < A.Count; k++)
            {
                freqs[A[k] % B]++;
            }

            long ans = PairSum(freqs[0]);

            int i = 1;
            int j = B - 1;

            while (i < j)
            {
                ans += freqs[i] * freqs[j];
                i++;
                j--;
            }

            if ((B & 1) == 0)  // Checking even or not
            {
                ans += PairSum(freqs[B / 2]);
            }

            int mod = 1000000007;

            return (int)ans % mod;
        }

        static long PairSum(long digit)
        {
            return (digit * (digit - 1)) / 2;
        }
    }
}
