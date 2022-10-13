/*
 * 
 *	Problem Description
		Given an array of integers, every element appears thrice except for one, which occurs once.

		Find that element that does not appear thrice.

		NOTE: Your algorithm should have a linear runtime complexity.

		Could you implement it without using extra memory?


	Problem Constraints
		2 <= A <= 5*10^6
		0 <= A <= INTMAX

	Input Format
		First and only argument of input contains an integer array A.

	Output Format
		Return a single integer.


	Example Input
		Input 1:
			A = [1, 2, 4, 3, 3, 2, 2, 3, 1, 1]
		Output 1:
			4
	
	
		Input 2:
			A = [0, 0, 0, 1]
		Output 2:
			1

 
 * */

using System;
using System.Collections.Generic;

namespace _019_SingleOccuranceElementInAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
			var inputA = new List<int> { 1, 2, 3, 4, 5, 1, 2, 3, 4, 1, 2, 3, 4 };
			Console.WriteLine(SingleOccurranceElement(inputA) == 5 ? "Passed" : "Failed");

			inputA = new List<int> { 1, 2, 4, 3, 3, 2, 2, 3, 1, 1 };
			Console.WriteLine(SingleOccurranceElement(inputA) == 4 ? "Passed" : "Failed");

			inputA = new List<int> { 0, 0, 0, 1 };
			Console.WriteLine(SingleOccurranceElement(inputA) == 1 ? "Passed" : "Failed");
		}


		public static int SingleOccurranceElement(List<int> A)
		{
			var ans = 0;

            for (int i = 0; i < 31; i++)
            {
				int count = 0;
                for (int j = 0; j < A.Count; j++)
                {
					count += (A[j] >> i) & 1;		// returns 1 if LSB is 1 after shifting i times right side
                }
				count %= 3;
				ans += count * Convert.ToInt32(Math.Pow(2, i));
            }

			return ans;
		}

    }
}
