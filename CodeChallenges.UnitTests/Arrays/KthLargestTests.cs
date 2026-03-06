using CodeChallenges.Solutions.Arrays;

namespace CodeChallenges.UnitTests.Arrays;

public class KthLargestTests
{
    [Theory]
    [InlineData(new[] { 3, 2, 1, 4, 5, 6 },             2, 5)]
    [InlineData(new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 },    4, 4)]
    [InlineData(new[] { 1 },                              1, 1)]
    [InlineData(new[] { 7, 7, 7 },                        2, 7)]
    [InlineData(new[] { 5, 3, 1, 6, 4, 2 },              6, 1)]
    public void SolveWithSort(int[] nums, int k, int expected) =>
        KthLargest.SolveWithSort(nums, k).Should().Be(expected);

    [Theory]
    [InlineData(new[] { 3, 2, 1, 4, 5, 6 },             2, 5)]
    [InlineData(new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 },    4, 4)]
    [InlineData(new[] { 1 },                              1, 1)]
    [InlineData(new[] { 7, 7, 7 },                        2, 7)]
    [InlineData(new[] { 5, 3, 1, 6, 4, 2 },              6, 1)]
    public void SolveWithMaxHeap(int[] nums, int k, int expected) =>
        KthLargest.SolveWithMaxHeap(nums, k).Should().Be(expected);
}