using CodeChallenges.Solutions.Assessments;

namespace CodeChallenges.UnitTests.Assessments;

public class AwsInterviewQuestionsTests
{
    // ── MinSwapsRequired ────────────────────────────────────────────

    [Fact]
    public void MinSwapsRequired_NullString_ReturnsMinusOne()
    {
        var result = AwsInterviewQuestions.MinSwapsRequired(null);

        result.Should().Be(-1);
    }

    [Fact]
    public void MinSwapsRequired_EmptyString_ReturnsMinusOne()
    {
        var result = AwsInterviewQuestions.MinSwapsRequired("");

        result.Should().Be(-1);
    }

    [Fact]
    public void MinSwapsRequired_SingleCharacter_ReturnsZero()
    {
        var result = AwsInterviewQuestions.MinSwapsRequired("a");

        result.Should().Be(0);
    }

    [Fact]
    public void MinSwapsRequired_TwoSameCharacters_ReturnsZero()
    {
        var result = AwsInterviewQuestions.MinSwapsRequired("aa");

        result.Should().Be(0);
    }

    [Fact]
    public void MinSwapsRequired_TwoDifferentCharacters_ReturnsMinusOne()
    {
        var result = AwsInterviewQuestions.MinSwapsRequired("ab");

        result.Should().Be(-1);
    }

    [Fact]
    public void MinSwapsRequired_AlreadyPalindrome_ReturnsZero()
    {
        var result = AwsInterviewQuestions.MinSwapsRequired("aba");

        result.Should().Be(0);
    }

    [Fact]
    public void MinSwapsRequired_EvenLengthAlreadyPalindrome_ReturnsZero()
    {
        var result = AwsInterviewQuestions.MinSwapsRequired("abba");

        result.Should().Be(0);
    }

    [Fact]
    public void MinSwapsRequired_SimpleSwapNeeded_ReturnsOne()
    {
        var result = AwsInterviewQuestions.MinSwapsRequired("abab");

        result.Should().Be(1);
    }

    [Fact]
    public void MinSwapsRequired_ImpossiblePalindrome_ReturnsMinusOne()
    {
        var result = AwsInterviewQuestions.MinSwapsRequired("abcd");

        result.Should().Be(-1);
    }

    [Fact]
    public void MinSwapsRequired_OddLengthPalindromePossible_ReturnsSwapCount()
    {
        var result = AwsInterviewQuestions.MinSwapsRequired("aabb");

        result.Should().Be(1);
    }

    [Fact]
    public void MinSwapsRequired_ThreeIdenticalCharacters_ReturnsZero()
    {
        var result = AwsInterviewQuestions.MinSwapsRequired("aaa");

        result.Should().Be(0);
    }

    // ── GetMaxFreqDeviation ─────────────────────────────────────────

    [Fact]
    public void GetMaxFreqDeviation_SingleCharacter_ReturnsZero()
    {
        var result = AwsInterviewQuestions.GetMaxFreqDeviation("a");

        result.Should().Be(0);
    }

    [Fact]
    public void GetMaxFreqDeviation_AllSameCharacters_ReturnsZero()
    {
        var result = AwsInterviewQuestions.GetMaxFreqDeviation("aaaa");

        result.Should().Be(0);
    }

    [Fact]
    public void GetMaxFreqDeviation_TwoGroupsDifferentSizes_ReturnsDeviation()
    {
        var result = AwsInterviewQuestions.GetMaxFreqDeviation("aabbb");

        result.Should().Be(1);
    }

    [Fact]
    public void GetMaxFreqDeviation_MultipleGroups_ReturnsMaxDeviation()
    {
        var result = AwsInterviewQuestions.GetMaxFreqDeviation("aabbbbcc");

        result.Should().Be(3);
    }

    [Fact]
    public void GetMaxFreqDeviation_TwoCharactersAlternating_ReturnsZero()
    {
        var result = AwsInterviewQuestions.GetMaxFreqDeviation("ababab");

        result.Should().Be(0);
    }

    [Fact]
    public void GetMaxFreqDeviation_TwoCharacters_ReturnsDeviation()
    {
        var result = AwsInterviewQuestions.GetMaxFreqDeviation("ab");

        result.Should().Be(0);
    }

    [Fact]
    public void GetMaxFreqDeviation_LargeDeviationBetweenConsecutiveGroups_ReturnsMax()
    {
        var result = AwsInterviewQuestions.GetMaxFreqDeviation("aaaab");

        result.Should().Be(3);
    }
}
