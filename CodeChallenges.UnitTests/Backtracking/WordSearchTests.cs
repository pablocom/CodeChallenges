using CodeChallenges.Solutions.Backtracking;

namespace CodeChallenges.UnitTests.Backtracking;

public class WordSearchTests
{
    [Theory]
    [MemberData(nameof(TestCases))]
    public void Solve(char[][] board, string word, bool expected) =>
        WordSearch.Solve(board, word).ShouldBe(expected);

    public static TheoryData<char[][], string, bool> TestCases => new()
    {
        {
            new[] { "ABCE".ToCharArray(), "SFCS".ToCharArray(), "ADEE".ToCharArray() },
            "ABCCED", true
        },
        {
            new[] { "ABCE".ToCharArray(), "SFCS".ToCharArray(), "ADEE".ToCharArray() },
            "SEE", true
        },
        {
            new[] { "ABCE".ToCharArray(), "SFCS".ToCharArray(), "ADEE".ToCharArray() },
            "ABCB", false
        },
        {
            new[] { "A".ToCharArray() },
            "A", true
        },
        {
            new[] { "A".ToCharArray() },
            "AB", false
        },
        {
            new[] { "AB".ToCharArray(), "CD".ToCharArray() },
            "ABDC", true
        },
    };
}
