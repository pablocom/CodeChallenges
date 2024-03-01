using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class RemoveDuplicatesFromSortedArrayTests
{
    [Fact]
    public void Test1()
    {
        var array = new[] {1, 2, 2};

        var resultArrayLength = new RemoveDuplicatesFromSortedArray().RemoveDuplicates(array);
            
        resultArrayLength.Should().Be(2);
        array[0].Should().Be(1);
        array[1].Should().Be(2);
    }
        
    [Fact]
    public void Test2()
    {
        var array = new[] {1, 2, 2, 3};

        var resultArrayLength = new RemoveDuplicatesFromSortedArray().RemoveDuplicates(array);
            
        resultArrayLength.Should().Be(3);
        array[0].Should().Be(1);
        array[1].Should().Be(2);
        array[2].Should().Be(3);
    }
}