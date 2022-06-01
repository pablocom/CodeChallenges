using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests;

public class ValidPalindrome2Tests
{
    [TestCase("aba", true)]
    [TestCase("abac", true)]
    [TestCase("acbac", false)]
    [TestCase("cacbac", true)]
    [TestCase("abc", false)]
    public void Test1(string text, bool isPalindrome)
    {
        var solution = new ValidPalindrome2().Solve(text);
        
        Assert.That(solution, Is.EqualTo(isPalindrome));
    }
}