using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class StringToIntegerAtoiTests
{
    [Theory(Skip = "Incomplete")]
    [InlineData("42", 42)]
    [InlineData("7", 7)]
    [InlineData("   42", 42)]
    [InlineData("4193 with words", 4193)]
    [InlineData("   -42", -42)]
    [InlineData("-4193 with words", -4193)]
    [InlineData("-91283472332", -2147483648)]
    [InlineData("words and 987", 0)]
    [InlineData("3.14159", 3)]
    [InlineData("+1", 1)]
    [InlineData("+-12", 0)]
    [InlineData("21474836460", 2147483647)]
    [InlineData("00000-42a1234", 0)]
    [InlineData("  -0012a42", -12)]
    public void ConvertStringIntoIntegerIfPossible(string numberInString, int expectedResult)
    {
        var number = new StringToIntegerAtoi().MyAtoi(numberInString);

        number.Should().Be(expectedResult);
    }
}