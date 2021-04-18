using System;
using System.Collections.Generic;

namespace CodeChallenges.Solutions
{
    public static class LongestSubset
    {
        public static int SolveOptimized(int[] A, int M)
        {
            var maximumSubsetCount = 1;
            var solvedSubProblems = new HashSet<int>();
            
            for (var i = 0; i < A.Length - 1 && !solvedSubProblems.Contains(i); i++)
            {
                var anySubset = false;
                var currentValue = A[i];
                var currentCount = 1;
                
                for (var j = i + 1; j < A.Length - 1; j++)
                {
                    if (Math.Abs(currentValue - A[j]) % M == 0)
                    {
                        if (!anySubset)
                            anySubset = true;
                        currentCount++;
                        solvedSubProblems.Add(j);
                    }
                }
                
                maximumSubsetCount = anySubset ? Math.Max(maximumSubsetCount, ++currentCount) : 1;
            }
            
            return maximumSubsetCount;
        }
        
        public static int Solve(int[] A, int M)
        {
            var maximumSubsetCount = 1;
            for (int i = 0; i < A.Length - 1; i++)
            {
                for (int j = i + 1; j < A.Length; j++)
                {
                    var distanceBetween = Math.Abs(A[i] - A[j]);
                    if (distanceBetween == 0) 
                        continue;

                    if (distanceBetween % M == 0)
                    {
                        var subsetCount = CountSubsetCount(A, j, M);
                        maximumSubsetCount = Math.Max(maximumSubsetCount, subsetCount);
                    }
                }
            }
            
            return maximumSubsetCount;
        }

        private static int CountSubsetCount(int[] A, int lastDivisible, int M)
        {
            var subsetCount = 2;

            for (int i = lastDivisible + 1; i < A.Length; i++)
            {
                var distanceBetweenLastAndCurrent = Math.Abs(A[lastDivisible] - A[i]);
                if (distanceBetweenLastAndCurrent == 0)
                    continue;
                if (distanceBetweenLastAndCurrent % M == 0)
                {
                    subsetCount++;
                    lastDivisible = i;
                }
            }

            return subsetCount;
        }
    }
}