using CodeChallenges.Solutions.Graphs;

namespace CodeChallenges.UnitTests.Graphs;

public class CourseSchedule2Tests
{
    /// <summary>
    /// Validates that every course in the result appears after all of its prerequisites.
    /// </summary>
    private static bool IsValidTopologicalOrder(int[] result, int numCourses, int[][] prerequisites)
    {
        if (result.Length != numCourses)
            return false;

        var positionOf = new Dictionary<int, int>();
        for (var i = 0; i < result.Length; i++)
            positionOf[result[i]] = i;

        if (positionOf.Count != numCourses)
            return false;

        foreach (var prereq in prerequisites)
        {
            var course = prereq[0];
            var pre = prereq[1];

            // The prerequisite must appear before the course that depends on it
            if (positionOf[pre] >= positionOf[course])
                return false;
        }

        return true;
    }

    [Fact]
    public void SingleCourse_NoPrerequisites_ReturnsThatCourse()
    {
        var result = CourseSchedule2.Solve(1, []);

        result.Should().BeEquivalentTo([0]);
    }

    [Fact]
    public void TwoCourses_NoPrerequisites_ReturnsBothCourses()
    {
        var result = CourseSchedule2.Solve(2, []);

        result.Should().HaveCount(2);
        result.Should().Contain(0);
        result.Should().Contain(1);
    }

    [Fact]
    public void TwoCourses_OnePrerequisite_ReturnsValidOrder()
    {
        // Course 1 requires course 0
        int[][] prerequisites = [[1, 0]];

        var result = CourseSchedule2.Solve(2, prerequisites);

        result.Should().BeEquivalentTo(new[] { 0, 1 }, options => options.WithStrictOrdering());
    }

    [Fact]
    public void FourCourses_LinearChain_ReturnsTheOnlyValidOrder()
    {
        // 0 -> 1 -> 2 -> 3 (must take 0 first, then 1, then 2, then 3)
        int[][] prerequisites = [[1, 0], [2, 1], [3, 2]];

        var result = CourseSchedule2.Solve(4, prerequisites);

        result.Should().BeEquivalentTo(new[] { 0, 1, 2, 3 }, options => options.WithStrictOrdering());
    }

    [Fact]
    public void LeetCodeExample1_FourCourses_TwoPrereqs_ReturnsValidOrder()
    {
        // numCourses = 4, prerequisites = [[1,0],[2,0],[3,1],[3,2]]
        int[][] prerequisites = [[1, 0], [2, 0], [3, 1], [3, 2]];

        var result = CourseSchedule2.Solve(4, prerequisites);

        IsValidTopologicalOrder(result, 4, prerequisites).Should().BeTrue(
            because: $"the result [{string.Join(", ", result)}] should be a valid topological ordering");
    }

    [Fact]
    public void TwoCourses_MutualDependency_ReturnsEmptyArray()
    {
        // Course 0 requires 1, and course 1 requires 0 -- cycle
        int[][] prerequisites = [[0, 1], [1, 0]];

        var result = CourseSchedule2.Solve(2, prerequisites);

        result.Should().BeEmpty();
    }

    [Fact]
    public void ThreeCourses_CycleAmongAll_ReturnsEmptyArray()
    {
        // 0 -> 1 -> 2 -> 0 -- cycle
        int[][] prerequisites = [[1, 0], [2, 1], [0, 2]];

        var result = CourseSchedule2.Solve(3, prerequisites);

        result.Should().BeEmpty();
    }

    [Fact]
    public void SelfLoop_ReturnsEmptyArray()
    {
        // Course 0 requires itself
        int[][] prerequisites = [[0, 0]];

        var result = CourseSchedule2.Solve(1, prerequisites);

        result.Should().BeEmpty();
    }

    [Fact]
    public void AllCoursesIndependent_ReturnsAllCourses()
    {
        var result = CourseSchedule2.Solve(5, []);

        result.Should().HaveCount(5);
        result.Should().OnlyContain(c => c >= 0 && c < 5);
        result.Distinct().Should().HaveCount(5);
    }

    [Fact]
    public void DisconnectedGraph_TwoIndependentChains_ReturnsValidOrder()
    {
        // Chain A: 0 -> 1, Chain B: 2 -> 3 (disconnected)
        int[][] prerequisites = [[1, 0], [3, 2]];

        var result = CourseSchedule2.Solve(4, prerequisites);

        IsValidTopologicalOrder(result, 4, prerequisites).Should().BeTrue(
            because: $"the result [{string.Join(", ", result)}] should be a valid topological ordering");
    }

    [Fact]
    public void DiamondDependency_ReturnsValidOrder()
    {
        // Course 3 depends on 1 and 2; both 1 and 2 depend on 0
        //     0
        //    / \
        //   1   2
        //    \ /
        //     3
        int[][] prerequisites = [[1, 0], [2, 0], [3, 1], [3, 2]];

        var result = CourseSchedule2.Solve(4, prerequisites);

        IsValidTopologicalOrder(result, 4, prerequisites).Should().BeTrue(
            because: $"the result [{string.Join(", ", result)}] should be a valid topological ordering");
        // Course 0 must be first
        result[0].Should().Be(0);
        // Course 3 must be last
        result[3].Should().Be(3);
    }

    [Fact]
    public void CycleInSubgraph_WithDisconnectedValidNode_ReturnsEmptyArray()
    {
        // Courses 0 and 1 form a cycle; course 2 is independent
        int[][] prerequisites = [[0, 1], [1, 0]];

        var result = CourseSchedule2.Solve(3, prerequisites);

        result.Should().BeEmpty();
    }

    [Fact]
    public void MultipleCoursesDependOnSamePrerequisite_ReturnsValidOrder()
    {
        // Courses 1, 2, 3 all depend on course 0
        int[][] prerequisites = [[1, 0], [2, 0], [3, 0]];

        var result = CourseSchedule2.Solve(4, prerequisites);

        IsValidTopologicalOrder(result, 4, prerequisites).Should().BeTrue(
            because: $"the result [{string.Join(", ", result)}] should be a valid topological ordering");
        result[0].Should().Be(0, because: "course 0 is a prerequisite for all others");
    }

    [Fact]
    public void LargerCycleInPartOfGraph_ReturnsEmptyArray()
    {
        // 0 -> 1 -> 2 -> 3 -> 1 (cycle among 1, 2, 3), 4 is independent
        int[][] prerequisites = [[1, 0], [2, 1], [3, 2], [1, 3]];

        var result = CourseSchedule2.Solve(5, prerequisites);

        result.Should().BeEmpty();
    }

    [Fact]
    public void TwoCourses_SecondDependsOnFirst_ReturnsValidOrder()
    {
        // Reversed direction: course 0 requires course 1
        int[][] prerequisites = [[0, 1]];

        var result = CourseSchedule2.Solve(2, prerequisites);

        result.Should().BeEquivalentTo(new[] { 1, 0 }, options => options.WithStrictOrdering());
    }

    [Fact]
    public void ComplexGraph_MultiplePrereqsPerCourse_ReturnsValidOrder()
    {
        // Course 5 depends on 0 and 4
        // Course 4 depends on 1
        // Course 3 depends on 2
        // Course 2 depends on 1
        int[][] prerequisites = [[5, 0], [5, 4], [4, 1], [3, 2], [2, 1]];

        var result = CourseSchedule2.Solve(6, prerequisites);

        IsValidTopologicalOrder(result, 6, prerequisites).Should().BeTrue(
            because: $"the result [{string.Join(", ", result)}] should be a valid topological ordering");
    }

    [Fact]
    public void LeetCodeExample2_OneCourse_ReturnsValidOrder()
    {
        // numCourses = 1, prerequisites = []
        var result = CourseSchedule2.Solve(1, []);

        result.Should().BeEquivalentTo([0]);
    }

    [Fact]
    public void ReversedLinearChain_ReturnsCorrectOrder()
    {
        // 3 -> 2 -> 1 -> 0 (course 0 depends on 1, 1 on 2, 2 on 3)
        int[][] prerequisites = [[0, 1], [1, 2], [2, 3]];

        var result = CourseSchedule2.Solve(4, prerequisites);

        result.Should().BeEquivalentTo(new[] { 3, 2, 1, 0 }, options => options.WithStrictOrdering());
    }

    [Fact]
    public void CourseWithMultiplePrerequisites_AllMustComeBefore()
    {
        // Course 4 requires courses 0, 1, 2, and 3
        int[][] prerequisites = [[4, 0], [4, 1], [4, 2], [4, 3]];

        var result = CourseSchedule2.Solve(5, prerequisites);

        IsValidTopologicalOrder(result, 5, prerequisites).Should().BeTrue(
            because: $"the result [{string.Join(", ", result)}] should be a valid topological ordering");
        result.Last().Should().Be(4, because: "course 4 depends on all others so it must come last");
    }

    [Fact]
    public void TwoCourseCycle_WithThirdCourseDependent_ReturnsEmptyArray()
    {
        // 0 <-> 1 cycle, and course 2 depends on course 0
        int[][] prerequisites = [[0, 1], [1, 0], [2, 0]];

        var result = CourseSchedule2.Solve(3, prerequisites);

        result.Should().BeEmpty();
    }
}
