using System;
using System.Diagnostics;

namespace CodeChallenges.LongestCommonSubsequence
{
    public class TabulationLongestCommonSubsequenceSolution : LongestCommonSubsequenceSolution
    {
        protected override string SolutionName => "Tabulation";

        protected override int LongestCommonSubsequence(string text1, string text2)
        {
            var m = text1.Length;
            var n = text2.Length;

            var resultsTable = new int[m + 1, n + 1];

            for (var i = 0; i <= m; i++)
            {
                for (var j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                        resultsTable[i, j] = 0;
                    else if (text1[i - 1] == text2[j - 1])
                        resultsTable[i, j] = resultsTable[i - 1, j - 1] + 1;
                    else
                        resultsTable[i, j] = Math.Max(resultsTable[i - 1, j], resultsTable[i, j - 1]);
                }
            }

            return resultsTable[m, n];
        }
    }
}