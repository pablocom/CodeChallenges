using CodeChallenges.Solutions.Arrays;

namespace CodeChallenges.UnitTests.Arrays;

public class RemoveDuplicatesFromSortedArrayTests
{
    [Fact]
    public void Test1()
    {
        var array = new[] {1, 2, 2};

        var resultArrayLength = new RemoveDuplicatesFromSortedArray().RemoveDuplicates(array);
            
        resultArrayLength.ShouldBe(2);
        array[0].ShouldBe(1);
        array[1].ShouldBe(2);
    }
        
    [Fact]
    public void Test2()
    {
        var array = new[] {1, 2, 2, 3};

        var resultArrayLength = new RemoveDuplicatesFromSortedArray().RemoveDuplicates(array);
            
        resultArrayLength.ShouldBe(3);
        array[0].ShouldBe(1);
        array[1].ShouldBe(2);
        array[2].ShouldBe(3);
    }
}