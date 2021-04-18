using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests
{
    public class LongestSubsetTests
    {
        [Test]
        public void Test1()
        {
            var result = LongestSubset.SolveOptimized(new[] { -2, 1, 5, 8, 11 }, 3);
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Test2()
        {
            var result = LongestSubset.SolveOptimized(new[] { -2, 0, 1, 5, 8, 4, 11, 8, 12 }, 4);
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Test3()
        {
            var result = LongestSubset.SolveOptimized(new[] { 1, 0, 1, 4, 8, 4, 2, 3, 2 }, 1);
            Assert.That(result, Is.EqualTo(9));
        }

        [Test]
        public void Test4()
        {
            var result = LongestSubset.SolveOptimized(new[] { 1, 0, 1, 4, 6, 4, 2, 0, 3, 2 }, 2);
            Assert.That(result, Is.EqualTo(7));
        }
    }
}