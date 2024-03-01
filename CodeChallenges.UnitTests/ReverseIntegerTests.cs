using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

// https://leetcode.com/problems/reverse-integer/description/?envType=featured-list&envId=top-microsoft-questions?envType=featured-list&envId=top-microsoft-questions
public class ReverseIntegerTests
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(123, 321)]
    [InlineData(-123, -321)]
    [InlineData(120, 21)]
    [InlineData(-2147483412, -2143847412)]
    [InlineData(-2147483648, 0)]
    [InlineData(2147483647, 0)]
    [InlineData(1534236469, 0)]
    public void Examples(int input, int expectedOutput)
    {
        var result = ReverseInteger.Reverse(input);

        result.Should().Be(expectedOutput);
    }
    
    [Theory]
    [InlineData(0, 0)]
    [InlineData(123, 321)]
    [InlineData(-123, -321)]
    [InlineData(120, 21)]
    [InlineData(-2147483412, -2143847412)]
    [InlineData(-2147483648, 0)]
    [InlineData(2147483641, 1463847412)]
    [InlineData(2147483647, 0)]
    [InlineData(1534236469, 0)]
    public void ExamplesOptimized(int input, int expectedOutput)
    {
        var result = ReverseInteger.ReverseOptimized(input);

        result.Should().Be(expectedOutput);
    }
}