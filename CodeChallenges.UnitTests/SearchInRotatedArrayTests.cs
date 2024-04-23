using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class SearchInRotatedArrayTests
{
    [Fact]
    public void Test1()
    {
        int[] nums = [3, 4, 0, 1, 2];
        var target = 1;

        var solution = new SearchInRotatedArray().Search(nums, target);

        solution.Should().Be(3);
    }
}
