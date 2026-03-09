using CodeChallenges.Solutions.LinkedLists;
using CodeChallenges.UnitTests.Builders;

namespace CodeChallenges.UnitTests.LinkedLists;

public sealed class AddTwoNumbersTests
{
    public static IEnumerable<object[]> Scenarios =>
    [
        [new[] { 2, 4, 3 }, new[] { 5, 6, 4 }, new[] { 7, 0, 8 }],
        [new[] { 0 },       new[] { 0 },       new[] { 0 }],
        [new[] { 9, 9, 9, 9, 9, 9, 9 }, new[] { 9, 9, 9, 9 }, new[] { 8, 9, 9, 9, 0, 0, 0, 1 }],
        [new[] { 5 },       new[] { 5 },       new[] { 0, 1 }],
        [new[] { 1 },       new[] { 9, 9 },    new[] { 0, 0, 1 }],
    ];

    [Theory]
    [MemberData(nameof(Scenarios))]
    public void Tests(int[] num1, int[] num2, int[] expected)
    {
        var l1 = ListNodeBuilder.From(num1).Build();
        var l2 = ListNodeBuilder.From(num2).Build();
        var expectedHead = ListNodeBuilder.From(expected).Build();

        var result = AddTwoNumbers.Solve(l1!, l2!);

        result.Should().BeEquivalentTo(expectedHead);
    }
}
