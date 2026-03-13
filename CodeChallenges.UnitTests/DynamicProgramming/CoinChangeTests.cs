using CodeChallenges.Solutions.DynamicProgramming;

namespace CodeChallenges.UnitTests.DynamicProgramming;

public class CoinChangeTests
{
    [Theory]
    [InlineData(new[] { 1, 2, 5 }, 11,  3)]
    [InlineData(new[] { 2 },        3, -1)]
    [InlineData(new[] { 1 },        0,  0)]
    [InlineData(new[] { 1 },        1,  1)]
    [InlineData(new[] { 1 },        5,  5)]
    [InlineData(new[] { 5 },        5,  1)]
    [InlineData(new[] { 2 },        4,  2)]
    [InlineData(new[] { 3 },        7, -1)]
    [InlineData(new[] { 1, 2, 5 },  0,  0)]
    [InlineData(new[] { 1, 3, 4 },  6,  2)]
    [InlineData(new[] { 1, 5, 10 }, 12,  3)]
    [InlineData(new[] { 2, 5, 10 },  1, -1)]
    [InlineData(new[] { 186, 419, 83, 408 }, 6249, 20)]
    public void Solve(int[] coins, int amount, int expected) =>
        CoinChange.Solve(coins, amount).ShouldBe(expected);
}
