using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class LongestCommonPrefixTests
{
    [Fact]
    public void Test1()
    {
        var words = new[] {"hello", "hel", "h"};

        var solution = new LongestCommonPrefix().Solve(words);

        solution.Should().Be("h");
    }
    
    [Fact]
    public void Test2()
    {
        var words = new[] {"hello", "hel", "he"};

        var solution = new LongestCommonPrefix().Solve(words);
        
        solution.Should().Be("he");
    }
    
    
    [Fact]
    public void Test3()
    {
        var words = new[] {"", "hel", "he"};

        var solution = new LongestCommonPrefix().Solve(words);
        
        solution.Should().BeEmpty();
    }
}