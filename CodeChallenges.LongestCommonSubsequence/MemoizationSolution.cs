using System;

namespace CodeChallenges.LongestCommonSubsequence
{
    public class MemoizationSolution : LongestCommonSubsequenceSolution
    {
        private int?[,] memoization;

        protected override string SolutionName => "Memoization";

        protected override int LongestCommonSubsequence(string X, string Y)
        {
            memoization = new int?[X.Length, Y.Length];
            return LongestCommonSubsequenceRecursive(X, Y, X.Length, Y.Length);
        }

        protected int LongestCommonSubsequenceRecursive(string X, string Y, int m, int n)
        {
            Console.WriteLine($"Calculating for X[{m}] Y[{n}]");

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