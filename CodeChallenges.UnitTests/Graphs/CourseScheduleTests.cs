using CodeChallenges.Solutions.Graphs;

namespace CodeChallenges.UnitTests.Graphs;

public class CourseScheduleTests
{
    [Fact]
    public void SingleCourse_NoPrerequisites_ReturnsTrue()
    {
        var result = CourseSchedule.Solve(1, []);

        result.ShouldBeTrue();
    }

    [Fact]
    public void TwoCourses_OnePrerequisite_ReturnsTrue()
    {
        int[][] prerequisites = [[1, 0]];

        var result = CourseSchedule.Solve(2, prerequisites);

        result.ShouldBeTrue();
    }

    [Fact]
    public void TwoCourses_MutualDependency_ReturnsFalse()
    {
        int[][] prerequisites = [[0, 1], [1, 0]];

        var result = CourseSchedule.Solve(2, prerequisites);

        result.ShouldBeFalse();
    }

    [Fact]
    public void ThreeCourses_CycleAmongAll_ReturnsFalse()
    {
        // 0 -> 1 -> 2 -> 0
        int[][] prerequisites = [[1, 0], [2, 1], [0, 2]];

        var result = CourseSchedule.Solve(3, prerequisites);

        result.ShouldBeFalse();
    }

    [Fact]
    public void SelfLoop_ReturnsFalse()
    {
        int[][] prerequisites = [[0, 0]];

        var result = CourseSchedule.Solve(1, prerequisites);

        result.ShouldBeFalse();
    }

    [Fact]
    public void AllCoursesIndependent_ReturnsTrue()
    {
        var result = CourseSchedule.Solve(5, []);

        result.ShouldBeTrue();
    }

    [Fact]
    public void LinearChain_NoCycle_ReturnsTrue()
    {
        // 0 -> 1 -> 2 -> 3
        int[][] prerequisites = [[1, 0], [2, 1], [3, 2]];

        var result = CourseSchedule.Solve(4, prerequisites);

        result.ShouldBeTrue();
    }

    [Fact]
    public void DiamondDependency_NoCycle_ReturnsTrue()
    {
        //     0
        //    / \
        //   1   2
        //    \ /
        //     3
        int[][] prerequisites = [[1, 0], [2, 0], [3, 1], [3, 2]];

        var result = CourseSchedule.Solve(4, prerequisites);

        result.ShouldBeTrue();
    }

    [Fact]
    public void DisconnectedGraph_NoCycle_ReturnsTrue()
    {
        // Chain A: 0 -> 1, Chain B: 2 -> 3
        int[][] prerequisites = [[1, 0], [3, 2]];

        var result = CourseSchedule.Solve(4, prerequisites);

        result.ShouldBeTrue();
    }

    [Fact]
    public void CycleInSubgraph_WithIndependentNode_ReturnsFalse()
    {
        // 0 <-> 1 cycle, course 2 is independent
        int[][] prerequisites = [[0, 1], [1, 0]];

        var result = CourseSchedule.Solve(3, prerequisites);

        result.ShouldBeFalse();
    }

    [Fact]
    public void LargerCycleInPartOfGraph_ReturnsFalse()
    {
        // 0 -> 1 -> 2 -> 3 -> 1 (cycle among 1, 2, 3)
        int[][] prerequisites = [[1, 0], [2, 1], [3, 2], [1, 3]];

        var result = CourseSchedule.Solve(5, prerequisites);

        result.ShouldBeFalse();
    }

    [Fact]
    public void MultipleCoursesDependOnSamePrerequisite_ReturnsTrue()
    {
        // Courses 1, 2, 3 all depend on course 0
        int[][] prerequisites = [[1, 0], [2, 0], [3, 0]];

        var result = CourseSchedule.Solve(4, prerequisites);

        result.ShouldBeTrue();
    }

    [Fact]
    public void ComplexGraph_NoCycle_ReturnsTrue()
    {
        // 5 depends on 0 and 4, 4 depends on 1, 3 depends on 2, 2 depends on 1
        int[][] prerequisites = [[5, 0], [5, 4], [4, 1], [3, 2], [2, 1]];

        var result = CourseSchedule.Solve(6, prerequisites);

        result.ShouldBeTrue();
    }

    [Fact]
    public void TwoCourseCycle_WithDependentCourse_ReturnsFalse()
    {
        // 0 <-> 1 cycle, course 2 depends on 0
        int[][] prerequisites = [[0, 1], [1, 0], [2, 0]];

        var result = CourseSchedule.Solve(3, prerequisites);

        result.ShouldBeFalse();
    }
}
