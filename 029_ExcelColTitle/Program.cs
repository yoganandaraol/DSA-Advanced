using System;

namespace _029_ExcelColTitle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ExcelColTitle(3) == "C" ? "Passed" : "Failed");
            Console.WriteLine(ExcelColTitle(26) == "Z" ? "Passed" : "Failed");
            Console.WriteLine(ExcelColTitle(27) == "AA" ? "Passed" : "Failed");
            Console.WriteLine(ExcelColTitle(1000) == "ALL" ? "Passed" : "Failed");
            Console.WriteLine(ExcelColTitle(943566) == "BAQTZ" ? "Passed" : "Failed");

        }

        static string ExcelColTitle(int A)
        {
            if (A <= 26)
            {
                return Convert.ToString((char)(A - 1 + 'A'));
            }

            int left = A / 26;
            int right = A % 26;
            if (right == 0)
            {
                right += 26;
                left -= 1;
            }

            return ExcelColTitle(left) + ExcelColTitle(right);
        }
    }
}
