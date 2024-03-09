using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class LongestSubsetTests
{
    [Fact]
    public void Test1()
    {
        var result = LongestSubset.SolveOptimized([-2, 1, 5, 8, 11], 3);
        result.Should().Be(3);
    }

    [Fact]
    public void Test2()
    {
        var result = LongestSubset.SolveOptimized([-2, 0, 1, 5, 8, 4, 11, 8, 12], 4);
        result.Should().Be(5);
    }

    [Fact]
    public void Test3()
    {
        var result = LongestSubset.SolveOptimized([1, 0, 1, 4, 8, 4, 2, 3, 2], 1);
        result.Should().Be(9);
    }

    [Fact]
    public void Test4()
    {
        var result = LongestSubset.SolveOptimized([1, 0, 1, 4, 6, 4, 2, 0, 3, 2], 2);
        result.Should().Be(7);
    }
}
