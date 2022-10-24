﻿/*
 
    Problem Description
        Given a number A, check if it is a magic number or not.

        A number is said to be a magic number if the sum of its digits is calculated till a single digit recursively by adding the sum of the digits after every addition. 
        If the single digit comes out to be 1, then the number is a magic number.

    Problem Constraints
        1 <= A <= 109

    Input Format
        The first and only argument is an integer A.

    Output Format
        Return an 1 if the given number is magic else return 0.

    Example Input
        Input 1:
            A = 83557
        Input 2:
            A = 1291


    Example Output
        Output 1:
            1
        Output 2:
            0


    Example Explanation
        Explanation 1:
            Sum of digits of (83557) = 28
            Sum of digits of (28) = 10
            Sum of digits of (10) = 1. 
            Single digit is 1, so it's a magic number. Return 1.

        Explanation 2:
            Sum of digits of (1291) = 13
            Sum of digits of (13) = 4
            Single digit is not 1, so it's not a magic number. Return 0.
 
 */

using System;

namespace _032_IsMagicNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsMagicNumber(83557) == 1 ? "Passed" : "Failed");
            Console.WriteLine(IsMagicNumber(1291) == 0 ? "Passed" : "Failed");
            Console.WriteLine(IsMagicNumber(111111112) == 1 ? "Passed" : "Failed");
        }

        private static int IsMagicNumber(int A)
        {
            int sum = A;

            while (sum > 9)
            {
                sum = SumOfDigits(sum);
            }

            return sum == 1 ? 1 : 0;
        }

        private static int SumOfDigits(int A)
        {
            if (A < 10)
            {
                return A;
            }

            return SumOfDigits(A / 10) + SumOfDigits(A % 10);
        }
    }
}
