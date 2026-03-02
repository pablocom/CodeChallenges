using CodeChallenges.Solutions.DynamicProgramming;

namespace CodeChallenges.UnitTests.DynamicProgramming;

public class TwoKeysKeyboardTests
{
    public static TheoryData<int, int> Scenarios => new()
    {
        { 1, 0 },
        { 2, 2 },
        { 3, 3 },
        { 4, 4 },
        { 6, 5 },
        { 9, 6 },
        { 12, 7 },
        { 37, 37 },
    };

    [Theory, MemberData(nameof(Scenarios))]
    public void SolveWithFactors(int n, int expected) =>
        TwoKeysKeyboard.SolveWithFactors(n).Should().Be(expected);

    [Theory, MemberData(nameof(Scenarios))]
    public void SolveWithMagic(int n, int expected) =>
        TwoKeysKeyboard.SolveWithMagic(n).Should().Be(expected);

    [Theory, MemberData(nameof(Scenarios))]
    public void SolveWithDfs(int n, int expected) =>
        TwoKeysKeyboard.SolveWithDfs(n).Should().Be(expected);
}
