/*
 * Problem Description
 *       There are A beggars sitting in a row outside a temple. 
 *       Each beggar initially has an empty pot. 
 *       
 *       When the devotees come to the temple, they donate some amount of coins to these beggars. 
 *       Each devotee gives a fixed amount of coin(according to their faith and ability) to some K beggars sitting next to each other.
 *
 *       Given the amount P donated by each devotee to the beggars ranging from L to R index, 
 *       where 1 <= L <= R <= A, find out the final amount of money in each beggar's pot at the end of the day, provided they don't fill their pots by any other means.
 *       
 *       For ith devotee B[i][0] = L, B[i][1] = R, B[i][2] = P, 
 *       Given by the 2D array B
 *       
 *  Output Format
 *  -------------
    Return an array(0 based indexing) that stores the total number of coins in each beggars pot.


    Example Input
        Input 1:-
            A = 5
            B = [[1, 2, 10], [2, 3, 20], [2, 5, 25]]


    Example Output
        Output 1:-
            10 55 45 25 25


    Example Explanation
        Explanation 1:-
            First devotee donated 10 coins to beggars ranging from 1 to 2. Final amount in each beggars pot after first devotee: [10, 10, 0, 0, 0]
            Second devotee donated 20 coins to beggars ranging from 2 to 3. Final amount in each beggars pot after second devotee: [10, 30, 20, 0, 0]
            Third devotee donated 25 coins to beggars ranging from 2 to 5. Final amount in each beggars pot after third devotee: [10, 55, 45, 25, 25]
 * 
 *
 *
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace _003_ContinuousSumQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputA = 5;
            List<List<int>> inputB = new List<List<int>>{
                new List<int> { 1, 2, 10 },
                new List<int> { 2, 3, 20 },
                new List<int> { 2, 5, 25 }
            };
            List<int> output = new List<int> { 10, 55, 45, 25, 25 };

            Console.WriteLine(Enumerable.SequenceEqual(ContinuousSum(inputA, inputB), output) ? "Passed" : "Failed");
        }

        static List<int> ContinuousSum(int A, List<List<int>> B)
        {
            var result = new List<int>();
            for (int i = 0; i < A; i++)
            {
                result.Add(0);
            }
            foreach (var bItems in B)
            {
                int start = bItems[0] - 1;
                int end = bItems[1] - 1;
                int val = bItems[2];

                result[start] += val;
                if (end < A - 1)
                {
                    result[end + 1] -= val;
                }
            }

            for (int i = 1; i < result.Count; i++)
            {
                result[i] += result[i - 1];
            }

            return result;
        }
    }
}
