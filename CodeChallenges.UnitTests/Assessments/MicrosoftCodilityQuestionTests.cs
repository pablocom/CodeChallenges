using CodeChallenges.Solutions.Assessments;

namespace CodeChallenges.UnitTests.Assessments;

public class MicrosoftCodilityQuestionTests
{
    [Fact]
    public void Test1()
    {
        var text = "abccbd";
        var costs = new[] { 0, 1, 2, 3, 4, 5 };

        var solution = new MicrosoftCodilityQuestion().Question1(text, costs);

        solution.ShouldBe(2);
    }
    
    [Fact]
    public void Test2()
    {
        var text = "aaaa";
        var costs = new[] { 3, 4, 5, 6 };

        var solution = new MicrosoftCodilityQuestion().Question1(text, costs);

        solution.ShouldBe(12);
    }
    
    [Fact]
    public void Test3()
    {
        var text = "aabbcc";
        var costs = new[] { 1, 2, 1, 2, 1, 2 };

        var solution = new MicrosoftCodilityQuestion().Question1(text, costs);
        
        solution.ShouldBe(3);
    }
    
    [Fact]
    public void Test6()
    {
        var k = 3;
        var a = new[] { 4, 9, 8, 2, 6 };

        var solution = new MicrosoftCodilityQuestion().Question2(a, k);
        
        solution.ShouldBe(18);
    }
}