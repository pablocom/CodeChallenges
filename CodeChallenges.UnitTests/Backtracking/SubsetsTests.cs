using CodeChallenges.Solutions.Backtracking;

namespace CodeChallenges.UnitTests.Backtracking;

public class SubsetsTests
{
    [Fact]
    public void EmptyArray_ReturnsOnlyEmptySubset()
    {
        var result = Subsets.Solve([]);
        result.Count.ShouldBe(1);
        result[0].ShouldBeEmpty();
    }

    [Fact]
    public void SingleElement_ReturnsTwoSubsets()
    {
        var result = Subsets.Solve([1]);
        result.Count.ShouldBe(2);
        result.ShouldContain(s => s.Count == 0);
        result.ShouldContain(s => s.SequenceEqual(new[] { 1 }));
    }

    [Fact]
    public void TwoElements_ReturnsFourSubsets()
    {
        var result = Subsets.Solve([1, 2]);
        result.Count.ShouldBe(4);
        result.ShouldContain(s => s.Count == 0);
        result.ShouldContain(s => s.SequenceEqual(new[] { 1 }));
        result.ShouldContain(s => s.SequenceEqual(new[] { 2 }));
        result.ShouldContain(s => s.SequenceEqual(new[] { 1, 2 }));
    }

    [Fact]
    public void ThreeElements_ReturnsEightSubsets()
    {
        var result = Subsets.Solve([1, 2, 3]);
        result.Count.ShouldBe(8);
    }

    [Fact]
    public void WithNegativeNumbers()
    {
        var result = Subsets.Solve([-1, 0, 1]);
        result.Count.ShouldBe(8);
    }

    [Fact]
    public void SubsetCountIsTwoToThePowerOfN()
    {
        var result = Subsets.Solve([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]);
        result.Count().ShouldBe(65536);
    }
}
