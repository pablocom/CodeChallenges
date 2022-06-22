using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests;

public class LetterCombinationsTests
{
    [Test]
    public void Test1()
    {
        var input = "23";

        var solution = new LetterCombinations().Solve(input);

        Assert.That(solution, Is.EquivalentTo(new[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" }));
    }
}
