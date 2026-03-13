using CodeChallenges.Solutions.Backtracking;

namespace CodeChallenges.UnitTests.Backtracking;

public class Permutations2Tests
{
    [Theory]
    [MemberData(nameof(TestCases))]
    public void Solve(int[] nums, int[][] expected) =>
        Permutations2.Solve(nums).ShouldBe(expected);

    public static TheoryData<int[], int[][]> TestCases => new()
    {
        { [1],          [[1]] },
        { [1, 2],       [[1, 2], [2, 1]] },
        { [1, 1, 2],    [[1, 1, 2], [1, 2, 1], [2, 1, 1]] },
        { [2, 2, 2],    [[2, 2, 2]] },
        { [1, 1, 2, 2], [[1, 1, 2, 2], [1, 2, 1, 2], [1, 2, 2, 1], [2, 1, 1, 2], [2, 1, 2, 1], [2, 2, 1, 1]] },
        { [-1, -1, 0],  [[-1, -1, 0], [-1, 0, -1], [0, -1, -1]] },
    };
}
