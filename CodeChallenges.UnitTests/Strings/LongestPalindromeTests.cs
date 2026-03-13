using CodeChallenges.Solutions.Strings;

namespace CodeChallenges.UnitTests.Strings;

public class LongestPalindromeTests
{
    [Fact]
    public void Test0()
    {
        var word = "a";

        var result = LongestPalindromeFinder.LongestPalindrome(word);

        result.ShouldBe("a");
    }

    [Fact]
    public void Test1()
    {
        var word = "babad";

        var result = LongestPalindromeFinder.LongestPalindrome(word);

        result.ShouldBeOneOf("aba", "bab");
    }

    [Fact]
    public void Test2()
    {
        var word = "abb";

        var result = LongestPalindromeFinder.LongestPalindrome(word);

        result.ShouldBe("bb");
    }
}