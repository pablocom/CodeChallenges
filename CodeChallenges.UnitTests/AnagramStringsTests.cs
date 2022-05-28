using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests;

public class AnagramStringsTests
{
    [Test]
    public void Test1()
    {
        var text1 = "pablo";
        var text2 = "blpao";

        var isAnagram = new AnagramStrings().IsAnagram(text1, text2);
            
        Assert.True((bool) isAnagram);
    }
}