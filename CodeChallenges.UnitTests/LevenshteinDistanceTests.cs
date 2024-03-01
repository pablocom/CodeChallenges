using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class LevenshteinDistanceTests
{
    [Theory]
    [InlineData("pablo", "company", 6)]
    [InlineData("zoologicoarchaeologist", "zoogeologist", 10)]
    public void Test1(string originalString, string destinationString, int expected)
    {
        var result = new LevenshteinDistanceSolution().LevenshteinDistance(originalString, destinationString);

        result.Should().Be(expected);
    }
}