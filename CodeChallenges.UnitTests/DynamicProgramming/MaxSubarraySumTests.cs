using CodeChallenges.Solutions.DynamicProgramming;

namespace CodeChallenges.UnitTests.DynamicProgramming;

public class MaxSubarraySumTests
{
    [Theory]
    [InlineData(new[] { 5 },                                  5)]
    [InlineData(new[] { -1 },                                -1)]
    [InlineData(new[] { 0 },                                  0)]
    [InlineData(new[] { 1, 2, 3 },                            6)]
    [InlineData(new[] { -3, -2, -1 },                        -1)]
    [InlineData(new[] { -5, -1, -3 },                        -1)]
    [InlineData(new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 },     6)]
    [InlineData(new[] { -2, -1, 3 },                          3)]
    [InlineData(new[] { -1, 3, -1, 3, -1 },                   5)]
    [InlineData(new[] { -5, -2, 3, 4 },                       7)]
    [InlineData(new[] { 3, 4, -5, -2 },                       7)]
    [InlineData(new[] { -10000, 10000 },                   10000)]
    [InlineData(new[] { 5, -100, 5 },                         5)]
    [InlineData(new[] { 5, -1, 5 },                           9)]
    [InlineData(new[] { 3, -10, 3 },                          3)]
    [InlineData(new[] { -10000, -10000 },                 -10000)]
    public void Solve(int[] nums, int expected) =>
        MaxSubarraySum.Solve(nums).Should().Be(expected);
}
