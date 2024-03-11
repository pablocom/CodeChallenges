using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class SpiralOrderTests
{
    [Fact]
    public void Test1()
    {
        var matrix = new int[][] 
        { 
            [1, 2, 3],
            [4, 5, 6],
            [7, 8, 9]
        };
        int[] expectedResult = [1, 2, 3, 6, 9, 8, 7, 4, 5];

        var solution = new SpiralOrderSolution().SpiralOrder(matrix);

        solution.Should().Equal(expectedResult);
    }

    [Fact]
    public void Test2()
    {
        var matrix = new int[][] 
        { 
            [1,  2,  3,  4],
            [5,  6,  7,  8],
            [9, 10, 11, 12]
        };
        int[] expectedResult = [1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7];

        var solution = new SpiralOrderSolution().SpiralOrder(matrix);

        solution.Should().Equal(expectedResult);
    }
}
