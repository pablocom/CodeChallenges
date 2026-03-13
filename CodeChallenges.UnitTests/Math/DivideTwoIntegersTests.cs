using CodeChallenges.Solutions.Mathematics;

namespace CodeChallenges.UnitTests.Math;

public class DivideTwoIntegersTests
{
    [Fact]
    public void Test1()
    {
        var result = new DivideTwoIntegers().Divide(10, 5);
        result.ShouldBe(2);
    }

    [Fact]
    public void Test2()
    {
        var result = new DivideTwoIntegers().Divide(16, 5);
        result.ShouldBe(3);
    }

    [Fact]
    public void Test3()
    {
        var result = new DivideTwoIntegers().Divide(7, -3);
        result.ShouldBe(-2);
    }

    [Fact]
    public void Test4()
    {
        var result = new DivideTwoIntegers().Divide(-2147483648, -1);
        result.ShouldBe(2147483647);
    }

    [Fact]
    public void Test5()
    {
        var result = new DivideTwoIntegers().Divide(2147483647, 2147483646);
        result.ShouldBe(1);
    }
}
