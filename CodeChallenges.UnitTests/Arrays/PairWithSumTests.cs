using CodeChallenges.Solutions.Arrays;

namespace CodeChallenges.UnitTests.Arrays;

public sealed class HasPairWithSumTests
{
    [Theory]
    [InlineData(new[] { 1, 2, 3, 9 }, 8, false)]
    [InlineData(new[] { 1, 2, 4, 4 }, 8, true)]
    [InlineData(new[] { 1, 2, 3 }, 6, false)]
    [InlineData(new[] { -2, -1, 0, 3, 7 }, -1, true)]
    [InlineData(new[] { -2, -1, 0, 3, 7 }, 0, false)]
    public void ReturnsTrueIfTwoElementsSumAGivenNumber_AscOrderedNumbers(int[] numbers, int sum, bool expectedResult)
    {
        var result = HasPairWithSum.SolveForAscOrderedNumbers(numbers, sum);
        result.ShouldBe(expectedResult);
    }
    
    [Theory]
    [InlineData(new[] { 7, 1, 6, 7 }, 7, true)]
    [InlineData(new[] { 7, 1, -6, -7 }, -13, true)]
    [InlineData(new[] { 7, 1, -6, -7 }, -17, false)]
    public void ReturnsTrueIfTwoElementsSumAGivenNumber_UnorderedNumbers(int[] numbers, int sum, bool expectedResult)
    {
        var result = HasPairWithSum.SolveForUnorderedNumbers(numbers, sum);
        result.ShouldBe(expectedResult);
    }
}