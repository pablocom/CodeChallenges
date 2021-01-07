using System;

namespace CodeChallenges.LongestCommonSubsequence
{
    public class BruteForceSolution : Solution
    {
        protected override string SolutionName => "Brute force";

        protected override int LongestCommonSubsequence(string X, string Y)
        {
            return LongestCommonSubsequenceRecursive(X, Y, X.Length, Y.Length); 
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