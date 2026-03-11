using CodeChallenges.Solutions.DynamicProgramming;

namespace CodeChallenges.UnitTests.DynamicProgramming;

public class LongestValidParenthesesTests
{
    private readonly LongestValidParentheses _sut = new();

    [Theory]
    [InlineData("(()",    2)]
    [InlineData(")()())", 4)]
    [InlineData("",       0)]
    [InlineData("()()",   4)]
    [InlineData("()(())", 6)]
    [InlineData("(((",    0)]
    [InlineData(")))",    0)]
    [InlineData("()",     2)]
    public void Solve(string input, int expected) =>
        _sut.Solve(input).Should().Be(expected);
}
