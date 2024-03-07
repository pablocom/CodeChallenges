using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class ForSumTests
{
    [Fact]
    public void Test()
    {
        int[] input = [1, 0, -1, 0, -2, 2];
        var target = 0;

        var solution = new FourSum().Solve(input, target);

        solution.Should().BeEquivalentTo(new int[][] { [-2, -1, 1, 2], [-2, 0, 0, 2], [-1, 0, 0, 1] });
    }
    
    [Fact]
    public void Test2()
    {
        int[] input = [2, 2, 2, 2, 2];
        var target = 8;

        var solution = new FourSum().Solve(input, target);

        solution.Should().BeEquivalentTo(new int[][] { [2, 2, 2, 2] });
    }
}