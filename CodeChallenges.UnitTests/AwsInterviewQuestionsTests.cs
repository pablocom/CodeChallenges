using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class AwsInterviewQuestionsTests
{
    [Theory(Skip = "Not implemented")]
    [InlineData("101000", 1)]
    [InlineData("1110", -1)]
    [InlineData("1010", 1)]
    public void MinSwapsRequiredTests(string text, int expected)
    {
        var solution = AwsInterviewQuestions.MinSwapsRequired(text);
        solution.Should().Be(expected);
    }
    
    [Theory(Skip = "Not implemented")]
    [InlineData("baaacyyyyyssssss", 4)]
    [InlineData("aab", 1)]
    [InlineData("abb", 1)]
    [InlineData("bbacccabab", 2)]
    [InlineData("bbcccc", 2)]
    [InlineData("bbccccddd", 2)]
    [InlineData("aaaaa", 0)]
    public void GetMaxFreqDeviationTests(string text, int expected)
    {
        var solution = AwsInterviewQuestions.GetMaxFreqDeviation(text);
        solution.Should().Be(expected);
    }
}