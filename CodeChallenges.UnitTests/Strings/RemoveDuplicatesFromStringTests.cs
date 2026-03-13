using CodeChallenges.Solutions.Strings;

namespace CodeChallenges.UnitTests.Strings;

public class RemoveDuplicatesFromStringTests
{
    [Fact]
    public void Test1()
    {
        var text = "bcabc";

        var result = new RemoveDuplicatesFromString().RemoveDuplicateLetters(text);

        result.ShouldBe("abc");
    } 
        
    [Fact]
    public void Test2()
    {
        var text = "cbacdcbc";

        var result = new RemoveDuplicatesFromString().RemoveDuplicateLetters(text);

        result.ShouldBe("acdb");
    }
        
    [Fact]
    public void Test3()
    {
        var text = "cdadabcc";

        var result = new RemoveDuplicatesFromString().RemoveDuplicateLetters(text);

        result.ShouldBe("adbc");
    }
        
    [Fact]
    public void Test4()
    {
        var text = "leetcode";

        var result = new RemoveDuplicatesFromString().RemoveDuplicateLetters(text);

        result.ShouldBe("letcod");
    }
}