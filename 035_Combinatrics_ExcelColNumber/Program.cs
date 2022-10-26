using System;

namespace _035_Combinatrics_ExcelColNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ExcelColumnNumber("Z") == 26 ? "Passed" : "Failed");
            Console.WriteLine(ExcelColumnNumber("A") == 1 ? "Passed" : "Failed");
            Console.WriteLine(ExcelColumnNumber("AA") == 27 ? "Passed" : "Failed");
            Console.WriteLine(ExcelColumnNumber("BB") == 54 ? "Passed" : "Failed");
        }

        public static int ExcelColumnNumber(string A)
        {
            int size = A.Length;
            int res = 0;
            for (int i = 0; i < size; i++)
            {
                if (size == 1)
                {
                    res += (A[i] - 64);
                }
                else
                {
                    res += Convert.ToInt32(Math.Pow(26, size - 1 - i)) * (A[i] - 64);
                }
            }
            return res;
        }
    }
}
