using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests
{
    public class ThreeSumClosestTests
    {
        [Test]
        public void Test1()
        {
            var array = new int[] { -1, 2, 1, -4 };
            var target = 1;

            var solution = new ThreeSumClosest().Solve(array, target);

            Assert.That(solution, Is.EqualTo(2));
        }

        [Test]
        public void Test2()
        {
            var array = new int[] { 0, 0, 0 };
            var target = 1;

            var solution = new ThreeSumClosest().Solve(array, target);

            Assert.That(solution, Is.EqualTo(0));
        }

        [Test]
        public void Test3()
        {
            var array = new int[] { 1, 1, 1, 0 };
            var target = 1;

            var solution = new ThreeSumClosest().Solve(array, target);

            Assert.That(solution, Is.EqualTo(2));
        }

        [Test]
        public void Test4()
        {
            var array = new int[] { 0, 2, 1, -3 };
            var target = 1;

            var solution = new ThreeSumClosest().Solve(array, target);

            Assert.That(solution, Is.EqualTo(0));
        }
    }
}
