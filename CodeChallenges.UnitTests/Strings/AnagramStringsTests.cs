using CodeChallenges.Solutions.Strings;


namespace CodeChallenges.UnitTests.Strings;

public class AnagramStringsTests
{
    [Fact]
    public void Test1()
    {
        var text1 = "pablo";
        var text2 = "blpao";

        var isAnagram = new AnagramStrings().IsAnagram(text1, text2);

        isAnagram.ShouldBeTrue();
    }
}