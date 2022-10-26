using System;
using System.Collections.Generic;
using System.Linq;

namespace _027_PrimeSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CheckPrime(7) ? "Passed":"Failed");
            Console.WriteLine(CheckPrime(17) ? "Passed":"Failed"); 
            Console.WriteLine(CheckPrime(11393) ? "Passed":"Failed"); 
            Console.WriteLine(CheckPrime(11383) ? "Passed":"Failed");
            Console.WriteLine(!CheckPrime(11194) ? "Passed":"Failed");
            Console.WriteLine(CheckPrime(23291) ? "Passed":"Failed");

            Console.WriteLine("-------------------------");
            var output = new List<int> { 2, 2 };
            Console.WriteLine(Enumerable.SequenceEqual(GetPrimeSumOfAV1(4), output) ? "Passed" : "Failed");

            output = new List<int> { 31, 16777183 };
            Console.WriteLine(Enumerable.SequenceEqual(GetPrimeSumOfAV1(16777214), output) ? "Passed" : "Failed");

            output = new List<int> { 3, 7 };
            Console.WriteLine(Enumerable.SequenceEqual(GetPrimeSumOfAV1(10), output) ? "Passed" : "Failed");
        }

        public static List<int> GetPrimeSumOfA(int A)
        {
            var res = new List<int>();
            var primes = GetAllPrimes(A);
            var sieve = GetAllSieves(A);

            var left = 0;
            var right = primes.Count - 1;

            while (left <= right)
            {
                if (primes[left] + primes[right] == A)
                {
                    res.Add(primes[left]);
                    res.Add(primes[right]);
                    break;
                }
                else if (primes[left] + primes[left] == A)
                {
                    res.Add(primes[left]);
                    res.Add(primes[left]);
                    break;
                }
                else if (primes[right] + primes[right] == A)
                {
                    res.Add(primes[right]);
                    res.Add(primes[right]);
                    break;
                }
                left++;
                right--;
            }

            return res;
        }

        // TODO: FIX REQUIRED
        public static List<int> GetPrimeSumOfAV1(int A)
        {
            var res = new List<int>();
            if (A == 4)
            {
                res.Add(2);
                res.Add(2);
                return res;
            }
            var sieve = GetAllSieves(A);
            var s = sieve.FindAll(x => x == true);

            for (int i = 2; i <= A; i++)
            {
                if (sieve[i] && sieve[A - 1])
                {
                    res.Add(i);
                    res.Add(A - 1);
                    break;
                }
            }

            return res;
        }

        public static List<int> GetAllPrimes(int A)
        {
            var res = new List<int>() { 2 };
            for (int i = 3; i < A; i++)
            {
                if(CheckPrime(i))
                    res.Add(i);
            }

            return res;
        }

        public static List<bool> GetAllSieves(int A)
        {
            var res = new List<bool>() { false, false };

            for (int i = 2; i <= A+1; i++)
            {
                res.Add(true);
            }

            //for (int i = 2; i <= A; i++)
            //{
            //    if (res[i] == true)
            //    {
            //        for (int j = i; j  <= A; j += i)
            //        {
            //            res[j] = false;
            //        }
            //    }
            //}

            for (int i = 2; i <= A + 1; i++)
            {
                if (res[i] == true)
                {
                    for (int j = i; j < A + 1; j += i)
                    {
                        res[j] = false;
                    }
                }
            }

            return res;
        }

        public static bool CheckPrime(int A)
        {
            var ans = true;

            for (int i = 2; i * i < A; i++)
            {
                if (A%i == 0)
                {
                    ans = false;
                    break;
                }
            }

            return ans;
        }
    }
}
