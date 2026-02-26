using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public sealed class BinarySumTests
{
    [Theory]
    [InlineData("10110", "10101", "101011")]
    [InlineData("111", "1", "1000")]
    [InlineData("0", "0", "0")]
    [InlineData("10100110101010101", "1101011010011010", "100010001111101111")]
    [InlineData("000000", "11010", "011010")]
    public void Tests(string a, string b, string expected)
    {
        var result = BinarySum.Solve(a, b);

        result.Should().Be(expected);
    }
}