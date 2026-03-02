using CodeChallenges.Solutions.LinkedLists;
using CodeChallenges.UnitTests.Builders;

namespace CodeChallenges.UnitTests.LinkedLists;

public sealed class ReverseLinkedListTests
{
    public static IEnumerable<object[]> Scenarios =>
    [
        [new[] { 1, 2, 3, 4, 5 }, new[] { 5, 4, 3, 2, 1 }],
        [new[] { 1, 2 },           new[] { 2, 1 }],
        [new[] { 1 },              new[] { 1 }],
    ];

    [Theory]
    [MemberData(nameof(Scenarios))]
    public void Tests(int[] input, int[] expected)
    {
        var head = ListNodeBuilder.From(input).Build();
        var expectedHead = ListNodeBuilder.From(expected).Build();

        var result = ReverseLinkedList.Solve(head!);

        result.Should().BeEquivalentTo(expectedHead);
    }
}
