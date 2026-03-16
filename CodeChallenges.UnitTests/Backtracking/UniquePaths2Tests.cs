using CodeChallenges.Solutions.Backtracking;

namespace CodeChallenges.UnitTests.Backtracking;

public class UniquePaths2Tests
{
    [Fact]
    public void NoObstacles_ReturnsAllPaths()
    {
        int[][] grid = [[0, 0, 0], [0, 0, 0], [0, 0, 0]];
        UniquePaths2.UniquePathsWithObstacles(grid).ShouldBe(6);
    }

    [Fact]
    public void ObstacleBlocksAllPaths_ReturnsZero()
    {
        int[][] grid = [[0, 1], [1, 0]];
        UniquePaths2.UniquePathsWithObstacles(grid).ShouldBe(0);
    }

    [Fact]
    public void ObstacleAtStart_ReturnsZero()
    {
        int[][] grid = [[1, 0], [0, 0]];
        UniquePaths2.UniquePathsWithObstacles(grid).ShouldBe(0);
    }

    [Fact]
    public void ObstacleAtEnd_ReturnsZero()
    {
        int[][] grid = [[0, 0], [0, 1]];
        UniquePaths2.UniquePathsWithObstacles(grid).ShouldBe(0);
    }

    [Fact]
    public void SingleCell_NoObstacle_ReturnsOne()
    {
        int[][] grid = [[0]];
        UniquePaths2.UniquePathsWithObstacles(grid).ShouldBe(1);
    }

    [Fact]
    public void SingleCell_WithObstacle_ReturnsZero()
    {
        int[][] grid = [[1]];
        UniquePaths2.UniquePathsWithObstacles(grid).ShouldBe(0);
    }

    [Fact]
    public void ObstacleInMiddle_ReducesPaths()
    {
        int[][] grid = [[0, 0, 0], [0, 1, 0], [0, 0, 0]];
        UniquePaths2.UniquePathsWithObstacles(grid).ShouldBe(2);
    }

    [Fact]
    public void SingleRow_NoObstacles_ReturnsOne()
    {
        int[][] grid = [[0, 0, 0]];
        UniquePaths2.UniquePathsWithObstacles(grid).ShouldBe(1);
    }

    [Fact]
    public void SingleColumn_NoObstacles_ReturnsOne()
    {
        int[][] grid = [[0], [0], [0]];
        UniquePaths2.UniquePathsWithObstacles(grid).ShouldBe(1);
    }

    [Fact]
    public void LeetCodeExample1()
    {
        int[][] grid = [[0, 0, 0], [0, 1, 0], [0, 0, 0]];
        UniquePaths2.UniquePathsWithObstacles(grid).ShouldBe(2);
    }

    [Fact]
    public void LeetCodeExample2()
    {
        int[][] grid = [[0, 1], [0, 0]];
        UniquePaths2.UniquePathsWithObstacles(grid).ShouldBe(1);
    }
}
