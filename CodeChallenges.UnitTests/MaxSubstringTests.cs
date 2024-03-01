using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class MaxSubstringTests
{
    [Fact]
    public void Test1()
    {
        var word = " ";

        var maxLength = MaxSubstring.LengthOfLongestSubstring(word);

        maxLength.Should().Be(1);
    }
        
    [Fact]
    public void Test2()
    {
        var word = "dvdf";

        var maxLength = MaxSubstring.LengthOfLongestSubstring(word);
            
        maxLength.Should().Be(3);
    }
        
    [Fact]
    public void Test3()
    {
        var word = "abcabcbb";

        var maxLength = MaxSubstring.LengthOfLongestSubstring(word);
            
        maxLength.Should().Be(3);
    }
        
    [Fact]
    public void Test4()
    {
        var word = "bbbbb";

        var maxLength = MaxSubstring.LengthOfLongestSubstring(word);
            
        maxLength.Should().Be(1);
    }
        
    [Fact]
    public void Test5()
    {
        var word = "cdd";

        var maxLength = MaxSubstring.LengthOfLongestSubstring(word);
            
        maxLength.Should().Be(2);
    }
}