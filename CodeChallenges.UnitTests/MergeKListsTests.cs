using CodeChallenges.Solutions;
using CodeChallenges.Solutions.LinkedLists;
using CodeChallenges.UnitTests.Builders;

namespace CodeChallenges.UnitTests;

public class MergeKListsTests
{
    [Fact]
    public void Test1()
    {
        var lists = new ListNode[]
        {
            ListNodeBuilder.From([1, 4, 5]).Build()!,
            ListNodeBuilder.From([1, 3, 4]).Build()!,
            ListNodeBuilder.From([2, 6]).Build()!,
        };
        int[] expectedSolution = [1, 1, 2, 3, 4, 4, 5, 6];

        var solution = new MergeKListsSolution().MergeKLists(lists);

        solution.Should().Equal(expectedSolution);
    }
}
