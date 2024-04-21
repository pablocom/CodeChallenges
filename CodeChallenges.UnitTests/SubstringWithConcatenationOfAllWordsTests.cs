using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class SubstringWithConcatenationOfAllWordsTests
{
    [Fact]
    public void Test1()
    {
        var result = new SubstringWithConcatenationOfAllWords().FindSubstring("barfoothefoobarman", ["foo", "bar"]);
        result.Should().Equal([0, 9]);
    }
}
