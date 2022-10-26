using System;

namespace _034_Combinatrics_nCrModP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        // TODO: FIX REQUIRED
        public int Compute_nCrModP(int A, int B, int C)
        {
            long[] arr = new long[A + 1];
            arr[0] = 1;
            for (int i = 1; i <= A; i++)
            {
                arr[i] = ((arr[i - 1] % C) * (i % C)) % C;
                arr[i] %= C;
            }

            long num = arr[A] % C;

            /*
                Applied Little fermat Theorem
                A POW P=A MOD P
                A POW P-2= (A POW -1) MOD P  
                in our case,
                A POW P-2 is Math.pow(a[A-B] * a[B], C-2)
            */
            long k = ((arr[A - B] % C) * (arr[B] % C)) % C;
            long power = FastPower(k, C - 2, C);
            long ans = ((num % C) * (power % C)) % C;
            return (int)ans;

        }

        public long FastPower(long A, int B, int C)
        {
            if (A == 0) return 1;
            if (B == 0) return 1;
            if (B == 1) return (A + C) % C;

            long halfPower = FastPower(A, B / 2, C);
            if (B % 2 == 0)
            {
                return ((halfPower % C) * (halfPower % C)) % C;
            }
            else
            {
                return ((halfPower % C) * ((halfPower * A) % C)) % C;
            }
        }
    }
}
