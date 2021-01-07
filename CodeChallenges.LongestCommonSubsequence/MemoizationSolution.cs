using System;

namespace CodeChallenges.LongestCommonSubsequence
{
    public class MemoizationSolution : Solution
    {
        private int?[,] memoization;
        private int numberOfCalls = 0;

        protected override string SolutionName => "Memoization";

        protected override int LongestCommonSubsequence(string X, string Y)
        {
            memoization = new int?[X.Length, Y.Length];
            var longestCommonSubsequenceRecursive = LongestCommonSubsequenceRecursive(X, Y, X.Length, Y.Length);
            Console.WriteLine($"Number of calls: {numberOfCalls}");
            return longestCommonSubsequenceRecursive;
        }

        protected int LongestCommonSubsequenceRecursive(string X, string Y, int m, int n)
        {
            numberOfCalls++;

            if (m == 0 || n == 0)
                return 0;

            if (memoization[m - 1, n - 1] != null)
                return memoization[m - 1, n - 1].Value;

            var longestCommonSubsequence = 0;
            if (X[m - 1] == Y[n - 1])
            {
                longestCommonSubsequence = 1 + LongestCommonSubsequenceRecursive(X, Y, m - 1, n - 1);
                memoization[m - 1, n - 1] = longestCommonSubsequence;
                return longestCommonSubsequence;
            }

            longestCommonSubsequence = Math.Max(LongestCommonSubsequenceRecursive(X, Y, m, n - 1), LongestCommonSubsequenceRecursive(X, Y, m - 1, n));
            memoization[m - 1, n - 1] = longestCommonSubsequence;
            return longestCommonSubsequence;
        }
    }
}