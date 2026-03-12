using CodeChallenges.Solutions.Mathematics;

namespace CodeChallenges.UnitTests.Math;

public class MultiplyStringsTests
{
    [Theory]
    [InlineData("1", "2", "2")]
    [InlineData("2", "3", "6")]
    [InlineData("99", "2", "198")]
    [InlineData("999", "22", "21978")]
    [InlineData("9999999999999999", "222", "2219999999999999778")]
    [InlineData("11111111111111111111111111111111111", "1000000", "11111111111111111111111111111111111000000")]
    public void Tests(string num1, string num2, string expected) 
        => MultiplyStrings.Solve(num1, num2).Should().Be(expected);
}