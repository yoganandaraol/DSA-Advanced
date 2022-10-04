using System;

namespace _009_NumberOfSetBits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NumberOfSetBitsInInteger(10) == 2 ? "Passed" : "Failed");
            Console.WriteLine(NumberOfSetBitsInInteger(32) == 1 ? "Passed" : "Failed");
            Console.WriteLine(NumberOfSetBitsInInteger(31) == 5 ? "Passed" : "Failed");
            Console.WriteLine(NumberOfSetBitsInInteger(65) == 2 ? "Passed" : "Failed");
            Console.WriteLine(NumberOfSetBitsInInteger(68) == 2 ? "Passed" : "Failed");
        }

        public static int NumberOfSetBitsInInteger(int A)
        {
            int bits = 0;
            int ans = 0;

            while (bits < 32)
            {
                if (((A >> bits) & 1) == 1)
                {
                    ans++;
                }
                bits++;
            }

            return ans;
        }
    }
}
