using CodeChallenges.Solutions.DynamicProgramming;

namespace CodeChallenges.UnitTests.DynamicProgramming;

public sealed class CourseSchedule3Tests
{
    public static TheoryData<int[][], int> Scenarios => new()
    {
        { [[100, 200], [200, 1300], [1000, 1250], [2000, 3200]], 3 },
        { [[1, 2]], 1 },
        { [[3, 2], [4, 3]], 0 },
    };

    [Theory, MemberData(nameof(Scenarios))]
    public void Solve(int[][] courses, int expected) =>
        CourseSchedule3.Solve(courses).ShouldBe(expected);
}
