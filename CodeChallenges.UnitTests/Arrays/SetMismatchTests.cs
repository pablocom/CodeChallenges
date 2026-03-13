using CodeChallenges.Solutions.Arrays;

namespace CodeChallenges.UnitTests.Arrays;

public sealed class SetMismatchTests
{
    [Theory]
    [InlineData(new[] { 1, 3, 3, 4 }, new[] { 3, 2 })]
    [InlineData(new[] { 2, 2, 3, 5, 4 }, new[] { 2, 1 })]
    [InlineData(new[] { 1, 5, 3, 2, 7, 7, 6 }, new[] { 7, 4 })]
    [InlineData(new[] { 1, 1 }, new[] { 1, 2 })]
    [InlineData(new[] { 2, 2 }, new[] { 2, 1 })]
    [InlineData(new[] { 1, 2, 3, 3 }, new[] { 3, 4 })]
    public void Tests(int[] nums, int[] expected)
    {
        var result = SetMismatch.Solve(nums);

        result.ShouldBe(expected);
    }
}
