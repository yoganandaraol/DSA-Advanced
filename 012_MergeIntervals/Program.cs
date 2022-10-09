using System;
using System.Collections.Generic;
using System.Linq;

namespace _012_MergeIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputA = new List<List<int>>() { 
                new List<int>{ 1, 5 },
                new List<int>{ 6, 9 },
            };
            var output = new List<List<int>>() {
                new List<int>{ 1, 5 },
                new List<int>{ 6, 9 },
            };
            var calOutput = MergeIntervalsV2(inputA, 2, 5);
            Console.WriteLine(Enumerable.SequenceEqual(calOutput, output) ? "Passed" : "Failed");


            inputA = new List<List<int>>() {
                new List<int>{ 1, 2 },
                new List<int>{ 3, 6 },
            };
            output = new List<List<int>>() {
                new List<int>{ 1, 2 },
                new List<int>{ 3, 6 },
                new List<int>{ 8, 10 },
            };
            Console.WriteLine(Enumerable.SequenceEqual(MergeIntervalsV2(inputA, 8, 10), output) ? "Passed" : "Failed");

            inputA = new List<List<int>>() {
                new List<int>{ 3, 6 },
                new List<int>{ 8, 10 },

            };
            output = new List<List<int>>() {
                new List<int>{ 1, 2 },
                new List<int>{ 3, 6 },
                new List<int>{ 8, 10 },
            };
            Console.WriteLine(Enumerable.SequenceEqual(MergeIntervalsV2(inputA, 1, 2), output) ? "Passed" : "Failed");

            inputA = new List<List<int>>() {
                new List<int>{ 3, 6 },
                new List<int>{ 8, 10 },

            };
            output = new List<List<int>>() {
                new List<int>{ 1, 6 },
                new List<int>{ 8, 10 },
            };
            Console.WriteLine(Enumerable.SequenceEqual(MergeIntervalsV2(inputA, 1, 3), output) ? "Passed" : "Failed");

            inputA = new List<List<int>>() {
                new List<int>{6037774, 6198243},
                new List<int>{6726550, 7004541},
                new List<int>{8842554, 10866536},
                new List<int>{11027721, 11341296},
                new List<int>{11972532, 14746848}, 
                new List<int>{16374805, 16706396}, 
                new List<int>{17557262, 20518214}, 
                new List<int>{22139780, 22379559}, 
                new List<int>{27212352, 28404611}, 
                new List<int>{28921768, 29621583}, 
                new List<int>{29823256, 32060921}, 
                new List<int>{33950165, 36418956}, 
                new List<int>{37225039, 37785557}, 
                new List<int>{40087908, 41184444}, 
                new List<int>{41922814, 45297414}, 
                new List<int>{48142402, 48244133}, 
                new List<int>{48622983, 50443163}, 
                new List<int>{50898369, 55612831}, 
                new List<int>{57030757, 58120901}, 
                new List<int>{59772759, 59943999}, 
                new List<int>{61141939, 64859907}, 
                new List<int>{65277782, 65296274}, 
                new List<int>{67497842, 68386607}, 
                new List<int>{70414085, 73339545}, 
                new List<int>{73896106, 75605861}, 
                new List<int>{79672668, 84539434}, 
                new List<int>{84821550, 86558001}, 
                new List<int>{91116470, 92198054}, 
                new List<int>{96147808, 98979097}
            };
            output = new List<List<int>>() {
            };
            Console.WriteLine(Enumerable.SequenceEqual(MergeIntervalsV2(inputA, 36210193, 61984219), output) ? "Passed" : "Failed");


        }

        public static List<List<int>> MergeIntervals(List<List<int>> A, int B, int C)
        {
            var ans = new List<List<int>>();
            int temp;
            if (B > C)
            {
                temp = B;
                B = C;
                C = temp;
            }

            for (int i = 0; i < A.Count; i++)
            {
                int S = A[i][0];
                int E = A[i][1];
                if (HasOverlap(S, E, B, C))
                {
                    if (S <= B && E >= C)
                    {
                        ans.Add(new List<int> { S, E });
                    }
                    else if (S > B && E < C)
                    {
                        ans.Add(new List<int> { B, C });
                    }
                    else if (B < S && C < E)
                    {
                        ans.Add(new List<int> { B, E });
                    }
                    else if (B > S && E < C)
                    {
                        ans.Add(new List<int> { S, C });
                    }
                }
                else
                {
                    if (B < S && C < S)
                    {
                        ans.Add(new List<int> { B, C });
                        ans.Add(new List<int> { S, E });
                    }
                    else if (E < B && C < B)
                    {
                        ans.Add(new List<int> { S, E });
                        ans.Add(new List<int> { B, C });
                    }
                }
            }
            return ans;
        }

        public static List<List<int>> MergeIntervalsV1(List<List<int>> A, int B, int C)
        {
            var ans = new List<List<int>>();
            var res = new List<List<int>>(A);
            int temp;
            if (B > C)
            {
                temp = B;
                B = C;
                C = temp;
            }
            bool isHandled = false;
            for (int i = 0; i < A.Count; i++)
            {
                int S = A[i][0];
                int E = A[i][1];
                if (HasOverlap(S, E, B, C))
                {
                    isHandled = true;
                    if (S <= B && E >= C)
                    {
                        ans.Add(new List<int> { S, E });
                    }
                    else if (S > B && E < C)
                    {
                        ans.Add(new List<int> { B, C });
                        res[i][0] = B;
                        res[i][1] = C;
                    }
                    else if (B < S && C < E)
                    {
                        ans.Add(new List<int> { B, E });
                        res[i][0] = B;
                        res[i][1] = E;
                    }
                    else if (B > S && E < C)
                    {
                        ans.Add(new List<int> { S, C });
                        res[i][0] = S;
                        res[i][1] = C;
                    }
                }
                else
                {
                    if (!isHandled)
                    {
                        if (B < S && C < S)
                        {
                            res.Insert(i, new List<int> { B, C });
                            ans.Add(new List<int> { B, C });
                            ans.Add(new List<int> { S, E });
                        }
                        else if (E < B && E < C)
                        {
                            res.Insert(i + 1, new List<int> { B, C });
                            ans.Add(new List<int> { S, E });
                            ans.Add(new List<int> { B, C });
                        }
                    }
                }
            }
            return res;
        }

        public static List<List<int>> MergeIntervalsV2(List<List<int>> A, int B, int C)
        {
            var ans = new List<List<int>>(A);

            bool isHandled = false;
            for (int i = 0; i < A.Count; i++)
            {
                int S = A[i][0];
                int E = A[i][1];
                if (!isHandled)
                {

                    if (C < S)
                    {
                        isHandled = true;
                        ans.Insert(i, new List<int> { B, C });
                    }
                    else if (HasOverlap(S, E, B, C))
                    {
                        if (B < S)
                        {
                            if (C >= S && C <= E)
                            {
                                isHandled = true;
                                ans[i][0] = B;
                                ans[i][1] = E;
                            }
                            else if (E <= C)
                            {
                                isHandled = true;
                                ans[i][0] = B;
                                ans[i][1] = C;
                            }
                        }
                        else if (B > S)
                        {
                            if (C >= S && C <= E)
                            {
                                isHandled = true;
                                ans[i][0] = S;
                                ans[i][1] = E;
                            }
                            else if (E <= C)
                            {
                                isHandled = true;
                                ans[i][0] = S;
                                ans[i][1] = C;
                            }

                        }

                    }
                    else
                    {
                        isHandled = false;
                        continue;
                    }
                }
            }
            if (!isHandled)
            {
                ans.Add(new List<int> { B, C });
            }
            return ans;
        }

        public static List<List<int>> MergeIntervalsV3(List<List<int>> A, int B, int C)
        {
            var ans = new List<List<int>>(A);

            bool isHandled = false;
            for (int i = 0; i < A.Count; i++)
            {
                int S = A[i][0];
                int E = A[i][1];
                if (!isHandled)
                {
                    if (C < S)
                    {
                        isHandled = true;
                        ans.Insert(i, new List<int> { B, C });
                    }
                    else if (HasOverlap(S, E, B, C))
                    {
                        S = Math.Min(S, B);
                        E = Math.Max(E, C);
                        ans[i][0] = S;
                        ans[i][1] = E;
                    }
                    else
                    {
                        isHandled = false;
                        continue;
                    }
                }
            }
            if (!isHandled)
            {
                ans.Add(new List<int> { B, C });
            }
            return ans;
        }

        public static List<List<int>> MergeIntervalV4(List<List<int>> A, int B, int C)
        {
            int i = 0;
            var ans = new List<List<int>>(A);

            while (i < A.Count && A[i][1] <= B)
            {
                ans.Add(A[i]);
                i++;
            }

            int start = A[i][0];
            int end = A[i][1];
            while (i < A.Count && A[i][0] <= C)
            {
                start = Math.Min(A[i][0], B);
                end = Math.Max(A[i][1], C);
                i++;
            }
            ans.Add(new List<int>{ start, end });

            while (i < A.Count)
            {
                ans.Add(A[i++]);
            }

            return ans;
        }

        public List<List<int>> solve(List<List<int>> A, int B, int C)
        {
            var res = new List<List<int>>();
            var newInterval = new List<int>() { B, C };
            int i = 0;
            foreach (var interval in A)
            {
                // check if new interval is behind current interval, then add new interval first and then remaining in result
                if (newInterval[1] < interval[0])
                {
                    res.Add(newInterval);
                    var remainingIntervals = getIntervalsFrom(i, A);
                    res.AddRange(remainingIntervals);
                    return res;
                }
                // check if new interval is ahead of current interval, then add current interval in result
                else if (newInterval[0] > interval[1])
                {
                    res.Add(interval);
                }
                // there is an overlapping, find min start and end point
                else
                {
                    newInterval[0] = Math.Min(interval[0], newInterval[0]);
                    newInterval[1] = Math.Max(interval[1], newInterval[1]);
                }
                i++;
            }

            res.Add(newInterval);
            return res;
        }


        // Final Answer
        public List<List<int>> SolveV1(List<List<int>> A, int B, int C)
        {
            var res = new List<List<int>>();
            var newInterval = new List<int>() { B, C };
            int i = 0;
            foreach (var interval in A)
            {
                if (newInterval[1] < interval[0])
                {
                    res.Add(newInterval);
                    res.AddRange(A.Skip(i + 1));
                    return res;
                }
                else if (newInterval[0] > interval[1])
                {
                    res.Add(interval);
                }
                else
                {
                    newInterval[0] = Math.Min(interval[0], newInterval[0]);
                    newInterval[1] = Math.Max(interval[1], newInterval[1]);
                }
                i++;
            }

            res.Add(newInterval);
            return res;
        }

        private List<List<int>> getIntervalsFrom(int idx, List<List<int>> intervals)
        {
            var res = new List<List<int>>();
            for (int i = idx; i < intervals.Count; i++)
            {
                res.Add(intervals[i]);
            }
            return res;
        }


        private static bool HasOverlap(int a, int b, int x, int y)
        {
            if (x > b || y < a)
                return false;

            return true;
        }
    }
}
