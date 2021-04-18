using System;

namespace CodeChallenges.LongestCommonSubsequence
{
    public static class TabulationSolution
    {
        public static int LongestCommonSubsequence(string text1, string text2)
        {
            int numberOfCalls = 0;
            var m = text1.Length;
            var n = text2.Length;

            var resultsTable = new int[m + 1, n + 1];

            for (var i = 0; i <= m; i++)
            {
                for (var j = 0; j <= n; j++)
                {
                    numberOfCalls++;
                    if (i == 0 || j == 0)
                        resultsTable[i, j] = 0;
                    else if (text1[i - 1] == text2[j - 1])
                        resultsTable[i, j] = resultsTable[i - 1, j - 1] + 1;
                    else
                        resultsTable[i, j] = Math.Max(resultsTable[i - 1, j], resultsTable[i, j - 1]);
                }
            }
            
            Console.WriteLine($"Number of calls: {numberOfCalls}");

            return resultsTable[m, n];
        }
    }
}