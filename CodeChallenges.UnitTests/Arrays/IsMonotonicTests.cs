using CodeChallenges.Solutions.Arrays;

namespace CodeChallenges.UnitTests.Arrays;

public sealed class IsMonotonicTests
{
    [Theory]
    [InlineData(new[] { 1, 2, 2, 3 }, true)]
    [InlineData(new[] { 6, 5, 4, 4 }, true)]
    [InlineData(new[] { 1, 3, 2 }, false)]
    [InlineData(new[] { 1, 1, 1 }, true)]
    [InlineData(new[] { 1 }, true)]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, true)]
    [InlineData(new[] { 5, 4, 3, 2, 1 }, true)]
    [InlineData(new[] { 1, 2, 3, 2, 1 }, false)]
    [InlineData(new[] { 3, 3, 3, 2, 1 }, true)]
    [InlineData(new[] { 1, 1, 2, 3, 3 }, true)]
    public void Tests(int[] nums, bool expected)
    {
        var result = IsMonotonic.Solve(nums);

        result.ShouldBe(expected);
    }
}
