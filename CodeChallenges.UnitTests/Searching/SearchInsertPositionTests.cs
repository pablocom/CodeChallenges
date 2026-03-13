using CodeChallenges.Solutions.Searching;

namespace CodeChallenges.UnitTests.Searching;

public sealed class SearchInsertPositionTests
{
    [Theory]
    [InlineData(new[] { 2, 4, 6, 8, 10 }, 1, 0)]
    [InlineData(new[] { 1, 3, 7, 9, 11 }, 10, 4)]
    [InlineData(new[] { 5, 8, 12 }, 12, 2)]
    [InlineData(new[] { 1, 3, 5, 6 }, 5, 2)]
    [InlineData(new[] { 1, 3, 5, 6 }, 2, 1)]
    [InlineData(new[] { 1, 3, 5, 6 }, 7, 4)]
    [InlineData(new[] { 1, 3, 5, 6 }, 0, 0)]
    [InlineData(new[] { 1 }, 1, 0)]
    [InlineData(new[] { 1, 3 }, 3, 1)]
    [InlineData(new[] { 1, 3, 5 }, 4, 2)]
    public void Tests(int[] nums, int target, int expected)
    {
        var result = SearchInsertPosition.Solve(nums, target);

        result.ShouldBe(expected);
    }
}
