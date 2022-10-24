/*
 
    Problem Description
        Given a number A, we need to find the sum of its digits using recursion.

    Problem Constraints
        1 <= A <= 109

    Input Format
        The first and only argument is an integer A.

    Output Format
        Return an integer denoting the sum of digits of the number A.

    Example Input
        Input 1:
            A = 46

        Input 2:
            A = 11

    Example Output
        Output 1:
            10

        Output 2:
            2

    Example Explanation
        Explanation 1:
            Sum of digits of 46 = 4 + 6 = 10

        Explanation 2:
            Sum of digits of 11 = 1 + 1 = 2
 
 
 
 */


using System;

namespace _031_SumOfDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SumOfDigits(21234) == 12 ? "Passed" : "Failed");
            Console.WriteLine(SumOfDigits(46) == 10 ? "Passed" : "Failed");
            Console.WriteLine(SumOfDigits(11) == 2 ? "Passed" : "Failed");
            Console.WriteLine(SumOfDigits(100000000) == 1 ? "Passed" : "Failed");
        }

        static int SumOfDigits(int A)
        {
            if (A < 10)
            {
                return A;
            }

            return SumOfDigits(A / 10) + SumOfDigits(A % 10);
        }
    }
}
