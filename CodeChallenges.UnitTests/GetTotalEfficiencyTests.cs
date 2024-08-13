using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class GetTotalEfficiencyTests
{
    [Fact]
    public void Test1()
    {
        var expectedSolution = 7;
        
        var solution = GetTotalEfficiency.getTotalEfficiency([1, 2, 3, 2]);
        
        solution.Should().Be(expectedSolution);
    }
}