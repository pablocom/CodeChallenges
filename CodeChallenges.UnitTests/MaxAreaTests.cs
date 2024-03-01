using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class MaxAreaTests
{
    [Fact]
    public void Test1()
    {
        var heights = new[] {1, 1};

        var solution = new MaxArea().Solve(heights);

        solution.Should().Be(1);
    }
    
    [Fact]
    public void Test2()
    {
        var heights = new[] {2, 1};

        var solution = new MaxArea().Solve(heights);
        
        solution.Should().Be(1);
    }
    
    [Fact]
    public void Test3()
    {
        var heights = new[] {2, 1, 2};

        var solution = new MaxArea().Solve(heights);
        
        solution.Should().Be(4);
    }
    
    [Fact]
    public void Test4()
    {
        var heights = new[] {1, 2, 1, 2};

        var solution = new MaxArea().Solve(heights);
        
        solution.Should().Be(4);
    }
    
    [Fact]
    public void Test5()
    {
        var heights = new[] {1,8,6,2,5,4,8,3,7};

        var solution = new MaxArea().Solve(heights);
        
        solution.Should().Be(49);
    }
    
    [Fact]
    public void Test6()
    {
        var heights = new[] {1, 2, 1};

        var solution = new MaxArea().Solve(heights);
        
        solution.Should().Be(2);
    }
}