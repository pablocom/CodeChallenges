using CodeChallenges.Solutions.DynamicProgramming;

namespace CodeChallenges.UnitTests.DynamicProgramming;

public class LengthOfLongestIncreasingSubsequenceTests
{
    [Theory]
    [InlineData(new int[] { },                         0)]
    [InlineData(new[] { 7 },                           1)]
    [InlineData(new[] { 1, 2 },                        2)]
    [InlineData(new[] { 2, 1 },                        1)]
    [InlineData(new[] { 5, 4, 3, 2, 1 },               1)]
    [InlineData(new[] { 1, 2, 3, 4, 5 },               5)]
    [InlineData(new[] { 7, 7, 7, 7, 7 },               1)]
    [InlineData(new[] { 10, 9, 2, 5, 3, 7, 101, 18 },  4)]
    [InlineData(new[] { 0, 1, 0, 3, 2, 3 },            4)]
    [InlineData(new[] { 3, 10, 2, 1, 20 },             3)]
    [InlineData(new[] { 1, 3, 6, 7, 9, 4, 10, 5, 6 },  6)]
    [InlineData(new[] { -5, -3, -1, 0, 2 },            5)]
    [InlineData(new[] { -7, -2, -5, 0, -1, 3 },        4)]
    [InlineData(new[] { 4, 10, 4, 3, 8, 9 },           3)]
    [InlineData(new[] { 1, 2, 4, 3 },                  3)]
    public void Solve(int[] nums, int expected) =>
        LengthOfLongestIncreasingSubsequence.Solve(nums).Should().Be(expected);
}
