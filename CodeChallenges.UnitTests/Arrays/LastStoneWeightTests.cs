using CodeChallenges.Solutions.Arrays;

namespace CodeChallenges.UnitTests.Arrays;

public class LastStoneWeightTests
{
    [Theory]
    [InlineData(new[] { 2, 7, 4, 1, 8, 1 }, 1)]
    [InlineData(new[] { 1 },                 1)]
    [InlineData(new[] { 2, 2 },              0)]
    [InlineData(new[] { 3, 7, 2 },           2)]
    [InlineData(new[] { 1, 3, 5, 7, 9 },     1)]
    [InlineData(new[] { 10, 10, 10, 10 },    0)]
    public void Solve(int[] stones, int expected) =>
        LastStoneWeight.Solve(stones).Should().Be(expected);
}
