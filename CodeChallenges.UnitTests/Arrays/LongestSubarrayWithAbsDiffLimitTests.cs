using CodeChallenges.Solutions.Arrays;

namespace CodeChallenges.UnitTests.Arrays;

public sealed class LongestSubarrayWithAbsDiffLimitTests
{
    public static TheoryData<int[], int, int> Scenarios => new()
    {
        { [8, 2, 4, 7],          4, 2 },
        { [10, 1, 2, 4, 7, 2],   5, 4 },
        { [4, 2, 2, 2, 4, 4, 2, 2], 0, 3 },
    };

    [Theory, MemberData(nameof(Scenarios))]
    public void Solve(int[] nums, int limit, int expected) =>
        LongestSubarrayWithAbsDiffLimit.Solve(nums, limit).ShouldBe(expected);
}
