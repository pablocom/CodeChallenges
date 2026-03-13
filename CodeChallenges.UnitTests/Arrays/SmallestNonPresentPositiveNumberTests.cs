using CodeChallenges.Solutions.Arrays;

namespace CodeChallenges.UnitTests.Arrays
{
    public class SmallestNonPresentPositiveNumberTests
    {
        [Fact]
        public void Test1()
        {
            var array = new[] { 1, 3, 6, 4, 1, 2 };

            var solution = new SmallestNonPresentPositiveNumber().Solution(array);

            solution.ShouldBe(5);
        }
    }
}
