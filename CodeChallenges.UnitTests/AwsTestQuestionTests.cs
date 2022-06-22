using System.Collections.Generic;
using System.Linq;
using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests;

public class AwsTestQuestionTests
{
    [Test]
    public void METHOD()
    {
        var logs = new List<string>
        {
            "1 2 50", 
            "1 7 70", 
            "1 3 20", 
            "2 2 17"
        };
        var threshold = 2;

        var solution = AwsTest.ProcessLogs(logs, threshold);
        
        CollectionAssert.AreEquivalent(new []
        {
            "1",
            "2"
        }, solution);
    }
    
    [TestCase("|**|*|**", 3)]
    [TestCase("|*|**|**", 3)]
    public void Test2(string input, int expected)
    {
        var solution = AwsTest.numberOfItems(input, new List<int> {1}, new List<int> {8});
        
        Assert.AreEqual(expected, solution.First());
    }
}