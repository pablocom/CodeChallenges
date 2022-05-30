using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests;

[TestFixture]
public class LongestCommonPrefixTests
{
    [Test]
    public void Test1()
    {
        var words = new[] {"hello", "hel", "h"};

        var solution = new LongestCommonPrefix().Solve(words);
        
        Assert.That(solution, Is.EqualTo("h"));
    }
    
    [Test]
    public void Test2()
    {
        var words = new[] {"hello", "hel", "he"};

        var solution = new LongestCommonPrefix().Solve(words);
        
        Assert.That(solution, Is.EqualTo("he"));
    }
    
    
    [Test]
    public void Test3()
    {
        var words = new[] {"", "hel", "he"};

        var solution = new LongestCommonPrefix().Solve(words);
        
        Assert.That(solution, Is.EqualTo(string.Empty));
    }
}