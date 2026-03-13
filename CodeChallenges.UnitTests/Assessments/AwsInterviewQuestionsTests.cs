using CodeChallenges.Solutions.Assessments;

namespace CodeChallenges.UnitTests.Assessments;

public class AwsInterviewQuestionsTests
{
    // ── MinSwapsRequired ────────────────────────────────────────────

    [Fact]
    public void MinSwapsRequired_NullString_ReturnsMinusOne()
    {
        var result = AwsInterviewQuestions.MinSwapsRequired(null);

        result.ShouldBe(-1);
    }

    [Fact]
    public void MinSwapsRequired_EmptyString_ReturnsMinusOne()
    {
        var result = AwsInterviewQuestions.MinSwapsRequired("");

        result.ShouldBe(-1);
    }

    [Fact]
    public void MinSwapsRequired_SingleCharacter_ReturnsZero()
    {
        var result = AwsInterviewQuestions.MinSwapsRequired("a");

        result.ShouldBe(0);
    }

    [Fact]
    public void MinSwapsRequired_TwoSameCharacters_ReturnsZero()
    {
        var result = AwsInterviewQuestions.MinSwapsRequired("aa");

        result.ShouldBe(0);
    }

    [Fact]
    public void MinSwapsRequired_TwoDifferentCharacters_ReturnsMinusOne()
    {
        var result = AwsInterviewQuestions.MinSwapsRequired("ab");

        result.ShouldBe(-1);
    }

    [Fact]
    public void MinSwapsRequired_AlreadyPalindrome_ReturnsZero()
    {
        var result = AwsInterviewQuestions.MinSwapsRequired("aba");

        result.ShouldBe(0);
    }

    [Fact]
    public void MinSwapsRequired_EvenLengthAlreadyPalindrome_ReturnsZero()
    {
        var result = AwsInterviewQuestions.MinSwapsRequired("abba");

        result.ShouldBe(0);
    }

    [Fact]
    public void MinSwapsRequired_SimpleSwapNeeded_ReturnsOne()
    {
        var result = AwsInterviewQuestions.MinSwapsRequired("abab");

        result.ShouldBe(1);
    }

    [Fact]
    public void MinSwapsRequired_ImpossiblePalindrome_ReturnsMinusOne()
    {
        var result = AwsInterviewQuestions.MinSwapsRequired("abcd");

        result.ShouldBe(-1);
    }

    [Fact]
    public void MinSwapsRequired_OddLengthPalindromePossible_ReturnsSwapCount()
    {
        var result = AwsInterviewQuestions.MinSwapsRequired("aabb");

        result.ShouldBe(1);
    }

    [Fact]
    public void MinSwapsRequired_ThreeIdenticalCharacters_ReturnsZero()
    {
        var result = AwsInterviewQuestions.MinSwapsRequired("aaa");

        result.ShouldBe(0);
    }

    // ── GetMaxFreqDeviation ─────────────────────────────────────────

    [Fact]
    public void GetMaxFreqDeviation_SingleCharacter_ReturnsZero()
    {
        var result = AwsInterviewQuestions.GetMaxFreqDeviation("a");

        result.ShouldBe(0);
    }

    [Fact]
    public void GetMaxFreqDeviation_AllSameCharacters_ReturnsZero()
    {
        var result = AwsInterviewQuestions.GetMaxFreqDeviation("aaaa");

        result.ShouldBe(0);
    }

    [Fact]
    public void GetMaxFreqDeviation_TwoGroupsDifferentSizes_ReturnsDeviation()
    {
        var result = AwsInterviewQuestions.GetMaxFreqDeviation("aabbb");

        result.ShouldBe(1);
    }

    [Fact]
    public void GetMaxFreqDeviation_MultipleGroups_ReturnsMaxDeviation()
    {
        var result = AwsInterviewQuestions.GetMaxFreqDeviation("aabbbbcc");

        result.ShouldBe(3);
    }

    [Fact]
    public void GetMaxFreqDeviation_TwoCharactersAlternating_ReturnsZero()
    {
        var result = AwsInterviewQuestions.GetMaxFreqDeviation("ababab");

        result.ShouldBe(0);
    }

    [Fact]
    public void GetMaxFreqDeviation_TwoCharacters_ReturnsDeviation()
    {
        var result = AwsInterviewQuestions.GetMaxFreqDeviation("ab");

        result.ShouldBe(0);
    }

    [Fact]
    public void GetMaxFreqDeviation_LargeDeviationBetweenConsecutiveGroups_ReturnsMax()
    {
        var result = AwsInterviewQuestions.GetMaxFreqDeviation("aaaab");

        result.ShouldBe(3);
    }
}
