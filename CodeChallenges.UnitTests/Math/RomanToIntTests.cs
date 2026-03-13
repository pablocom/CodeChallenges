using CodeChallenges.Solutions.Mathematics;

namespace CodeChallenges.UnitTests.Math;

public class RomanToIntTests
{
    [Theory]
    [InlineData("III", 3)]
    [InlineData("IV", 4)]
    [InlineData("MMD", 2500)]
    public void Test1(string roman, int arabic)
    {
        var solution = new RomanToInt().Solve(roman);

        solution.ShouldBe(arabic);
    }
}