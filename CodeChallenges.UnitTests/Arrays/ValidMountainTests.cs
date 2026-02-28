using CodeChallenges.Solutions.Arrays;

namespace CodeChallenges.UnitTests.Arrays;

public sealed class ValidMountainTests
{
    [Theory]
    [InlineData(new[] { 2, 1 }, false)]
    [InlineData(new[] { 3, 5, 5 }, false)]
    [InlineData(new[] { 0, 3, 2, 1 }, true)]
    [InlineData(new[] { 0, 1, 2, 3, 4, 5, 4, 3, 2, 1 }, true)]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, false)]
    [InlineData(new[] { 5, 4, 3, 2, 1 }, false)]
    [InlineData(new[] { 1, 3, 2 }, true)]
    [InlineData(new[] { 1, 2, 2, 1 }, false)]
    [InlineData(new[] { 1 }, false)]
    public void Tests(int[] numbers, bool expected)
    {
        var result = ValidMountain.Solve(numbers);

        result.Should().Be(expected);
    }
}
