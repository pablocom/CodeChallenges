using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public sealed class LengthOfLastWordTests
{
    [Theory]
    [InlineData("Hello World", 5)]
    [InlineData("   fly me   to   the moon  ", 4)]
    [InlineData("luffy is still joyboy", 6)]
    [InlineData("a", 1)]
    [InlineData("today", 5)]
    [InlineData("hello world  ", 5)]
    public void Tests(string str, int expected)
    {
        var result = LengthOfLastWord.Solve(str);

        result.Should().Be(expected);
    }
}
