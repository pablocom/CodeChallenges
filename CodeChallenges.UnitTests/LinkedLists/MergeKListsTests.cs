using CodeChallenges.Solutions.LinkedLists;
using CodeChallenges.UnitTests.Builders;

namespace CodeChallenges.UnitTests.LinkedLists;

public sealed class MergeKListsTests
{
    public static TheoryData<int[][], int[]> Scenarios => new()
    {
        { [[1, 4, 5], [1, 3, 4], [2, 6]], [1, 1, 2, 3, 4, 4, 5, 6] },
        { [[1]],                           [1]                       },
        { [[-1, 0, 1], [-3, -2]],          [-3, -2, -1, 0, 1]       },
    };

    [Theory, MemberData(nameof(Scenarios))]
    public void SolveWithMinHeap(int[][] inputLists, int[] expected)
    {
        var lists = inputLists.Select(values => ListNodeBuilder.From(values).Build()!).ToArray();

        var result = MergeKSortedLists.Solve(lists);

        result.ShouldBe(expected);
    }

    [Theory, MemberData(nameof(Scenarios))]
    public void SolveOptimized(int[][] inputLists, int[] expected)
    {
        var lists = inputLists.Select(values => ListNodeBuilder.From(values).Build()!).ToArray();

        var result = MergeKSortedLists.SolveOptimized(lists);

        result.ShouldBe(expected);
    }

    [Theory, MemberData(nameof(Scenarios))]
    public void SolveWithDivideAndConquer(int[][] inputLists, int[] expected)
    {
        var lists = inputLists.Select(values => ListNodeBuilder.From(values).Build()!).ToArray();

        var result = new MergeKListsSolution().MergeKLists(lists);

        result.ShouldBe(expected);
    }
}
