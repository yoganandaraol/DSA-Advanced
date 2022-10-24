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
