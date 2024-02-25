using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests;

// https://leetcode.com/problems/reverse-integer/description/?envType=featured-list&envId=top-microsoft-questions?envType=featured-list&envId=top-microsoft-questions
public class ReverseIntegerTests
{
    [TestCase(0, 0)]
    [TestCase(123, 321)]
    [TestCase(-123, -321)]
    [TestCase(120, 21)]
    [TestCase(-2147483412, -2143847412)]
    [TestCase(-2147483648, 0)]
    [TestCase(2147483647, 0)]
    [TestCase(1534236469, 0)]
    public void Examples(int input, int expectedOutput)
    {
        var result = ReverseInteger.Reverse(input);

        result.Should().Be(expectedOutput);
    }
    
    [TestCase(0, 0)]
    [TestCase(123, 321)]
    [TestCase(-123, -321)]
    [TestCase(120, 21)]
    [TestCase(-2147483412, -2143847412)]
    [TestCase(-2147483648, 0)]
    [TestCase(2147483641, 1463847412)]
    [TestCase(2147483647, 0)]
    [TestCase(1534236469, 0)]
    public void ExamplesOptimized(int input, int expectedOutput)
    {
        var result = ReverseInteger.ReverseOptimized(input);

        result.Should().Be(expectedOutput);
    }
}