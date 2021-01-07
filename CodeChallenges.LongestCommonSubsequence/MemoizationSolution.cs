using System;
using System.Diagnostics;

namespace CodeChallenges.LongestCommonSubsequence
{
    public class MemoizationSolution
    {
        private int?[,] memoization;

        public int LongestCommonSubsequence(string X, string Y)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            memoization = new int?[X.Length, Y.Length];

            var longestCommonSubsequence = LongestCommonSubsequence(X, Y, X.Length, Y.Length);
            stopwatch.Stop();

            Console.WriteLine($"Memoization: {stopwatch.Elapsed}");

            return longestCommonSubsequence;
        }

        public int LongestCommonSubsequence(string X, string Y, int m, int n)
        {
            if (m == 0 || n == 0)
                return 0;

            int longestCommonSubsequence = 0;

            if (memoization[m - 1, n - 1] != null)
                return memoization[m - 1, n - 1].Value;

            if (X[m - 1] == Y[n - 1])
            {
                longestCommonSubsequence = 1 + LongestCommonSubsequence(X, Y, m - 1, n - 1);
                memoization[m - 1, n - 1] = longestCommonSubsequence;
                return longestCommonSubsequence;
            }

            longestCommonSubsequence = Math.Max(LongestCommonSubsequence(X, Y, m, n - 1), LongestCommonSubsequence(X, Y, m - 1, n));
            memoization[m - 1, n - 1] = longestCommonSubsequence;
            return longestCommonSubsequence;
        }
    }
}