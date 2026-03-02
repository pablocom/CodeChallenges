using CodeChallenges.Solutions.Arrays;

namespace CodeChallenges.UnitTests.Arrays;

public sealed class FindDifferenceOfTwoArraysTests
{
    [Fact]
    public void PartialOverlap_ReturnsMissingElementsOnEachSide()
    {
        var result = FindDifferenceOfTwoArrays.Solve([1, 2, 3], [2, 4, 6]);

        result[0].Should().BeEquivalentTo([1, 3]);
        result[1].Should().BeEquivalentTo([4, 6]);
    }

    [Fact]
    public void IdenticalArrays_ReturnsTwoEmptyLists()
    {
        var result = FindDifferenceOfTwoArrays.Solve([1, 2, 3], [1, 2, 3]);

        result[0].Should().BeEmpty();
        result[1].Should().BeEmpty();
    }

    [Fact]
    public void NoOverlap_ReturnsBothArraysAsDistinctElements()
    {
        var result = FindDifferenceOfTwoArrays.Solve([1, 3, 5], [2, 4, 6]);

        result[0].Should().BeEquivalentTo([1, 3, 5]);
        result[1].Should().BeEquivalentTo([2, 4, 6]);
    }

    [Fact]
    public void DuplicatesInInput_ReturnsOnlyUniqueElements()
    {
        var result = FindDifferenceOfTwoArrays.Solve([1, 2, 2, 3], [2, 3, 4]);

        result[0].Should().BeEquivalentTo([1]);
        result[1].Should().BeEquivalentTo([4]);
    }

    [Fact]
    public void Nums1IsSubsetOfNums2_ReturnsEmptyFirstAndExtraInSecond()
    {
        var result = FindDifferenceOfTwoArrays.Solve([1, 2, 3], [1, 2, 3, 4]);

        result[0].Should().BeEmpty();
        result[1].Should().BeEquivalentTo([4]);
    }
}
