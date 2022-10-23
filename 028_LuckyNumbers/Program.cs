using System;

namespace _028_LuckyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetLucklyNumber(8) == 1 ? "Passed" : "Failed");
            Console.WriteLine(GetLucklyNumber(12) == 3 ? "Passed" : "Failed");

            var output = GetSieve(30);
        }

        public static int GetLucklyNumber(int A)
        {

            int[] primeFacs = GetSieve(A);
            int ans = 0;
            foreach (var a in primeFacs)
            {
                if (a == 2)
                    ans++;
            }
            return ans;
        }


        public static int[] GetSieve(int A)
        {
            int[] prime = new int[A + 1];
            for (int i = 2; i <= A; i++)
            {
                if (prime[i] == 0)
                {
                    for (int j = i; j <= A; j += i)
                        prime[j]++;
                }
            }
            return prime;
        }
    }
}
