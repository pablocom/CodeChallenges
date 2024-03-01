using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;
public class KthLargestTests
{
    [Fact]
    public void Test1()
    {
        var inputArray = new[] {3, 2, 1, 4, 5, 6};
        var kthLargestNumber = 2;

        var result = new KthLargest().FindKthLargest(inputArray, kthLargestNumber);

        result.Should().Be(5);
    }

    [Fact]
    public void Test2()
    {
        var inputArray = new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
        var kthLargestNumber = 4;

        var result = new KthLargest().FindKthLargest(inputArray, kthLargestNumber);

        result.Should().Be(4);
    }
}