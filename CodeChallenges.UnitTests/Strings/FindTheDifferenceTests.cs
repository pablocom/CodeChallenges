using CodeChallenges.Solutions.Strings;

namespace CodeChallenges.UnitTests.Strings;

public sealed class FindTheDifferenceTests
{
    [Theory]
    [InlineData("abcd", "abcde", 'e')]
    [InlineData("", "y", 'y')]
    [InlineData("a", "aa", 'a')]
    [InlineData("ae", "aea", 'a')]
    [InlineData("abcde", "abcdef", 'f')]
    public void SolveWithDictionary(string s, string t, char expected)
    {
        var result = FindTheDifference.SolveWithDictionary(s, t);

        result.ShouldBe(expected);
    }

    [Theory]
    [InlineData("abcd", "abcde", 'e')]
    [InlineData("", "y", 'y')]
    [InlineData("a", "aa", 'a')]
    [InlineData("ae", "aea", 'a')]
    [InlineData("abcde", "abcdef", 'f')]
    public void SolveWithXor(string s, string t, char expected)
    {
        var result = FindTheDifference.SolveWithXor(s, t);

        result.ShouldBe(expected);
    }
}
