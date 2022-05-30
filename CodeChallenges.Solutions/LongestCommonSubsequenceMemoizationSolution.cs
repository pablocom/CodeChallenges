using System;

namespace CodeChallenges.Solutions;

public class MemoizationSolution
{
    private int?[,] memoization;
    private int numberOfCalls = 0;

    public int LongestCommonSubsequence(string text1, string text2)
    {
        memoization = new int?[text1.Length, text2.Length];
        var longestCommonSubsequenceRecursive = LongestCommonSubsequenceRecursive(text1, text2, text1.Length, text2.Length);
        Console.WriteLine($"Memoization Number of calls: {numberOfCalls}");
        return longestCommonSubsequenceRecursive;
    }

    public int LongestCommonSubsequenceRecursive(string X, string Y, int m, int n)
    {
        numberOfCalls++;

        if (m == 0 || n == 0)
            return 0;

        if (memoization[m - 1, n - 1] != null)
            return memoization[m - 1, n - 1].Value;

        int longestCommonSubsequence;
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