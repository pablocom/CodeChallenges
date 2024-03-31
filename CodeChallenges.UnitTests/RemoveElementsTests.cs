using CodeChallenges.Solutions.Arrays;

namespace CodeChallenges.UnitTests;

public class RemoveElementsTests
{
    [Fact(Skip = "Not implemented")]
    public void Test1()
    {
        int[] array = [3, 2, 2, 3];

        var solution = new RemoveElements().RemoveElement(array, 4);

        solution.Should().Be(2);
    }
}

