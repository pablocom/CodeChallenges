using CodeChallenges.Solutions.Arrays;

namespace CodeChallenges.UnitTests.Arrays;

public class MinDifferenceTests
{
    [Theory]
    [InlineData(new[] { 5, 3, 2, 4 },             0)]
    [InlineData(new[] { 1, 5, 0, 10, 14 },         1)]
    [InlineData(new[] { 3, 100, 20 },              0)]
    [InlineData(new[] { 6, 6, 0, 1, 1, 4, 6 },     2)]
    [InlineData(new[] { 1, 5, 6, 14, 15 },         1)]
    public void Solve(int[] nums, int expected) =>
        MinDifference.Solve(nums).ShouldBe(expected);
}
