using NUnit.Framework;

namespace CodeChallenges.FindAndReplaceString
{
    public class FindAndReplaceStringTests
    {
        [Test]
        public void Test1()
        {
            var inputString = "abcd";
            var indexes = new[] {0, 2};
            var sources = new[] { "a", "cd" };
            var targets = new[] { "eee", "ffff" };

            var result = new Solution()
                .FindReplaceString(inputString, indexes, sources, targets);

            Assert.That(result, Is.EqualTo("eeebffff"));
        }

        [Test]
        public void Test2()
        {
            var inputString = "abcd";
            var indexes = new[] { 0, 2 };
            var sources = new[] { "ab", "ec" };
            var targets = new[] { "eee", "ffff" };

            var result = new Solution()
                .FindReplaceString(inputString, indexes, sources, targets);

            Assert.That(result, Is.EqualTo("eeecd"));
        }

        [Test]
        public void Test3()
        {
            var inputString = "abcd";
            var indexes = new[] { 2, 0 };
            var sources = new[] { "cd", "a" };
            var targets = new[] { "ffff", "eee" };

            var result = new Solution()
                .FindReplaceString(inputString, indexes, sources, targets);

            Assert.That(result, Is.EqualTo("eeebffff"));
        }
    }
}