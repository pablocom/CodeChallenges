using CodeChallenges.Solutions.Graphs;

namespace CodeChallenges.UnitTests.Graphs;

public class DetonateMaximumBombsTests
{
    [Theory]
    [MemberData(nameof(GetBombTestCases))]
    public void Tests(int[][] bombs, int expected)
    {
        var result = DetonateMaximumBombs.Solve(bombs);

        result.Should().Be(expected);
    }

    public static IEnumerable<object[]> GetBombTestCases()
    {
        yield return new object[]
        {
            new int[][] { new[] { 2, 1, 3 }, new[] { 6, 1, 4 } },
            2
        };

        yield return new object[]
        {
            new int[][] { new[] { 1, 1, 5 }, new[] { 10, 10, 5 } },
            1
        };

        yield return new object[]
        {
            new int[][]
            {
                new[] { 1, 2, 3 },
                new[] { 2, 3, 1 },
                new[] { 3, 4, 2 },
                new[] { 4, 5, 3 },
                new[] { 5, 6, 4 }
            },
            5
        };
    }
}