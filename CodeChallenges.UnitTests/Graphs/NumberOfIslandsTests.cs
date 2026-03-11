using CodeChallenges.Solutions.Graphs;

namespace CodeChallenges.UnitTests.Graphs;

public class NumberOfIslandsTests
{
    [Fact]
    public void SingleIsland()
    {
        var grid = new[]
        {
            new[] { '1', '1', '1', '1', '0' },
            new[] { '1', '1', '0', '1', '0' },
            new[] { '1', '1', '0', '0', '0' },
            new[] { '0', '0', '0', '0', '0' },
        };

        NumberOfIslands.Solve(grid).Should().Be(1);
    }

    [Fact]
    public void ThreeIslands()
    {
        var grid = new[]
        {
            new[] { '1', '1', '0', '0', '0' },
            new[] { '1', '1', '0', '0', '0' },
            new[] { '0', '0', '1', '0', '0' },
            new[] { '0', '0', '0', '1', '1' },
        };

        NumberOfIslands.Solve(grid).Should().Be(3);
    }

    [Fact]
    public void NoIslands()
    {
        var grid = new[]
        {
            new[] { '0', '0' },
            new[] { '0', '0' },
        };

        NumberOfIslands.Solve(grid).Should().Be(0);
    }

    [Fact]
    public void AllLand()
    {
        var grid = new[]
        {
            new[] { '1', '1' },
            new[] { '1', '1' },
        };

        NumberOfIslands.Solve(grid).Should().Be(1);
    }

    [Fact]
    public void DiagonalIslandsAreNotConnected()
    {
        var grid = new[]
        {
            new[] { '1', '0' },
            new[] { '0', '1' },
        };

        NumberOfIslands.Solve(grid).Should().Be(2);
    }

    [Fact]
    public void SingleCellIsland()
    {
        var grid = new[]
        {
            new[] { '1' },
        };

        NumberOfIslands.Solve(grid).Should().Be(1);
    }
}
