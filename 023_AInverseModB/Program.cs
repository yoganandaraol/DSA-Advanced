/*
 
 
    Problem Description
        Given two integers A and B. Find the value of A-1 mod B where B is a prime number and gcd(A, B) = 1.

        A-1 mod B is also known as modular multiplicative inverse of A under modulo B.
 
 
    Example Input
        Input 1:
             A = 3
             B = 5

        Input 2:
             A = 6
             B = 23

    Example Output
        Output 1:
            2

        Output 2:
            4

    Explanation 1:
         Let's say A-1 mod B = X, then (A * X) % B = 1.
         3 * 2 = 6, 6 % 5 = 1.

    Explanation 2:
        Similarly, (6 * 4) % 23 = 1.
 
 */


using System;

namespace _023_AInverseModB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AInverseModB(3, 5) == 2 ? "Passed" : "Failed");
            Console.WriteLine(AInverseModB(6, 23) == 4 ? "Passed" : "Failed");
            Console.WriteLine(AInverseModB(12, 55557209) == 32408372 ? "Passed" : "Failed");
        }

        public static int AInverseModB(int A, int B)
        {

            #region Solution Logic Explanation

            /*
             *  Given that GCD(A, B) = 1
             *  => A is not divisible by B
             *  
             *  And given that B is prime
             *  
             *  Based on above 2 conditions, we can apply Fermat theorem to solve A inverse mod B
             *  
             *  Fermat theorem:
             *      
             *      a ^ (p-1) congurent to 1 mod p
             *      
             *      So by multiplying a power -1 both sides
             *      
             *      a ^ (p-2) congurent to (a ^ -1) mod p               // (a ^ -1) mod p ==> A inverse mod B which is our problem statement
             *      
             *      ---------------------------------------------
             *      |    (a ^ (p-2)) mod p =  (a ^ -1) mod p    |
             *      ---------------------------------------------
             *      
             *      so based on above equation 
             *      
             *      A inverse mod B =  (A ^ (B-2)) % B
             *      
             *      further (A ^ (B-2)) % B can be solved using Fast Power concept
             *      
             *      (a power b) % m
             *      
             *          if b is even
             *              ((a power b/2) % m) power b/2) % m
             *              
             *          if b is odd
             *              ( a * ((a power b/2) % m) power b/2) % m ) % m
             * 
             * 
             */

            #endregion
            int ans = Convert.ToInt32(FastPower(A, B - 2, B));
            return ans;
        }

        private static long FastPower(int a, int b, int m)
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
