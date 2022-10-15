/*
 * 
 *  Problem Description
        Given two binary strings, return their sum (also a binary string).
        Example:

        a = "100"

        b = "11"
        Return a + b = "111".
 * 
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace _020_AddTwoBinaryStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = DateTime.Now;
            Console.WriteLine(AddBinary("00110", "10") == "1000" ? "Passed" : "Failed");
            Console.WriteLine(AddBinary("100", "11") == "111" ? "Passed" : "Failed");
            Console.WriteLine(AddBinary("000100", "11") == "111" ? "Passed" : "Failed");

            Console.WriteLine(DateTime.Now - t);
            Console.WriteLine("--------------------------");

            t = DateTime.Now;
            Console.WriteLine(addBinary("00110", "10") == "1000" ? "Passed" : "Failed");
            Console.WriteLine(addBinary("100", "11") == "111" ? "Passed" : "Failed");
            Console.WriteLine(addBinary("000100", "11") == "111" ? "Passed" : "Failed");
            Console.WriteLine(DateTime.Now - t);
        }

        // Better solution covers all scenarios
        public static string AddBinary(string A, string B)
        {
            // StringBuilder temp = new StringBuilder();
            var temp = new List<char>();
            StringBuilder ans = new StringBuilder();
            bool carry = false;
            int maxLen = Math.Max(A.Length, B.Length);

            if (A.Length != maxLen)
            {
                A = A.PadLeft(maxLen, '0');
            }
            if (B.Length != maxLen)
            {
                B = B.PadLeft(maxLen, '0');
            }

            for (int i = maxLen - 1; i >= 0; i--)
            {
                if (A[i] == B[i] && A[i] == '1')
                {
                    if (carry)
                        temp.Add('1');
                    else
                        temp.Add('0');

                    carry = true;
                }
                else if (A[i] == '1' || B[i] == '1')
                {
                    if (carry)
                    {
                        temp.Add('0');
                        carry = true;
                    }
                    else
                    {
                        temp.Add('1');
                        carry = false;
                    }
                }
                else
                {
                    if (carry)
                        temp.Add('1');
                    else
                        temp.Add('0');

                    carry = false;
                }
            }
            if (carry)
            {
                temp.Add('1');
            }

            for (int i = temp.Count - 1; i >= 0; i--)
            {
                if (temp[i] == '0' && ans.Length == 0)
                {
                    continue;
                }
                ans.Append(temp[i]);
            }
            return ans.ToString();
        }

        public static string addBinary(string A, string B)
        {
            List<char> l1 = new List<char>();
            int carry = 0;
            int i = A.Length - 1;
            int j = B.Length - 1;
            // we add bits from the rightmost bit to the leftmost bit
            while (i >= 0 || j >= 0 || carry > 0)
            {
                int sum = carry;
                if (i >= 0)
                    sum += (A[i] - '0');
                if (j >= 0)
                    sum += (B[j] - '0');
                l1.Add((char)('0' + sum % 2));
                carry = sum / 2;
                i--;
                j--;
            }
            StringBuilder ans = new StringBuilder();
            for (i = l1.Count - 1; i >= 0; i--)
            {
                ans.Append(l1[i]);
            }
            return ans.ToString();
        }
    }
}
