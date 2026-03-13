using CodeChallenges.Solutions.Strings;

namespace CodeChallenges.UnitTests.Strings;

public sealed class ValidPalindromeTests
{
    [Theory]
    [InlineData("bla bla 12 _ 21 alb alb", true)]
    [InlineData("bla bla 1 _ 1 zlb alb", false)]
    [InlineData("323_!", true)]
    [InlineData("323_!a", false)]
    [InlineData("123_!ab", false)]
    [InlineData("", true)]
    [InlineData("0P", false)]
    public void Test1(string text, bool isPalindrome)
    {
        var solution = ValidPalindrome.Solve(text);

        solution.ShouldBe(isPalindrome);
    }
}