using CodeChallenges.Solutions.Arrays;

namespace CodeChallenges.UnitTests.Arrays;

public sealed class TwoSumTests
{
    public static TheoryData<int[], int, int[]> Scenarios => new()
    {
        { [2, 7, 11, 15], 9, [0, 1] },
        { [3, 2, 4],      6, [1, 2] },
        { [3, 3],         6, [0, 1] },
        { [-1, -2, -3],  -5, [1, 2] },
    };

    [Theory, MemberData(nameof(Scenarios))]
    public void Solve(int[] nums, int target, int[] expected) =>
        TwoSum.Solve(nums, target).ShouldBe(expected);

    [Theory, MemberData(nameof(Scenarios))]
    public void WriteHeavy(int[] nums, int target, int[] expected)
    {
        var strategy = new WriteHeavyTwoSumStrategy();
        foreach (var n in nums) strategy.Add(n);
        strategy.Find(target).ShouldBe(expected);
    }

    [Theory, MemberData(nameof(Scenarios))]
    public void ReadHeavy(int[] nums, int target, int[] expected)
    {
        var strategy = new ReadHeavyTwoSumStrategy();
        foreach (var n in nums) strategy.Add(n);
        strategy.Find(target).ShouldBe(expected);
    }

    [Fact]
    public void NoSolution_Throws()
    {
        Should.Throw<InvalidOperationException>(() => TwoSum.Solve([1, 2, 3], 100));

        var writeHeavy = new WriteHeavyTwoSumStrategy();
        foreach (var n in new[] { 1, 2, 3 }) writeHeavy.Add(n);
        Should.Throw<InvalidOperationException>(() => writeHeavy.Find(100));

        var readHeavy = new ReadHeavyTwoSumStrategy();
        foreach (var n in new[] { 1, 2, 3 }) readHeavy.Add(n);
        Should.Throw<InvalidOperationException>(() => readHeavy.Find(100));
    }
}
