using CodeChallenges.Solutions.Strings;

namespace CodeChallenges.UnitTests.Strings;

public class LongestCommonPrefixTests
{
    [Fact]
    public void Test1()
    {
        var words = new[] {"hello", "hel", "h"};

        var solution = new LongestCommonPrefix().Solve(words);

        solution.ShouldBe("h");
    }
    
    [Fact]
    public void Test2()
    {
        var words = new[] {"hello", "hel", "he"};

        var solution = new LongestCommonPrefix().Solve(words);
        
        solution.ShouldBe("he");
    }
    
    
    [Fact]
    public void Test3()
    {
        var words = new[] {"", "hel", "he"};

        var solution = new LongestCommonPrefix().Solve(words);
        
        solution.ShouldBeEmpty();
    }
}