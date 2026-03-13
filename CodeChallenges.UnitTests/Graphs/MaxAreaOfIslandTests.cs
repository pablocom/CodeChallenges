using CodeChallenges.Solutions.Graphs;

namespace CodeChallenges.UnitTests.Graphs;

public class MaxAreaOfIslandTests
{
    [Fact]
    public void LeetCodeExample_ReturnsLargestIsland()
    {
        var grid = new[]
        {
            new[] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            new[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
            new[] { 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            new[] { 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0 },
            new[] { 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0 },
            new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
            new[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
            new[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
        };

        MaxAreaOfIsland.Solve(grid).ShouldBe(6);
    }

    [Fact]
    public void NoIslands_ReturnsZero()
    {
        var grid = new[]
        {
            new[] { 0, 0, 0 },
            new[] { 0, 0, 0 },
        };

        MaxAreaOfIsland.Solve(grid).ShouldBe(0);
    }

    [Fact]
    public void SingleCellIsland()
    {
        var grid = new[]
        {
            new[] { 0, 1, 0 },
            new[] { 0, 0, 0 },
        };

        MaxAreaOfIsland.Solve(grid).ShouldBe(1);
    }

    [Fact]
    public void EntireGridIsOneIsland()
    {
        var grid = new[]
        {
            new[] { 1, 1 },
            new[] { 1, 1 },
        };

        MaxAreaOfIsland.Solve(grid).ShouldBe(4);
    }

    [Fact]
    public void DiagonalCellsAreNotConnected()
    {
        var grid = new[]
        {
            new[] { 1, 0 },
            new[] { 0, 1 },
        };

        MaxAreaOfIsland.Solve(grid).ShouldBe(1);
    }

    [Fact]
    public void MultipleIslands_ReturnsLargest()
    {
        var grid = new[]
        {
            new[] { 1, 1, 0, 0, 0 },
            new[] { 1, 1, 0, 0, 0 },
            new[] { 0, 0, 0, 1, 1 },
            new[] { 0, 0, 0, 1, 1 },
            new[] { 0, 0, 0, 1, 1 },
        };

        MaxAreaOfIsland.Solve(grid).ShouldBe(6);
    }

    [Fact]
    public void LShapedIsland()
    {
        var grid = new[]
        {
            new[] { 1, 0, 0 },
            new[] { 1, 0, 0 },
            new[] { 1, 1, 1 },
        };

        MaxAreaOfIsland.Solve(grid).ShouldBe(5);
    }
}
