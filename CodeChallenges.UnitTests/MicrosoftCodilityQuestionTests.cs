using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class MicrosoftCodilityQuestionTests
{
    [Fact]
    public void Test1()
    {
        var text = "abccbd";
        var costs = new[] { 0, 1, 2, 3, 4, 5 };

        var solution = new MicrosoftCodilityQuestion().Question1(text, costs);

        solution.Should().Be(2);
    }
    
    [Fact]
    public void Test2()
    {
        var text = "aaaa";
        var costs = new[] { 3, 4, 5, 6 };

        var solution = new MicrosoftCodilityQuestion().Question1(text, costs);

        solution.Should().Be(12);
    }
    
    [Fact]
    public void Test3()
    {
        var text = "aabbcc";
        var costs = new[] { 1, 2, 1, 2, 1, 2 };

        var solution = new MicrosoftCodilityQuestion().Question1(text, costs);
        
        solution.Should().Be(3);
    }
    
    [Fact(Skip = "Not implemented")]
    public void Test5()
    {
        var K = 5;
        var A = new[] { 5, 6, 3, 4, 2 };

        var solution = new MicrosoftCodilityQuestion().Question2(A, K);
        
        solution.Should().Be(20);
    }
    
    [Fact]
    public void Test6()
    {
        var K = 3;
        var A = new[] { 4, 9, 8, 2, 6 };

        var solution = new MicrosoftCodilityQuestion().Question2(A, K);
        
        solution.Should().Be(18);
    }
}