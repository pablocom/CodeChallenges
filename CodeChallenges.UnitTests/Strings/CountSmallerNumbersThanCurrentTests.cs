using CodeChallenges.Solutions.Strings;

namespace CodeChallenges.UnitTests.Strings;

public sealed class CountSmallerNumbersThanCurrentTests
{
    [Theory]
    [InlineData(new[] { 8, 1, 2, 2, 3 }, new[] { 4, 0, 1, 1, 3 })]
    [InlineData(new[] { 6, 5, 4, 8 }, new[] { 2, 1, 0, 3 })]
    [InlineData(new[] { 7, 7, 7, 7 }, new[] { 0, 0, 0, 0 })]
    [InlineData(new[] { 0 }, new[] { 0 })]
    [InlineData(new[] { 5, 0, 10 }, new[] { 1, 0, 2 })]
    public void Tests(int[] nums, int[] expected)
    {
        var result = CountSmallerNumbersThanCurrent.Solve(nums);

        result.Should().Equal(expected);
    }
}
