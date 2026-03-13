using CodeChallenges.Solutions.Strings;

namespace CodeChallenges.UnitTests.Strings;

public sealed class StringToIntegerAtoiTests
{
    [Fact]
    public void Simple_Positive_Number_Returns_Integer()
    {
        var result = new StringToIntegerAtoi().MyAtoi("42");

        result.ShouldBe(42);
    }

    [Fact]
    public void Negative_Number_Returns_Negative_Integer()
    {
        var result = new StringToIntegerAtoi().MyAtoi("-42");

        result.ShouldBe(-42);
    }

    [Fact]
    public void Leading_Whitespace_Is_Ignored()
    {
        var result = new StringToIntegerAtoi().MyAtoi("   -42");

        result.ShouldBe(-42);
    }

    [Fact]
    public void Trailing_Non_Digit_Characters_Are_Ignored()
    {
        var result = new StringToIntegerAtoi().MyAtoi("4193 with words");

        result.ShouldBe(4193);
    }

    [Fact]
    public void Non_Digit_First_Character_Returns_Zero()
    {
        var result = new StringToIntegerAtoi().MyAtoi("words and 987");

        result.ShouldBe(0);
    }

    [Fact]
    public void Plus_Sign_Returns_Positive_Integer()
    {
        var result = new StringToIntegerAtoi().MyAtoi("+1");

        result.ShouldBe(1);
    }

    [Fact]
    public void Empty_String_Returns_Zero()
    {
        var result = new StringToIntegerAtoi().MyAtoi("");

        result.ShouldBe(0);
    }

    [Fact]
    public void Whitespace_Only_String_Returns_Zero()
    {
        var result = new StringToIntegerAtoi().MyAtoi("   ");

        result.ShouldBe(0);
    }

    [Fact]
    public void Zero_Returns_Zero()
    {
        var result = new StringToIntegerAtoi().MyAtoi("0");

        result.ShouldBe(0);
    }

    [Fact]
    public void Single_Digit_Returns_That_Digit()
    {
        var result = new StringToIntegerAtoi().MyAtoi("7");

        result.ShouldBe(7);
    }

    [Fact]
    public void Positive_Overflow_Returns_Int_MaxValue()
    {
        var result = new StringToIntegerAtoi().MyAtoi("91283472332");

        result.ShouldBe(int.MaxValue);
    }
}
