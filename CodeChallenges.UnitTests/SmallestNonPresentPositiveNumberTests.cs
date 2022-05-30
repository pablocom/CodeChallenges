
using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests
{
    public class SmallestNonPresentPositiveNumberTests
    {
        [Test]
        public void Test1()
        {
            var array = new[] { 1, 3, 6, 4, 1, 2 };

            var solution = new SmallestNonPresentPositiveNumber().Solution(array);

            Assert.That(solution, Is.EqualTo(5));
        }
    }
}
