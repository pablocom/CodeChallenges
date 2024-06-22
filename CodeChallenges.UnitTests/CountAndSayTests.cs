using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class CountAndSayTests
{
    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "11")]
    [InlineData(3, "21")]
    [InlineData(4, "1211")]
    [InlineData(5, "111221")]
    [InlineData(6, "312211")]
    public void Scenario(int n, string expectedSolution) 
    {
        var solution = new CountAndSay().Solve(n);

        solution.Should().Be(expectedSolution);
    }
}
