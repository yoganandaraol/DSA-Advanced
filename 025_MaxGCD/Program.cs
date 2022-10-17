/*
 
 
    Problem Description

        Given an integer array A of size N. You have to delete one element such that the GCD(Greatest common divisor) of the remaining array is maximum.
        Find the maximum value of GCD.

    Problem Constraints

        2 <= N <= 10^5
        1 <= A[i] <= 10^9
 
    Example Input

        Input 1:
            A = [12, 15, 18]

        Input 2:
            A = [5, 15, 30]


    Example Output

        Output 1:
            6

        Output 2:
            15

 
 
 */

using System;
using System.Collections.Generic;

namespace _025_MaxGCD
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputA = new List<int> { 12, 15, 18 };
            Console.WriteLine(Solve(inputA) == 6 ? "Passed" : "Failed");

            inputA = new List<int> { 5, 15, 30 };
            Console.WriteLine(Solve(inputA) == 15 ? "Passed" : "Failed");

            inputA = new List<int> { 5, 15, 30, 60 };
            Console.WriteLine(Solve(inputA) == 15 ? "Passed" : "Failed");

            inputA = new List<int> { 15, 30, 60 };
            Console.WriteLine(Solve(inputA) == 30 ? "Passed" : "Failed");

            inputA = new List<int> { 208610688, 48106344, 135402124, 34168992, 95013776, 35218040, 117231114, 172905590, 66652014, 45970782, 222323244, 203402914, 35292972, 159829956, 154584716, 107190226, 71335264, 42786172, 203327982, 3484338, 28062034, 64179258, 210993, 94938844, 155858560, 123562868, 223447224, 116744056, 55711942, 88082566, 45671054, 16072914, 165299992, 136601036, 44659472, 219063702, 202953322, 188341582, 116931386, 127759060, 131318330, 49867246, 92278758, 40875406, 218314382, 135889182, 6893744, 97111872, 56236466, 96662280, 52340002, 195010530, 44884268, 167435554, 155746162, 201679478, 54138370, 103481092, 25814074, 186093622, 208498290, 31883566, 122101694, 128058788, 133566290, 55749408, 178675354, 186056156, 155071774, 35180574, 82050540, 7755462, 29448276, 100333948, 130156884, 67850926, 44509608, 17084496, 216703344, 197295956, 174479162, 18058612, 51290954, 173917172, 51815478, 218426780, 184032992, 148140564, 108951128 };
            Console.WriteLine(Solve(inputA) == 37466 ? "Passed" : "Failed");

            inputA = new List<int> { 208610688, 48106344, 135402124, 34168992, 95013776, 35218040, 117231114, 172905590, 66652014, 45970782, 222323244, 203402914, 35292972, 159829956, 154584716, 107190226, 71335264, 42786172, 203327982, 3484338, 28062034, 64179258, 210993, 94938844, 155858560, 123562868, 223447224, 116744056, 55711942, 88082566, 45671054, 16072914, 165299992, 136601036, 44659472, 219063702, 202953322, 188341582, 116931386, 127759060, 131318330, 49867246, 92278758, 40875406, 218314382, 135889182, 6893744, 97111872, 56236466, 96662280, 52340002, 195010530, 44884268, 167435554, 155746162, 201679478, 54138370, 103481092, 25814074, 186093622, 208498290, 31883566, 122101694, 128058788, 133566290, 55749408, 178675354, 186056156, 155071774, 35180574, 82050540, 7755462, 29448276, 100333948, 130156884, 67850926, 44509608, 17084496, 216703344, 197295956, 174479162, 18058612, 51290954, 173917172, 51815478, 218426780, 184032992, 148140564, 108951128 };
            Console.WriteLine(Solve(inputA) == 37466 ? "Passed" : "Failed");


        }

        public static int Solve(List<int> A)
        {
            var pGCD = new List<int>(A);
            var sGCD = new List<int>(A);
            var indexLE = A.Count - 1;
            for (int i = 1; i < A.Count; i++)
            {
                pGCD[i] = CalculateGCD(pGCD[i - 1], A[i]);
                
            }
            for (int i = indexLE-1; i >= 0; i--)
            {
                sGCD[i] = CalculateGCD(sGCD[i+1], A[i]);
            }

            int maxGCD = Math.Max(pGCD[indexLE-1], sGCD[1]);
            for (int i = 1; i < A.Count-1; i++)
            {
                maxGCD = Math.Max(maxGCD, CalculateGCD(pGCD[i-1], sGCD[i+1]));
            }

            return maxGCD;
        }

        public static int CalculateGCD(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }

            return CalculateGCD(b % a, a);
        }
    }
}
