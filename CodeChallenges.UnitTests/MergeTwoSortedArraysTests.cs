using CodeChallenges.Solutions;
using CodeChallenges.UnitTests.Builders;

namespace CodeChallenges.UnitTests;
public class MergeTwoSortedListsTests
{
    public static IEnumerable<object[]> Scenarios => new List<object[]>
    {
        new object[] { new[] {1,2,4}, new[] {1,3,4}, new[] {1,1,2,3,4,4} },
        new object[] { new int[] {}, new int[] {}, new int[] {} },
        new object[] { new int[] {}, new[] {0}, new[] {0} },
        new object[] { new[] {2,3,5}, new[] {1,4,6}, new[] {1,2,3,4,5,6} },
        new object[] { new[] {-10,-5,0,5}, new[] {-2,3,4}, new[] {-10,-5,-2,0,3,4,5} }
    };

    [Theory]
    [MemberData(nameof(Scenarios))]
    public void Test(int[] array1, int[] array2, int[] expectedArray)
    {
        var list1 = ListNodeBuilder.From(array1).Build();
        var list2 = ListNodeBuilder.From(array2).Build();
        var expectedList = ListNodeBuilder.From(expectedArray).Build();

        var result = MergeTwoSortedLists.Merge(list1, list2);

        result.Should().BeEquivalentTo(expectedList);
    }
}
