using CodeChallenges.Solutions.Arrays;

namespace CodeChallenges.UnitTests.Arrays;

public class SubsetsTests
{
    [Fact]
    public void EmptyArray_ReturnsOnlyEmptySubset()
    {
        var result = Subsets.Solve([]);
        result.Should().BeEquivalentTo<IList<int>>([[]]);
    }

    [Fact]
    public void SingleElement_ReturnsTwoSubsets()
    {
        var result = Subsets.Solve([1]);
        result.Should().BeEquivalentTo<IList<int>>([[], [1]]);
    }

    [Fact]
    public void TwoElements_ReturnsFourSubsets()
    {
        var result = Subsets.Solve([1, 2]);
        result.Should().BeEquivalentTo<IList<int>>([[], [1], [2], [1, 2]]);
    }

    [Fact]
    public void ThreeElements_ReturnsEightSubsets()
    {
        var result = Subsets.Solve([1, 2, 3]);
        result.Should().BeEquivalentTo<IList<int>>(
            [[], [1], [2], [3], [1, 2], [1, 3], [2, 3], [1, 2, 3]]);
    }

    [Fact]
    public void WithNegativeNumbers()
    {
        var result = Subsets.Solve([-1, 0, 1]);
        result.Should().BeEquivalentTo<IList<int>>(
            [[], [-1], [0], [1], [-1, 0], [-1, 1], [0, 1], [-1, 0, 1]]);
    }

    [Fact]
    public void SubsetCountIsTwoToThePowerOfN()
    {
        var result = Subsets.Solve([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]);
        result.Should().HaveCount(65536);
    }
}
