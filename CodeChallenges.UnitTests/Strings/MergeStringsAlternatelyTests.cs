using CodeChallenges.Solutions.Strings;

namespace CodeChallenges.UnitTests.Strings;

public sealed class MergeStringsAlternatelyTests
{
    [Theory]
    [InlineData("abc", "pqr", "apbqcr")]
    [InlineData("ab", "pqrs", "apbqrs")]
    [InlineData("abcd", "pq", "apbqcd")]
    [InlineData("a", "b", "ab")]
    [InlineData("a", "bcd", "abcd")]
    [InlineData("", "bcd", "bcd")]
    public void Tests(string word1, string word2, string expected)
    {
        var result = MergeStringsAlternately.Solve(word1, word2);

        result.Should().Be(expected);
    }
}
