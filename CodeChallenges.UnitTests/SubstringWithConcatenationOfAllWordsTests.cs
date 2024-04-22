using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class SubstringWithConcatenationOfAllWordsTests
{
    [Fact]
    public void Test1()
    {
        var result = new SubstringWithConcatenationOfAllWords().FindSubstring("barfoothefoobarman", ["foo", "bar"]);
        result.Should().BeEquivalentTo([0, 9]);
    }

    [Fact]
    public void Test2()
    {
        var result = new SubstringWithConcatenationOfAllWords().FindSubstring("wordgoodgoodgoodbestword", ["word", "good", "best", "word"]);
        result.Should().BeEmpty();
    }

    [Fact]
    public void Test3()
    {
        var result = new SubstringWithConcatenationOfAllWords().FindSubstring("barfoofoobarthefoobarman", ["bar", "foo", "the"]);
        result.Should().BeEquivalentTo([6, 9, 12]);
    }


    [Fact]
    public void Test4()
    {
        var result = new SubstringWithConcatenationOfAllWords().FindSubstring("abaa", ["a", "b"]);
        result.Should().BeEquivalentTo([0, 1]);
    }

    [Fact]
    public void Test5()
    {
        var result = new SubstringWithConcatenationOfAllWords().FindSubstring("aaaa", ["a", "a"]);
        result.Should().BeEquivalentTo([0, 1, 2]);
    }

    [Fact]
    public void Test6()
    {
        var result = new SubstringWithConcatenationOfAllWords().FindSubstring("wordgoodgoodgoodbestword", ["word", "good", "best", "good"]);
        result.Should().BeEquivalentTo([8]);
    }

    [Fact]
    public void Test7()
    {
        var result = new SubstringWithConcatenationOfAllWords().FindSubstring("aaaaaaaaaaaaaa", ["aa", "aa"]);
        result.Should().BeEquivalentTo([0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
    }

    [Fact]
    public void Test8()
    {
        var result = new SubstringWithConcatenationOfAllWords().FindSubstring("bcabbcaabbccacacbabccacaababcbb", ["c", "b", "a", "c", "a", "a", "a", "b", "c"]);
        result.Should().BeEquivalentTo([6, 16, 17, 18, 19, 20]);
    }
}
