using System;
using System.Diagnostics;

namespace CodeChallenges.LongestCommonSubsequence
{
    public class TabulationSolution
    {
        
        public int LongestCommonSubsequence(string X, string Y, int m, int n)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Restart();

            var resultsTable = new int[m + 1, n + 1];

            for (var i = 0; i <= m; i++)
            {
                for (var j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                        resultsTable[i, j] = 0;
                    else if (X[i - 1] == Y[j - 1])
                        resultsTable[i, j] = resultsTable[i - 1, j - 1] + 1;
                    else
                        resultsTable[i, j] = Math.Max(resultsTable[i - 1, j], resultsTable[i, j - 1]);
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"Tabulation: {stopwatch.Elapsed}");

            return resultsTable[m, n];
        }
    }
}