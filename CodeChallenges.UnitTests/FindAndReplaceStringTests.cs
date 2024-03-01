using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class FindAndReplaceStringTests
{
    [Fact]
    public void Test1()
    {
        var inputString = "abcd";
        var indexes = new[] {0, 2};
        var sources = new[] { "a", "cd" };
        var targets = new[] { "eee", "ffff" };

        var result = new FindAndReplaceString().FindReplaceString(inputString, indexes, sources, targets);

        result.Should().Be("eeebffff");
    }

    [Fact]
    public void Test2()
    {
        var inputString = "abcd";
        var indexes = new[] { 0, 2 };
        var sources = new[] { "ab", "ec" };
        var targets = new[] { "eee", "ffff" };

        var result = new FindAndReplaceString().FindReplaceString(inputString, indexes, sources, targets);

        result.Should().Be("eeecd");
    }

    [Fact]
    public void Test3()
    {
        var inputString = "abcd";
        var indexes = new[] { 2, 0 };
        var sources = new[] { "cd", "a" };
        var targets = new[] { "ffff", "eee" };

        var result = new FindAndReplaceString().FindReplaceString(inputString, indexes, sources, targets);

        result.Should().Be("eeebffff");
    }
}