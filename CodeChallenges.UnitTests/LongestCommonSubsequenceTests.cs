using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests;

public class LongestCommonSubsequenceTests
{
    [TestCase("abcde", "ace", 3)]
    [TestCase("ACB", "AIB", 2)]
    [TestCase("AGGTAB", "GXTXAYB", 4)]
    [TestCase("ABCDGH", "AEDFHR", 3)]
    [TestCase("ABCDGH", "", 0)]
    [TestCase("", "ADV", 0)]
    public void FindLongestCommonSubsequenceGivenTwoStrings(string text1, string text2, int expectedResult)
    {
        var tabulationSolution = TabulationSolution.LongestCommonSubsequence(text1, text2);
        var memoizationSolution = new MemoizationSolution().LongestCommonSubsequence(text1, text2);
        // var bruteForceSolution = new LongestCommonSubsequenceBruteForceSolution().LongestCommonSubsequence(text1, text2);
            
        Assert.That(tabulationSolution, Is.EqualTo(expectedResult));
        Assert.That(memoizationSolution, Is.EqualTo(expectedResult));   
        // Assert.That(bruteForceSolution, Is.EqualTo(expectedResult));   
    }
}