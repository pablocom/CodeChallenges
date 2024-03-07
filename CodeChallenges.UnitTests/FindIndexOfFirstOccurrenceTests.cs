using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class FindIndexOfFirstOccurrenceTests
{
    [Theory]
    [InlineData("aaa", "aaaa", -1)]
    public void Test1(string haystack, string needle, int expectedResult)
    {
        var solution = new FindIndexOfFirstOccurrence().StrStr(haystack, needle);

        solution.Should().Be(expectedResult);
    }
}