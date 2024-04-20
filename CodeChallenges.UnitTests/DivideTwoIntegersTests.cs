using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class DivideTwoIntegersTests
{
    [Fact]
    public void Test1()
    {
        var result = new DivideTwoIntegers().Divide(10, 5);
        result.Should().Be(2);
    }

    [Fact]
    public void Test2()
    {
        var result = new DivideTwoIntegers().Divide(16, 5);
        result.Should().Be(3);
    }

    [Fact]
    public void Test3()
    {
        var result = new DivideTwoIntegers().Divide(7, -3);
        result.Should().Be(-2);
    }

    [Fact]
    public void Test4()
    {
        var result = new DivideTwoIntegers().Divide(-2147483648, -1);
        result.Should().Be(2147483647);
    }

    [Fact]
    public void Test5()
    {
        var result = new DivideTwoIntegers().Divide(2147483647, 2147483646);
        result.Should().Be(1);
    }
}
