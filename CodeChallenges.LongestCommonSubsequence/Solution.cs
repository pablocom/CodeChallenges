using System;
using System.Diagnostics;

namespace CodeChallenges.LongestCommonSubsequence
{
    public abstract class Solution
    {
        protected abstract string SolutionName { get; }
        private readonly Stopwatch stopwatch;

        protected Solution()
        {
            stopwatch = new Stopwatch();
        }

        public int CalculateWithPerformanceTrackingLongestCommonSubsequence(string text1, string text2)
        {
            stopwatch.Restart();

            var result = this.LongestCommonSubsequence(text1, text2);
            Console.WriteLine($"{SolutionName}: {stopwatch.Elapsed}");

            return result;
        }

        protected abstract int LongestCommonSubsequence(string text1, string text2);
    }
}