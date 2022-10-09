using System;
using System.Collections.Generic;
using System.Linq;

namespace _013_MergeOverlappingIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Interval> inputA = new List<Interval> {
                new Interval(1, 3   ),
                new Interval(2, 6   ),
                new Interval(8, 10  ),
                new Interval(15, 18 )
            };
            List<Interval> output = new List<Interval> {
                new Interval(1, 6   ),
                new Interval(8, 10  ),
                new Interval(15, 18 )
            };
            var calculatedOutput = Merge2(inputA);
            Console.WriteLine(IsEqual(calculatedOutput, output) ? "Passed" : "Failed");


            inputA = new List<Interval> {
                new Interval(1, 2   ),
                new Interval(2, 6   ),
                new Interval(5, 6   ),
                new Interval(8, 10  ),
                new Interval(15, 18 )
            };
            output = new List<Interval> {
                new Interval(1, 6   ),
                new Interval(8, 10  ),
                new Interval(15, 18 )
            }; 
            calculatedOutput = Merge2(inputA);
            Console.WriteLine(IsEqual(calculatedOutput, output) ? "Passed" : "Failed");

            inputA = new List<Interval> {
                new Interval(1, 20   ),
                new Interval(2, 6   ),
                new Interval(5, 6   ),
                new Interval(8, 10  ),
                new Interval(15, 18 )
            };
            output = new List<Interval> {
                new Interval(1, 20   )
            };
            calculatedOutput = Merge2(inputA);
            Console.WriteLine(IsEqual(calculatedOutput, output) ? "Passed" : "Failed");


            inputA = new List<Interval> {
                new Interval(54, 75),
                new Interval(56, 60),
                new Interval(61, 86),
                new Interval(22, 43),
                new Interval(56, 87),
                new Interval(32, 53),
                new Interval(14, 81),
                new Interval(64, 65),
                new Interval( 9, 42),
                new Interval(12, 33),
                new Interval(22, 58),
                new Interval(84, 90),
                new Interval(27, 59),
                new Interval(41, 48),
                new Interval(43, 47),
                new Interval(22, 29),
                new Interval(16, 23),
                new Interval(41, 72),
                new Interval(15, 87),
                new Interval(20, 59),
                new Interval(45, 84),
                new Interval(14, 77),
                new Interval(72, 93),
                new Interval(20, 58),
                new Interval(47, 53),
                new Interval(25, 88),
                new Interval( 5, 89),
                new Interval(34, 97),
                new Interval(14, 47 )
            };
            output = new List<Interval> {
                new Interval(5, 97  )
            };
            calculatedOutput = Merge2(inputA);
            Console.WriteLine(IsEqual(calculatedOutput, output) ? "Passed" : "Failed");

            inputA = new List<Interval> {
               new Interval(47, 76),new Interval(51, 99),new Interval(28, 78),new Interval(54, 94),new Interval(12, 72),new Interval(31, 72),new Interval(12, 55),new Interval(24, 40),new Interval(59, 79),new Interval(41, 100),new Interval(46, 99),new Interval(5, 27),new Interval(13, 23),new Interval(9, 69),new Interval(39, 75),new Interval(51, 53),new Interval(81, 98),new Interval(14, 14),new Interval(27, 89),new Interval(73, 78),new Interval(28, 35),new Interval(19, 30),new Interval(39, 87),new Interval(60, 94),new Interval(71, 90),new Interval(9, 44),new Interval(56, 79),new Interval(58, 70),new Interval(25, 76),new Interval(18, 46),new Interval(14, 96),new Interval(43, 95),new Interval(70, 77),new Interval(13, 59),new Interval(52, 91),new Interval(47, 56),new Interval(63, 67),new Interval(28, 39),new Interval(51, 92),new Interval(30, 66),new Interval(4, 4),new Interval(29, 92),new Interval(58, 90),new Interval(6, 20),new Interval(31, 93),new Interval(52, 75),new Interval(41, 41),new Interval(64, 89),new Interval(64, 66),new Interval(24, 90),new Interval(25, 46),new Interval(39, 49),new Interval(15, 99),new Interval(50, 99),new Interval(9, 34),new Interval(58, 96),new Interval(85, 86),new Interval(13, 68),new Interval(45, 57),new Interval(55, 56),new Interval(60, 74),new Interval(89, 98),new Interval(23, 79),new Interval(16, 59),new Interval(56, 57),new Interval(54, 85),new Interval(16, 29),new Interval(72, 86),new Interval(10, 45),new Interval(6, 25),new Interval(19, 55),new Interval(21, 21),new Interval(17, 83),new Interval(49, 86),new Interval(67, 84),new Interval(8, 48),new Interval(63, 85),new Interval(5, 31),new Interval(43, 48),new Interval(57, 62),new Interval(22, 68),new Interval(48, 92),new Interval(36, 77),new Interval(27, 63),new Interval(39, 83),new Interval(38, 54),new Interval(31, 69),new Interval(36, 65),new Interval(52, 68)
            };
            output = new List<Interval> {
                new Interval(4, 4  ),
                new Interval(5, 100)
            };
            calculatedOutput = Merge2(inputA);
            Console.WriteLine(IsEqual(calculatedOutput, output) ? "Passed" : "Failed");
        }

        public static List<Interval> Merge(List<Interval> intervals)
        {
            var ans = new List<Interval>();
            var prevInterval = intervals[0];
            
            for (int i = 1; i < intervals.Count; i++)
            {
                if (prevInterval.end >= intervals[i].start)
                {
                    if (prevInterval.end >= intervals[i].end)
                    {
                        ans.Add(new Interval(prevInterval.start, prevInterval.end));
                    }
                    else
                    {
                        // ans.Add(new Interval(prevInterval.start, intervals[i].end));
                        prevInterval = intervals[i];
                        continue;
                    }
                }
                else
                {
                    if (i == 1)
                    {
                        ans.Add(prevInterval);
                    }

                    ans.Add(intervals[i]);
                    prevInterval = intervals[i];
                }

            }

            return ans;
        }

        public static List<Interval> Merge2(List<Interval> intervals)
        {
            intervals = intervals.OrderBy(x => x.start).ToList<Interval>();
            var ans = new List<Interval>();
            var prevInterval = intervals[0];
            int i = 1;
            bool isHandled = false;
            while ( i < intervals.Count )
            {
                if (HasOverlap(prevInterval.start, prevInterval.end, intervals[i].start, intervals[i].end))
                {
                    var temp = new Interval(
                        Math.Min(prevInterval.start, intervals[i].start),
                        Math.Max(prevInterval.end, intervals[i].end)
                        );

                    prevInterval = temp;
                    isHandled = false;
                }
                else
                {
                    ans.Add(prevInterval);
                    if (i == intervals.Count -1)
                    {
                        ans.Add(intervals[i]);
                    }
                    prevInterval = intervals[i];
                    isHandled = true;

                }
                i++;
            }

            if (!isHandled)
            {
                ans.Add(prevInterval);
            }

            return ans;
        }

        private static bool HasOverlap(int a, int b, int x, int y)
        {
            if (x > b || y < a)
                return false;

            return true;
        }

        private static bool IsEqual(List<Interval> l1, List<Interval> l2)
        {
            if (l1.Count == l2.Count)
            {
                for (int i = 0; i < l1.Count; i++)
                {
                    if (l1[i].start == l2[i].start && l1[i].end == l2[i].end)
                    {
                        continue;
                    }
                    else return false;
                }
            }
            else return false;

            return true;
        }
    }

    public class Interval
    {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }
}
