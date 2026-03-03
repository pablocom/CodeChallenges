using CodeChallenges.Solutions.Arrays;

namespace CodeChallenges.UnitTests.Arrays;

public class SubarraySumEqualKTests
{
    [Theory]
    [InlineData(new[] { 1, 1, 1 }, 2, 2)]
    [InlineData(new[] { 1, 2, 3 }, 3, 2)]
    [InlineData(new[] { 1 },       1, 1)]
    [InlineData(new[] { 1 },       2, 0)]
    [InlineData(new[] { -1, -1, 1 }, -1, 3)]
    public void Solve(int[] nums, int k, int expected) =>
        SubarraySumEqualK.Solve(nums, k).Should().Be(expected);
}
