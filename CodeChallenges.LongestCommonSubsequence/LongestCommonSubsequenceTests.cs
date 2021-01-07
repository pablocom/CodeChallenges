using NUnit.Framework;

namespace CodeChallenges.LongestCommonSubsequence
{
    public class LongestCommonSubsequenceTests
    {
        [TestCase("ACB", "AIB", 2)]
        [TestCase("AGGTAB", "GXTXAYB", 4)]
        [TestCase("ABCDGH", "AEDFHR", 3)]
        [TestCase("AGGTABOIBPOBBGXTXAY", "GXTXAYBAYBPOABAGGTAB", 11)]
        [TestCase("MNBVCXZÑLKJHGFDSAPOIUYTREWQMHEQSDQOJDSIANCVJHFIQHEURHALKSDLFKIDJFJKDIJWNSJNDAHFUVNAHFADPWOSS", "MNBVCXZÑLKJHGFDSAPOIUYTREWQWERTMNBVCXZÑLKJHGFDSAPOIUYTREWQWERTDQODIWJSDNASDOJWIDJASLDJQWOIJDASLDKJQWOWIJDSALJDJIWÑLVKCLASDJFDHF", 56)]
        public void FindLongestCommonSubsquenceGivenTwoStrings(string text1, string text2, int expectedResult)
        {
            var tabulationSolution = new TabulationSolution().CalculateWithPerformanceTrackingLongestCommonSubsequence(text1, text2);
            var memoizationSolution = new MemoizationSolution().CalculateWithPerformanceTrackingLongestCommonSubsequence(text1, text2);
            //var bruteForceSolution = new BruteForceSolution().CalculateWithPerformanceTrackingLongestCommonSubsequence(text1, text2);
            
            Assert.That(tabulationSolution, Is.EqualTo(expectedResult));
            Assert.That(memoizationSolution, Is.EqualTo(expectedResult));   
            //Assert.That(bruteForceSolution, Is.EqualTo(expectedResult));   
        }
    }
}