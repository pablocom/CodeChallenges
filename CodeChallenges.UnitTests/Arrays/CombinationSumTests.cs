using CodeChallenges.Solutions.Arrays;

namespace CodeChallenges.UnitTests.Arrays;

public class CombinationSumTests
{
    [Theory]
    [MemberData(nameof(TestCases))]
    public void Solve(int[] candidates, int target, int[][] expected) =>
        CombinationSum.Solve(candidates, target).Should().BeEquivalentTo(expected);

    public static TheoryData<int[], int, int[][]> TestCases => new()
    {
        { [2, 3, 6, 7], 7, [[2, 2, 3], [7]] },
        { [2, 3, 5],    8, [[2, 2, 2, 2], [2, 3, 3], [3, 5]] },
        { [2],          3, [] },
        { [1],          1, [[1]] },
        { [1],          3, [[1, 1, 1]] },
    };
}
