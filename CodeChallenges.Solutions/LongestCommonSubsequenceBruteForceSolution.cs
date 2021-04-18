using System;

namespace CodeChallenges.Solutions
{
    public class LongestCommonSubsequenceBruteForceSolution
    {
        public int LongestCommonSubsequence(string X, string Y)
        {
            var longestCommonSubsequenceRecursive = LongestCommonSubsequenceRecursive(X, Y, X.Length, Y.Length);
            return longestCommonSubsequenceRecursive;
        }

        public int LongestCommonSubsequenceRecursive(string X, string Y, int m, int n)
        {
            if (m == 0 || n == 0)
                return 0;

            if (X[m - 1] == Y[n - 1])
                return 1 + LongestCommonSubsequenceRecursive(X, Y, m - 1, n - 1);
            
            return Math.Max(LongestCommonSubsequenceRecursive(X, Y, m, n - 1), LongestCommonSubsequenceRecursive(X, Y, m - 1, n));
        }
    }
}