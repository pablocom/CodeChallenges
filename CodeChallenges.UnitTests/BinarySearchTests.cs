using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public sealed class BinarySearchTests
{
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 8, 7)]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, -11, -1)]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 7, 6)]
    public void ReturnsTheIndexOfElementFound(int[] orderedArray, int valueToFind, int indexFound)
    {
        var result = BinarySearch<int>.FindFirst(orderedArray, valueToFind);

        result.Should().Be(indexFound);
    }
}