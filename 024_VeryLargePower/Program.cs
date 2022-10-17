/*
 
    Problem Description
        Given two Integers A, B. You have to calculate (A ^ (B!)) % (1e9 + 7).

        "^" means power,
        "%" means "mod", and
        "!" means factorial.


    Problem Constraints
        1 <= A, B <= 5e5


    Input Format
        First argument is the integer A
        Second argument is the integer B

    Output Format
        Return one integer, the answer to the problem
 
 
 
 
 */

using System;

namespace _024_VeryLargePower
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        public int solve(int A, int B)
        {
            long m = 1000000000 + 7;
            long b = 1;
            for (long i = 2; i <= B; i++)
            {
                b = (b * i) % (m - 1);
            }

            return Convert.ToInt32(FastPower(A, b, m));
        }

        private static long FastPower(long a, long b, long m)
        {
            if (b == 0)
            {
                return 1;
            }

            long halfPower = FastPower(a % m, b / 2, m) % m;
            long fullPower = (halfPower * halfPower) % m;
            if (b % 2 == 0)
            {
                // adding m to handle a%b and -a%b
                return (fullPower + m) % m;
            }
            else
            {
                // adding m to handle a%b and -a%b
                return ((a * fullPower % m) + m) % m;
            }
        }


    }
}
