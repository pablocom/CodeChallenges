using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests;

public class AwsInterviewQuestionsTests
{
    [Test]
    public void Test1()
    {
        var text = "101000";

        var solution = AwsInterviewQuestions.MinSwapsRequired(text);
        
        Assert.That(solution, Is.EqualTo(1));
    }
    
    [Test]
    public void Test2()
    {
        var text = "1110";

        var solution = AwsInterviewQuestions.MinSwapsRequired(text);
        
        Assert.That(solution, Is.EqualTo(-1));
    }
    
    [Test]
    public void Test3()
    {
        var text = "1010";

        var solution = AwsInterviewQuestions.MinSwapsRequired(text);
        
        Assert.That(solution, Is.EqualTo(1));
    }
    
    [Test]
    public void Test4()
    {
        var text = "baaacyyyyyssssss";

        var solution = AwsInterviewQuestions.GetMaxFreqDeviation(text);
        
        Assert.That(solution, Is.EqualTo(4));
    }
    
    
    [Test]
    public void Test5()
    {
        var text = "aab";

        var solution = AwsInterviewQuestions.GetMaxFreqDeviation(text);
        
        Assert.That(solution, Is.EqualTo(1));
    }
    
    [Test]
    public void Test6()
    {
        var text = "abb";

        var solution = AwsInterviewQuestions.GetMaxFreqDeviation(text);
        
        Assert.That(solution, Is.EqualTo(1));
    }
    
    [Test]
    public void Test7()
    {
        var text = "bbacccabab";

        var solution = AwsInterviewQuestions.GetMaxFreqDeviation(text);
        
        Assert.That(solution, Is.EqualTo(2));
    }
    
    [Test]
    public void Test00()
    {
        var text = "bbcccc";

        var solution = AwsInterviewQuestions.GetMaxFreqDeviation(text);
        
        Assert.That(solution, Is.EqualTo(2));
    }
    
    [Test]
    public void Test01()
    {
        var text = "bbccccddd";

        var solution = AwsInterviewQuestions.GetMaxFreqDeviation(text);
        
        Assert.That(solution, Is.EqualTo(2));
    }
    
    [Test]
    public void Test8()
    {
        var text = "aaaaa";

        var solution = AwsInterviewQuestions.GetMaxFreqDeviation(text);
        
        Assert.That(solution, Is.EqualTo(0));
    }
}