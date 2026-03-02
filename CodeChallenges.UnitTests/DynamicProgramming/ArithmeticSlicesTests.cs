using CodeChallenges.Solutions.DynamicProgramming;

namespace CodeChallenges.UnitTests.DynamicProgramming;

public class ArithmeticSlicesTests
{
    [Theory]
    [InlineData(new[] { 1, 2 },          0)]
    [InlineData(new[] { 1, 2, 3 },       1)]
    [InlineData(new[] { 1, 2, 3, 4 },    3)]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 6)]
    [InlineData(new[] { 1, 2, 3, 1, 2 }, 1)]
    public void Solve(int[] nums, int expected) =>
        ArithmeticSlices.Solve(nums).Should().Be(expected);
}
