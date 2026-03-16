using CodeChallenges.Solutions.DynamicProgramming;

namespace CodeChallenges.UnitTests.DynamicProgramming;

public class MinimumPathSumTests
{
    [Fact]
    public void SingleCell_ReturnsThatValue()
    {
        int[][] grid = [[5]];
        MinimumPathSum.Solve(grid).ShouldBe(5);
    }

    [Fact]
    public void SingleRow_ReturnsSumOfAllCells()
    {
        int[][] grid = [[1, 2, 3]];
        MinimumPathSum.Solve(grid).ShouldBe(6);
    }

    [Fact]
    public void SingleColumn_ReturnsSumOfAllCells()
    {
        int[][] grid = [[1], [2], [3]];
        MinimumPathSum.Solve(grid).ShouldBe(6);
    }

    [Fact]
    public void LeetCodeExample1()
    {
        int[][] grid = [[1, 3, 1], [1, 5, 1], [4, 2, 1]];
        MinimumPathSum.Solve(grid).ShouldBe(7);
    }

    [Fact]
    public void LeetCodeExample2()
    {
        int[][] grid = [[1, 2, 3], [4, 5, 6]];
        MinimumPathSum.Solve(grid).ShouldBe(12);
    }

    [Fact]
    public void AllZeros_ReturnsZero()
    {
        int[][] grid = [[0, 0], [0, 0]];
        MinimumPathSum.Solve(grid).ShouldBe(0);
    }

    [Fact]
    public void PreferGoingDownOverRight()
    {
        // Down path: 1+1+1 = 3, Right path: 1+9+1 = 11
        int[][] grid = [[1, 9], [1, 1], [1, 1]];
        MinimumPathSum.Solve(grid).ShouldBe(4);
    }

    [Fact]
    public void PreferGoingRightOverDown()
    {
        // Right path: 1+1+1 = 3, Down path: 1+9+1 = 11
        int[][] grid = [[1, 1, 1], [9, 9, 1]];
        MinimumPathSum.Solve(grid).ShouldBe(4);
    }
}
