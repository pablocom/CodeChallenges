using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class LongestPalindromeTests
{
    [Fact]
    public void Test0()
    {
        var word = "a";

        var result = LongestPalindromeFinder.LongestPalindrome(word);

        result.Should().Be("a");
    }

    [Fact]
    public void Test1()
    {
        var word = "babad";

        var result = LongestPalindromeFinder.LongestPalindrome(word);

        result.Should().Match(x => x == "aba" || x == "bab");
    }

    [Fact]
    public void Test2()
    {
        var word = "abb";

        var result = LongestPalindromeFinder.LongestPalindrome(word);

        result.Should().Be("bb");
    }
}