using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class LongestCommonSubsequenceTests
{
    [Theory]
    [InlineData("abcde", "ace", 3)]
    [InlineData("ACB", "AIB", 2)]
    [InlineData("AGGTAB", "GXTXAYB", 4)]
    [InlineData("ABCDGH", "AEDFHR", 3)]
    [InlineData("ABCDGH", "", 0)]
    [InlineData("", "ADV", 0)]
    public void FindLongestCommonSubsequenceGivenTwoStrings(string text1, string text2, int expectedResult)
    {
        var tabulationSolution = TabulationSolution.LongestCommonSubsequence(text1, text2);
        var memoizationSolution = MemoizationSolution.LongestCommonSubsequence(text1, text2);
        // var bruteForceSolution = new LongestCommonSubsequenceBruteForceSolution().LongestCommonSubsequence(text1, text2);

        tabulationSolution.Should().Be(expectedResult);
        memoizationSolution.Should().Be(expectedResult);
        // bruteForceSolution.Should().Be(expectedResult);
    }
}