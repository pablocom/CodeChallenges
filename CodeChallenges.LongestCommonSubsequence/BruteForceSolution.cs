using System;
using System.Diagnostics;

namespace CodeChallenges.LongestCommonSubsequence
{
    public class BruteForceSolution : Solution
    {
        protected override string SolutionName => "Brute force";

        protected override int LongestCommonSubsequence(string X, string Y)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            
            var longestCommonSubsequence = LongestCommonSubsequence(X, Y, X.Length, Y.Length);
            stopwatch.Stop();

            Console.WriteLine($"Brute force: {stopwatch.Elapsed}");

            return longestCommonSubsequence; 
        }

        public int LongestCommonSubsequence(string X, string Y, int m, int n)
        {

            if (m == 0 || n == 0)
                return 0;

            if (X[m - 1] == Y[n - 1])
                return 1 + LongestCommonSubsequence(X, Y, m - 1, n - 1);
            
            return Math.Max(LongestCommonSubsequence(X, Y, m, n - 1), LongestCommonSubsequence(X, Y, m - 1, n));
        }
    }
}