using NUnit.Framework;

namespace CodeChallenges.LongestPalindrome
{
    public class LongestPalindromeTests
    {
        [Test]
        public void Test0()
        {
            var word = "a";

            var result = Solution.LongestPalindrome(word);

            Assert.That(result, Is.EqualTo("a"));
        }

        [Test]
        public void Test1()
        {
            var word = "babad";

            var result = Solution.LongestPalindrome(word);

            Assert.That(result, Is.EqualTo("aba").Or.EqualTo("bab"));
        }

        [Test]
        public void Test2()
        {
            var word = "abb";

            var result = Solution.LongestPalindrome(word);

            Assert.That(result, Is.EqualTo("bb"));
        }
    }
}