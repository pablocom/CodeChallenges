using CodeChallenges.Solutions.Backtracking;

namespace CodeChallenges.UnitTests.Backtracking;

public class GenerateParenthesesTests
{
    [Fact]
    public void Test1()
    {
        const int n = 3;

        var solution = new GenerateParentheses().GenerateParenthesis(n);

        solution.ShouldBe(["((()))", "(()())", "(())()", "()(())", "()()()"]);
    }
    
    [Fact]
    public void Test2()
    {
        var n = 2;

        var solution = new GenerateParentheses().GenerateParenthesis(n);

        solution.ShouldBe(["(())", "()()"]);
    }
    
    [Fact]
    public void Test3()
    {
        var n = 1;

        var solution = new GenerateParentheses().GenerateParenthesis(n);

        solution.ShouldBe(["()"]);
    }
}