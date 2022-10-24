using System;

namespace _030_SortedPermutationRank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static int FindRank(string A)
        {
            int ans = 0;
            for (int i = A.Length-1; i <= 0; i--)
            {
                int currentDigit = ('A' - A[i]) + 1;
                ans += currentDigit * (Convert.ToInt32(Math.Pow(26, (A.Length - i) + 1)) % 1000003);
            }
            return ans;
        }
    }
}
