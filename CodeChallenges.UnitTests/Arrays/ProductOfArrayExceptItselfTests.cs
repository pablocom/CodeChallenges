using CodeChallenges.Solutions.Arrays;

namespace CodeChallenges.UnitTests.Arrays
{
    public class ProductOfArrayExceptItselfTests
    {
        [Fact]
        public void Test1()
        {
            var nums = new[] { 1, 2, 3, 4 };

            var solution = new ProductOfArrayExceptItself().ProductExceptSelf(nums);

            solution.Should().BeEquivalentTo([24, 12, 8, 6]);
        }
    }
}
