using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests;

[TestFixture]
public class RomanToIntTests
{
    [TestCase("III", 3)]
    [TestCase("IV", 4)]
    [TestCase("MMD", 2500)]
    public void Test1(string roman, int arabic)
    {
        var solution = new RomanToInt().Solve(roman);
        
        Assert.That(solution, Is.EqualTo(arabic));
    }
}