using CodeChallenges.Solutions.LinkedLists;
using CodeChallenges.UnitTests.Builders;

namespace CodeChallenges.UnitTests;

public sealed class ReverseNodesInKGroupsTests
{
    [Fact]
    public void Test1()
    {
        var input = ListNodeBuilder.From([1, 2, 3, 4, 5]).Build();
        var k = 2;

        var result = ReverseNodesInKGroups.ReverseKGroup(input, k);

        result.Should().Equal([2, 1, 4, 3, 5]);
    }

    [Fact]
    public void Test2()
    {
        var input = ListNodeBuilder.From([1, 2, 3, 4, 5]).Build();
        var k = 1;

        var result = ReverseNodesInKGroups.ReverseKGroup(input, k);

        result.Should().Equal([1, 2, 3, 4, 5]);
    }

    [Fact]
    public void Test3()
    {
        var input = ListNodeBuilder.From([1, 2, 3, 4, 5, 6]).Build();
        var k = 2;

        var result = ReverseNodesInKGroups.ReverseKGroup(input, k);

        result.Should().Equal([2, 1, 4, 3, 6, 5]);
    }

    [Fact]
    public void Test4()
    {
        var input = ListNodeBuilder.From([1, 2, 3, 4, 5, 6]).Build();
        var k = 7;

        var result = ReverseNodesInKGroups.ReverseKGroup(input, k);

        result.Should().Equal([1, 2, 3, 4, 5, 6]);
    }

    [Fact]
    public void Test5()
    {
        var input = ListNodeBuilder.From([1, 2, 3, 4, 5, 6, 7]).Build();
        var k = 3;

        var result = ReverseNodesInKGroups.ReverseKGroup(input, k);

        result.Should().Equal([3, 2, 1, 6, 5, 4, 7]);
    }

    [Fact]
    public void Test6()
    {
        var input = ListNodeBuilder.From([1, 2, 3, 4, 5, 6, 7]).Build();
        var k = 4;

        var result = ReverseNodesInKGroups.ReverseKGroup(input, k);

        result.Should().Equal([4, 3, 2, 1, 5, 6, 7]);
    }
}
