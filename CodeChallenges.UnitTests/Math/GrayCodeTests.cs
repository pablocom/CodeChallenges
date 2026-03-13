using CodeChallenges.Solutions.Mathematics;

namespace CodeChallenges.UnitTests.Math;

public class GrayCodeTests
{
    [Theory]
    [InlineData(0, new[] { 0 })]
    [InlineData(1, new[] { 0, 1 })]
    [InlineData(2, new[] { 0, 1, 3, 2 })]
    [InlineData(3, new[] { 0, 1, 3, 2, 6, 7, 5, 4 })]
    [InlineData(4, new[] { 0, 1, 3, 2, 6, 7, 5, 4, 12, 13, 15, 14, 10, 11, 9, 8 })]
    public void Tests(int n, int[] expected)
    {
        var result = GrayCode.Solve(n);
        
        result.ShouldBe(expected);
    }
}
