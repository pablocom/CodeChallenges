using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests
{
    public class LongestPalindromeTests
    {
        [Test]
        public void Test0()
        {
            var word = "a";

            var result = LongestPalindromeFinder.LongestPalindrome(word);

            Assert.That(result, Is.EqualTo("a"));
        }

        [Test]
        public void Test1()
        {
            var word = "babad";

            var result = LongestPalindromeFinder.LongestPalindrome(word);

            Assert.That(result, Is.EqualTo("aba").Or.EqualTo("bab"));
        }

        [Test]
        public void Test2()
        {
            var word = "abb";

            var result = LongestPalindromeFinder.LongestPalindrome(word);

            Assert.That(result, Is.EqualTo("bb"));
        }
    }
}