using CodeChallenges.Solutions.Arrays;

namespace CodeChallenges.UnitTests;

public class FirstAndLastPositionInSortedArraySolutionTests
{
    [Fact]
    public void Test1()
    {
        int[] nums = [5, 7, 7, 8, 8, 10];
        var target = 6;

        var solution = new FirstAndLastPositionInSortedArraySolution().SearchRange(nums, target);

        solution.Should().Equal([-1, -1]);
    }
    
    [Fact]
    public void Test2()
    {
        int[] nums = [5, 7, 7, 8, 8, 10];
        var target = 8;

        var solution = new FirstAndLastPositionInSortedArraySolution().SearchRange(nums, target);

        solution.Should().Equal([3, 4]);
    }
    
    [Fact]
    public void Test3()
    {
        int[] nums = [1];
        var target = 1;

        var solution = new FirstAndLastPositionInSortedArraySolution().SearchRange(nums, target);

        solution.Should().Equal([0, 0]);
    }
}