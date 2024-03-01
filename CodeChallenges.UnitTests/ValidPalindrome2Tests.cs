using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public sealed class ValidPalindrome2Tests
{
    [Theory]
    [InlineData("aba", true)]
    [InlineData("abac", true)]
    [InlineData("acbac", false)]
    [InlineData("cacbac", true)]
    [InlineData("abc", false)]
    public void Test1(string text, bool isPalindrome)
    {
        var solution = new ValidPalindrome2().Solve(text);

        solution.Should().Be(isPalindrome);
    }
}