using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class ThreeSumTests
{
    [Fact]
    public void Test1()
    {
        var inputArray = new[] { -1, 0, 1, 2, -1, -4 };

        var solution = new ThreeSum().Solve(inputArray);

        solution.Should().BeEquivalentTo(new int[][]
        {
            [-1, -1, 2], [-1, 0, 1]
        });
    }
}
