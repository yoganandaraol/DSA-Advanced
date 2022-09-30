/*
 *  Problem Description
        Given a non-negative number represented as an array of digits, add 1 to the number ( increment the number represented by the digits ).

        The digits are stored such that the most significant digit is at the head of the list.

        NOTE: Certain things are intentionally left unclear in this question which you should practice asking the interviewer. For example: for this problem, the following are some good questions to ask :
            Q: Can the input have 0's before the most significant digit. Or, in other words, is 0 1 2 3 a valid input?
            A: For the purpose of this question, YES
            Q: Can the output have 0's before the most significant digit? Or, in other words, is 0 1 2 4 a valid output?
            A: For the purpose of this question, NO. Even if the input has zeroes before the most significant digit.
 * 
 *  Problem Constraints
        1 <= size of the array <= 1000000

    Input Format
        First argument is an array of digits.

    Output Format
        Return the array of digits after adding one.

    Example Input
        Input 1:
            [1, 2, 3]

    Example Output
        Output 1:
            [1, 2, 4]

    Example Explanation
        Explanation 1:
            Given vector is [1, 2, 3].
            The returned vector should be [1, 2, 4] as 123 + 1 = 124.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace _004_AddOne
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputA = new List<int> { 0, 0, 1, 2, 3 };
            List<int> output = new List<int> { 1, 2, 4 };
            Console.WriteLine(Enumerable.SequenceEqual(PlusOne(inputA), output) ? "Passed" : "Failed");

            inputA = new List<int> { 0, 0, 9, 9, 9 };
            output = new List<int> { 1, 0, 0, 0 };
            Console.WriteLine(Enumerable.SequenceEqual(PlusOne(inputA), output) ? "Passed" : "Failed");

            inputA = new List<int> { 9, 9, 9 };
            output = new List<int> { 1, 0, 0, 0 };
            Console.WriteLine(Enumerable.SequenceEqual(PlusOne(inputA), output) ? "Passed" : "Failed");
        }

        private static List<int> PlusOne(List<int> A)
        {
            List<int> result = new List<int>();
            int carry = 1;
            int trailing0Index = -1;
            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] > 0)
                    break;
                else
                    trailing0Index = i;
            }
            for (int i = A.Count - 1; i >= 0; i--)
            {
                int res = A[i] + carry;
                if (i >= trailing0Index)
                {
                    if (res > 0)
                    {
                        if (res >= 10)
                        {
                            res = 0;
                            carry = 1;
                        }
                        else
                            carry = 0;

                        result.Add(res);
                    }
                    else if (i > trailing0Index)
                        result.Add(A[i]);
                }
            }

            if (carry == 1)
                result.Add(1);

            result.Reverse();
            return result;
        }
    }
}
