using NUnit.Framework;

namespace CodeChallenges.LongestCommonSubsequence
{
    public class LongestCommonSubsequenceTests
    {
        [TestCase("abc", "abc", 3)]
        public void FindLongestCommonSubsquenceGivenTwoStrings(string text1, string text2, int expectedResult)
        {
            var solution = new Solution().LongestCommonSubsequence(text1, text2);

            Assert.That(solution, Is.EqualTo(expectedResult));
        }
    }
}