using NUnit.Framework;

namespace CodeChallenges.LevenshteinDistance
{
    public class LevenshteinDistanceTests
    {
        [TestCase("pablo", "company", 6)]
        [TestCase("zoologicoarchaeologist", "zoogeologist", 10)]
        public void Test1(string originalString, string destinationString, int expectedResult)
        {
            var result = new LevenshteinDistanceSolution().LevenshteinDistance(originalString, destinationString);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}