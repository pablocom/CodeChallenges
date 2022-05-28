using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests;

public class RemoveDuplicatesFromSortedArrayTests
{
    [Test]
    public void Test1()
    {
        var array = new[] {1, 2, 2};

        var resultArrayLength = new RemoveDuplicatesFromSortedArray().RemoveDuplicates(array);
            
        Assert.That(resultArrayLength, Is.EqualTo(2));
        Assert.That(array[0], Is.EqualTo(1));
        Assert.That(array[1], Is.EqualTo(2));
    }
        
    [Test]
    public void Test2()
    {
        var array = new[] {1, 2, 2, 3};

        var resultArrayLength = new RemoveDuplicatesFromSortedArray().RemoveDuplicates(array);
            
        Assert.That(resultArrayLength, Is.EqualTo(3));
        Assert.That(array[0], Is.EqualTo(1));
        Assert.That(array[1], Is.EqualTo(2));
        Assert.That(array[2], Is.EqualTo(3));
    }
}