using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests;

public class MaxAreaTests
{
    [Test]
    public void Test1()
    {
        var heights = new[] {1, 1};

        var solution = new MaxArea().Solve(heights);
        
        Assert.That(solution, Is.EqualTo(1));
    }
    
    [Test]
    public void Test2()
    {
        var heights = new[] {2, 1};

        var solution = new MaxArea().Solve(heights);
        
        Assert.That(solution, Is.EqualTo(1));
    }
    
    [Test]
    public void Test3()
    {
        var heights = new[] {2, 1, 2};

        var solution = new MaxArea().Solve(heights);
        
        Assert.That(solution, Is.EqualTo(4));
    }
    
    [Test]
    public void Test4()
    {
        var heights = new[] {1, 2, 1, 2};

        var solution = new MaxArea().Solve(heights);
        
        Assert.That(solution, Is.EqualTo(4));
    }
    
    [Test]
    public void Test5()
    {
        var heights = new[] {1,8,6,2,5,4,8,3,7};

        var solution = new MaxArea().Solve(heights);
        
        Assert.That(solution, Is.EqualTo(49));
    }
    
    [Test]
    public void Test6()
    {
        var heights = new[] {1, 2, 1};

        var solution = new MaxArea().Solve(heights);
        
        Assert.That(solution, Is.EqualTo(2));
    }
}