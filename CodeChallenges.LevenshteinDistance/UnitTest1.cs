using System.Linq;
using CodeChallenges.LongestCommonSubsequence;
using NUnit.Framework;

namespace CodeChallenges.LevenshteinDistance
{
    public class LevenshteinDistanceTests
    {
        [TestCase("pablo", "company", 6)]
        [TestCase("zoologicoarchaeologist", "zoogeologist", 10)]
        public void Test1(string originalString, string destinationString, int expectedResult)
        {
            var result = new Solution().LevenshteinDistance(originalString, destinationString);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }

    public class Solution
    {
        public int LevenshteinDistance(string originalString, string destinationString)
        {
            var computedResults = new int[originalString.Length + 1, destinationString.Length + 1];

            for (var i = 0; i <= originalString.Length; i++)
            for (var j = 0; j <= destinationString.Length; j++)
            {
                if (i == 0)
                {
                    computedResults[i, j] = j;
                    continue;
                }

                if (j == 0)
                {
                    computedResults[i, j] = i;
                    continue;
                }

                if (originalString[i - 1] == destinationString[j - 1])
                    computedResults[i, j] = computedResults[i - 1, j - 1];
                else
                    computedResults[i, j] = 1 + new[]
                        {computedResults[i - 1, j], computedResults[i - 1, j - 1], computedResults[i, j - 1]}.Min();
            }

            MatrixExtensions.Print2DArray(computedResults);

            return computedResults[originalString.Length, destinationString.Length];
        }
    }
}