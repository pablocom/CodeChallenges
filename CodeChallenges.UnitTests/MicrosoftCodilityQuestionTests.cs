using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests;

public class MicrosoftCodilityQuestionTests
{
    [Test]
    public void Test1()
    {
        var text = "abccbd";
        var costs = new[] { 0, 1, 2, 3, 4, 5 };

        var solution = new MicrosoftCodilityQuestion().Solution(text, costs);
        
        Assert.That(solution, Is.EqualTo(2));
    }
}