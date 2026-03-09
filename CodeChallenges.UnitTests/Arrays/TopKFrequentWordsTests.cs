using CodeChallenges.Solutions.Arrays;

namespace CodeChallenges.UnitTests.Arrays;

public class TopKFrequentWordsTests
{
    [Fact]
    public void ReturnsMostFrequentWords()
    {
        var words = new[] { "i", "love", "leetcode", "i", "love", "coding" };
        var result = TopKFrequentWords.TopKFrequent(words, 2);
        result.Should().ContainInOrder("i", "love");
    }

    [Fact]
    public void TiesAreBrokenAlphabetically()
    {
        var words = new[] { "the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is" };
        var result = TopKFrequentWords.TopKFrequent(words, 4);
        result.Should().ContainInOrder("the", "is", "sunny", "day");
    }

    [Fact]
    public void SingleWord()
    {
        var result = TopKFrequentWords.TopKFrequent(new[] { "hello" }, 1);
        result.Should().ContainInOrder("hello");
    }

    [Fact]
    public void AllSameFrequencyReturnedAlphabetically()
    {
        var words = new[] { "c", "a", "b" };
        var result = TopKFrequentWords.TopKFrequent(words, 2);
        result.Should().ContainInOrder("a", "b");
    }

    [Fact]
    public void KEqualsDistinctWordCount()
    {
        var words = new[] { "aa", "bb", "aa" };
        var result = TopKFrequentWords.TopKFrequent(words, 2);
        result.Should().ContainInOrder("aa", "bb");
    }
}
