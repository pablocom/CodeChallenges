using NUnit.Framework;

namespace CodeChallenges.LongestCommonSubsequence
{
    public class LongestCommonSubsequenceTests
    {
        [TestCase("ACB", "AIB", 2)]
        [TestCase("AGGTAB", "GXTXAYB", 4)]
        [TestCase("ABCDGH", "AEDFHR", 3)]
        [TestCase("AGGTABOIBPOBBGXTXAY", "GXTXAYBAYBPOABAGGTAB", 8)]
        public void FindLongestCommonSubsquenceGivenTwoStrings(string text1, string text2, int expectedResult)
        {
            var bruteForceSolution = new BruteForceSolution().LongestCommonSubsequence(text1, text2);
            var tabulationSolution = new TabulationSolution().LongestCommonSubsequence(text1, text2, text1.Length, text2.Length);
            var memoizationSolution = new MemoizationSolution().LongestCommonSubsequence(text1, text2);

            Assert.That(bruteForceSolution, Is.EqualTo(expectedResult));
            Assert.That(tabulationSolution, Is.EqualTo(expectedResult));
            Assert.That(memoizationSolution, Is.EqualTo(expectedResult));   
        }
    }
}