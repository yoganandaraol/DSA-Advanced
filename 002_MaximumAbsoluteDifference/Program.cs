using System;
using System.Collections.Generic;

namespace _002_MaximumAbsoluteDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputA = new List<int> { 1, 3, -1 };
            Console.WriteLine(MaxArr(inputA) == 5 ? "Passed" : "Failed");

            inputA = new List<int> { 2 };
            Console.WriteLine(MaxArr(inputA) == 0 ? "Passed" : "Failed");

            inputA = new List<int> { 2, 2, 2 };
            Console.WriteLine(MaxArr(inputA) == 2 ? "Passed" : "Failed");

            inputA = new List<int> { -1000000000, -1000000000, -1000000000, -1000000000, -1000000000 };
            Console.WriteLine(MaxArr(inputA) == 4 ? "Passed" : "Failed");
        }

        /*
         * ++++++++++++++++++++++++++++++++++++++++++++++++++
         * 
         *          f(i, j) = |A[i] - A[j]| + |i - j|
         * 
         * ++++++++++++++++++++++++++++++++++++++++++++++++++
         * 
         *  Q - Find the max value comes out of above function for a given list.
         * 
         *  Observations:
         * 
         *  --> if i == j ==> f(i, j) = 0
         *  --> min(f(i, j)) = 0 --> so we can set min val as 0
         *  --> relationship between f(i,j) and f(j,i) is
         *          for all values of i,j ---> f(i,j) = f(j,i) 
         *          
         *      So we can only check the list with i > j or j > i scenarios
         *      
         *      by taking i > j (i - j > 0)condition for solving the problem
         *      the expression is easy to resolve because i-j always +ve
         *      so we can remove the mod for |i-j| in f(i, j)
         *      
         *      
         *      Now the function becomes
         *      
         *          f(i, j) = |A[i] - A[j]| + i - j
         *          
         *      Further conditions are
         *      
         *          A[i] >= A[j]                    A[i] < A[j]
         *          
         *          For A[i] >= A[j]
         *          ----------------
         *          
         *              f(i, j) = A[i] - A[j] + i - j
         *              f(i, j) = ( A[i] + i ) - (  A[j] + j )
         *                          --------        -------
         *           max f(i, j)       max             min  
         *               
         *               for getting max f(i, j) -->
         *                      
         *                         A[i] + i should be max
         *                         A[j] + j should be min
         *                
         *          For A[i] < A[j]
         *          ---------------
         *              
         *              f(i, j) = A[j] - A[i] + i - j
         *              f(i, j) = ( A[j] - j ) - (  A[i] - i )
         *                          --------        -------
         *           max f(i, j)       max             min  
         *               
         *               for getting max f(i, j) -->
         *                      
         *                         A[j] - j should be max
         *                         A[i] - i should be min
         *          
         *          
        */
        public static int MaxArr(List<int> A)
        {
            int min1 = int.MaxValue, max1 = int.MinValue, min2 = int.MaxValue, max2 = int.MinValue;

            for (int i = 0; i < A.Count; i++)
            {
                max1 = Math.Max(A[i] + i, max1);
                min1 = Math.Min(A[i] + i, min1);
                max2 = Math.Max(A[i] - i, max2);
                min2 = Math.Min(A[i] - i, min2);
            }
            return Math.Max(max1 - min1, max2 - min2);
        }
    }
}
