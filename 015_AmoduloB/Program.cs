/*
 
    Problem Description
        Given two integers A and B, find the greatest possible positive integer M, such that A % M = B % M.


    Problem Constraints
        1 <= A, B <= 109
        A != B



    Input Format
        The first argument is an integer A.
        The second argument is an integer B.

    Output Format
        Return an integer denoting the greatest possible positive M.


    Example Input
        Input 1:
            A = 1
            B = 2
        
        Output:
            1

        Explanation:
            1 is the largest value of M such that A % M == B % M.



        Input 2:
            A = 5
            B = 10

        Output:
            5

        Explanation 2:

            For M = 5, A % M = 0 and B % M = 0.
            No value greater than M = 5, satisfies the condition.
 
 
 */


using System;

namespace _015_GreatestPossibleModulo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Modulo(1, 2) == 1 ? "Passed" : "Failed");
            Console.WriteLine(Modulo(5, 10) == 5 ? "Passed" : "Failed");
            Console.WriteLine(Modulo(12, 2) == 10 ? "Passed" : "Failed");
        }


        /*
         * ---------------------------------------------------------------------
         *  What is the greatest possible +ve integer M for the equation
         *          A % M = B % M
         * ---------------------------------------------------------------------
         * 
         * Bruteforce:
         *  
         *      we can find the value of M by looping " 1 to min(A, B)  "
         *      and storing maximum of M, which satisfies A % M = B % M
         * 
         * 
         *      TC = O( min(A, B) )
         *      SC = O(1)
         *      
         * ---------------------------------------------------------------------
         * 
         * Better Approach:
         * 
         * 
         *          A % M = B % M
         *          ( A - B ) % M = 0   ==> means A-B is factor M
         *          
         *          so 
         *              ( A-B ) = f * M
         *              M = ( A-B ) / f
         *              
         *          ask is greatest possible +ve integer M
         *          
         *              M is maximum if f is 1
         *              
         *          so M = abs(A-B)
         *          
         *      TC = O(1)
         *      SC = O(1)
         * 
         */
        public static int Modulo(int A, int B)
        {
            return Math.Abs(A - B);
        }
    }
}
