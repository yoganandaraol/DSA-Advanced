/*
 
    Problem Description
        You are given a binary string A(i.e., with characters 0 and 1) consisting of characters A1, A2, ..., AN. 
        In a single operation, you can choose two indices, L and R, such that 1 ≤ L ≤ R ≤ N and flip the characters AL, AL+1, ..., AR. 
        By flipping, we mean changing character 0 to 1 and vice-versa.

        Your aim is to perform ATMOST one operation such that in the final string number of 1s is maximized.

        If you don't want to perform the operation, return an empty array. Else, return an array consisting of two elements denoting L and R. 
        If there are multiple solutions, return the lexicographically smallest pair of L and R.

        NOTE: Pair (a, b) is lexicographically smaller than pair (c, d) if a < c or, if a == c and b < d.



    Problem Constraints
        1 <= size of string <= 100000

    Input Format
        First and only argument is a string A.

    Output Format
        Return an array of integers denoting the answer.

    Examples:

        Input 1:
            A = "010"

        Output 1:
            [1, 1]

        Input 2:
            A = "111"

        Output 2:
            []


    Example Explanation
        Explanation 1:
            A = "010"

            Pair of [L, R] | Final string
            _______________|_____________
            [1 1]          | "110"
            [1 2]          | "100"
            [1 3]          | "101"
            [2 2]          | "000"
            [2 3]          | "001"

            We see that two pairs [1, 1] and [1, 3] give same number of 1s in final string. So, we return [1, 1].
    

        Explanation 2:
            No operation can give us more than three 1s in final string. So, we return empty array [].
 
 
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace _005_FlipForMaxNoOfOnesInBinaryString
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> output = new List<int> { 1, 1 };
            Console.WriteLine(Enumerable.SequenceEqual(ConsecutiveZeroFlipForMaxOnes("010"), output) ? "Passed" : "Failed");

            output = new List<int>();
            Console.WriteLine(Enumerable.SequenceEqual(ConsecutiveZeroFlipForMaxOnes("111111111111111111111"), output) ? "Passed" : "Failed");

            output = new List<int> { 4, 4};
            Console.WriteLine(Enumerable.SequenceEqual(ConsecutiveZeroFlipForMaxOnes("1110"), output) ? "Passed" : "Failed");

            output = new List<int> { 9, 12 };
            Console.WriteLine(Enumerable.SequenceEqual(ConsecutiveZeroFlipForMaxOnes("10101011000011"), output) ? "Passed" : "Failed");

            output = new List<int> { 9, 12 };
            Console.WriteLine(Enumerable.SequenceEqual(ConsecutiveZeroFlipForMaxOnes("101010110000110000"), output) ? "Passed" : "Failed");

            output = new List<int> { 15, 19 };
            Console.WriteLine(Enumerable.SequenceEqual(ConsecutiveZeroFlipForMaxOnes("10101011000011000001"), output) ? "Passed" : "Failed");

            output = new List<int> { 15, 19 };
            Console.WriteLine(Enumerable.SequenceEqual(ConsecutiveZeroFlipForMaxOnes("1010101100001100000"), output) ? "Passed" : "Failed");

            //Failing
            output = new List<int> { 3, 9 };
            Console.WriteLine(Enumerable.SequenceEqual(FlipForMaxOnes("1101010001"), output) ? "Passed" : "Failed");

            output = new List<int> { 1, 1 };
            Console.WriteLine(Enumerable.SequenceEqual(FlipForMaxOnes("010"), output) ? "Passed" : "Failed");

            output = new List<int>();
            Console.WriteLine(Enumerable.SequenceEqual(FlipForMaxOnes("111111111111111111111"), output) ? "Passed" : "Failed");

            output = new List<int> { 4, 4 };
            Console.WriteLine(Enumerable.SequenceEqual(FlipForMaxOnes("1110"), output) ? "Passed" : "Failed");


            Console.WriteLine("---------");
            output = new List<int> { 3, 9 };
            Console.WriteLine(Enumerable.SequenceEqual(Flip("1101010001"), output) ? "Passed" : "Failed");

            output = new List<int> { 1, 1 };
            Console.WriteLine(Enumerable.SequenceEqual(Flip("010"), output) ? "Passed" : "Failed");

            output = new List<int>();
            Console.WriteLine(Enumerable.SequenceEqual(Flip("111111111111111111111"), output) ? "Passed" : "Failed");

            output = new List<int> { 4, 4 };
            Console.WriteLine(Enumerable.SequenceEqual(Flip("1110"), output) ? "Passed" : "Failed");
        }

        public static List<int> ConsecutiveZeroFlipForMaxOnes(string A)
        {
            var result = new List<int>();
            int max = 0;
            int start = 0;
            int currentStart = 0;
            int count = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == '0')
                {
                    if (count == 0)
                        currentStart = i;

                    count++;

                    if (max < count)
                    {
                        start = currentStart;
                        max = count;
                    }
                }
                else
                    count = 0;
            }

            if (max >= 1)
            {
                result.Add(start + 1);
                result.Add(start + max);
            }

            return result;
        }

        // Incomplete
        public static List<int> FlipForMaxOnes(string A)
        {
            var result = new List<int>();
            var onesSum = new List<int>();
            var zeroSum = new List<int>();

            int count0 = 0;
            int count1 = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == '0')
                    count0++;
                else
                    count1++;

                onesSum.Add(count1);
                zeroSum.Add(count0);
            }

            for (int i = 0; i < A.Length; i++)
            {
                if (i+1 == onesSum[i] + zeroSum[i] & A[i] == '0')
                {
                    if (result.Count == 0)
                    {
                        result.Add(i + 1);
                        result.Add(i + 1);
                    }
                    else
                        result[1] = i + 1;
                }
            }

            return result;
        }

        // Final Solution
        // Using Kadane's algorithm
        public static List<int> Flip(string A)
        {
            List<int> temp = new List<int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == '1')
                    temp.Add(-1);
                if (A[i] == '0')
                    temp.Add(1);
            }

            int currSum = 0;
            int maxSum = 0;
            int start = 0, end = -1;
            int index = 0;
            for (int i = 0; i < A.Length; i++)
            {
                currSum += temp[i];
                if (currSum < 0)
                {
                    currSum = 0;
                    index = i + 1;
                }
                else if (currSum > maxSum)
                {
                    maxSum = currSum;
                    start = index;
                    end = i;
                }
            }
            temp.Clear();
            if (end != -1)
            {
                temp.Add(start + 1);
                temp.Add(end + 1);
                return temp;
            }
            return temp;
        }
    }
}
