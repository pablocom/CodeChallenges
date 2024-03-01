using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests
{
    public class ThreeSumClosestTests
    {
        [Fact]
        public void Test1()
        {
            var array = new int[] { -1, 2, 1, -4 };
            var target = 1;

            var solution = new ThreeSumClosest().Solve(array, target);

            solution.Should().Be(2);
        }

        [Fact]
        public void Test2()
        {
            var array = new int[] { 0, 0, 0 };
            var target = 1;

            var solution = new ThreeSumClosest().Solve(array, target);

            solution.Should().Be(0);
        }

        [Fact]
        public void Test3()
        {
            var array = new int[] { 1, 1, 1, 0 };
            var target = 1;

            var solution = new ThreeSumClosest().Solve(array, target);

            solution.Should().Be(2);
        }

        [Fact]
        public void Test4()
        {
            var array = new int[] { 0, 2, 1, -3 };
            var target = 1;

            var solution = new ThreeSumClosest().Solve(array, target);

            solution.Should().Be(0);
        }
    }
}
