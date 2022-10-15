/*
 
    Problem Description
        Given an array A. For every pair of indices i and j (i != j), find the maximum A[i] & A[j].
 
 
 
 */

using System;
using System.Collections.Generic;

namespace _022_MaxANDPair
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputA = new List<int> { 53, 39, 88 };
            Console.WriteLine(MaximumANDOfPair(inputA) == 37 ? "Passed" : "Failed");

            inputA = new List<int> { 38, 44, 84, 12 };
            Console.WriteLine(MaximumANDOfPair(inputA) == 36 ? "Passed" : "Failed");

            inputA = new List<int> { 13, 18, 23, 56, 81, 20, 4, 24, 93 };
            Console.WriteLine(MaximumANDOfPair(inputA) == 81 ? "Passed" : "Failed");

            inputA = new List<int> { 26, 13, 23, 28, 27, 7, 25 };
            Console.WriteLine(MaximumANDOfPair(inputA) == 26 ? "Passed" : "Failed");
        }

        public static int MaximumANDOfPair(List<int> A)
        {
            int ans = 0;
            int msbCount = 0;
            var msbZeros = new List<int>();
            for (int i = 31; i >= 0; i--)
            {
                if (msbCount >= 2)
                {
                    for (int j = 0; j < msbZeros.Count; j++)
                    {
                        A[msbZeros[j]] = 0;
                    }
                }
                msbCount = 0;
                msbZeros.Clear();
                for (int j = 0; j < A.Count; j++)
                {
                    if (((A[j] >> i) & 1) == 1)
                    {
                        msbCount++;
                    }
                    else 
                    {
                        msbZeros.Add(j);
                    }
                }
                if (msbCount >= 2)
                {
                    ans += Convert.ToInt32(Math.Pow(2, i));
                }

            }
            return ans;
        }

        public static int MaxAndPair(List<int> A)
        {
            List<int> v = new List<int>();
            for (int i = 0; i < A.Count; i++)
                v.Add(A[i]);
            for (int i = 29; i >= 0; i--)
            {
                // create a set of elements with the i-th bit set
                List<int> v2 = new List<int>();
                for (int j = 0; j < v.Count; j++)
                    if ((v[j] & (1 << i)) > 0)
                        v2.Add(v[j]);
                if (v2.Count >= 2)
                    v = v2;
            }
            return v[0] & v[1];
        }
    }
    }
}
