using CodeChallenges.Solutions.Strings;

namespace CodeChallenges.UnitTests.Strings;

public class ReorganizeStringTests
{
    [Theory]
    [InlineData("aab", "aba")]
    [InlineData("aaab", "")]
    [InlineData("aaabbcc", "acbacba")]
    [InlineData("aaaaaabbcc", "")]
    public void ReorganizesTextSoNoEqualCharactersAreTogether(string text, string reorganizedText)
    {
        var result = ReorganizeString.Solve(text);
        
        result.Should().Be(reorganizedText);
    }
}