using CodeChallenges.Solutions.Strings;

namespace CodeChallenges.UnitTests.Strings;

public sealed class IsSubsequenceTests
{
    [Theory]
    [InlineData("abc", "ahbgdc", true)]
    [InlineData("axc", "ahbgdc", false)]
    [InlineData("", "ahbgdc", true)]
    [InlineData("abc", "abc", true)]
    [InlineData("abc", "ab", false)]
    [InlineData("a", "a", true)]
    [InlineData("a", "b", false)]
    [InlineData("ace", "abcde", true)]
    [InlineData("aec", "abcde", false)]
    [InlineData("abc", "aabc", true)]
    public void Tests(string s, string t, bool expected)
    {
        var result = IsSubsequence.Solve(s, t);

        result.Should().Be(expected);
    }
}
