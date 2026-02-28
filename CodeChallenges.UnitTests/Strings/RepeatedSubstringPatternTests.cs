using CodeChallenges.Solutions.Strings;

namespace CodeChallenges.UnitTests.Strings;

public sealed class RepeatedSubstringPatternTests
{
    [Theory]
    [InlineData("bcdbcdbcdbcd", true)]
    [InlineData("abcdabcd", true)]
    [InlineData("aabaaba", false)]
    [InlineData("abab", true)]
    [InlineData("abcabc", true)]
    [InlineData("a", false)]
    [InlineData("aa", true)]
    [InlineData("ab", false)]
    [InlineData("aaa", true)]
    [InlineData("abcabcabc", true)]
    [InlineData("abac", false)]
    public void Tests(string s, bool expected)
    {
        var result = RepeatedSubstringPattern.Solve(s);

        result.Should().Be(expected);
    }
}
