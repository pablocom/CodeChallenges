namespace CodeChallenges.UnitTests;

public class AmazonAssessmentsTests
{
    [Fact]
    public void Excersise1_Test1()
    {
        List<int> stockPrice = [1, 3, 2, 4, 5];
        var expectedOutput = 2;

        var result = AmazonAssessments.Result.LocateEarliestMonth(stockPrice);

        result.Should().Be(expectedOutput);
    }

    [Fact]
    public void Excersise1_Test2()
    {
        List<int> stockPrice = [1, 1, 1, 1, 1];
        var expectedOutput = 1;

        var result = AmazonAssessments.Result.LocateEarliestMonth(stockPrice);

        result.Should().Be(expectedOutput);
    }

    [Fact]
    public void Excersise1_Test3()
    {
        List<int> stockPrice = [1, 3, 2, 3, 1];
        var expectedOutput = 2;

        var result = AmazonAssessments.Result.LocateEarliestMonth(stockPrice);

        result.Should().Be(expectedOutput);
    }

    [Fact]
    public void Excersise1_Test4()
    {
        List<int> stockPrice = [2, 5];
        var expectedOutput = 1;

        var result = AmazonAssessments.Result.LocateEarliestMonth(stockPrice);

        result.Should().Be(expectedOutput);
    }

    [Fact]
    public void Excersise1_Test5()
    {
        List<int> stockPrice = [2, 2];
        var expectedOutput = 1;

        var result = AmazonAssessments.Result.LocateEarliestMonth(stockPrice);

        result.Should().Be(expectedOutput);
    }

    [Fact]
    public void Excersise1_Test6()
    {
        List<int> stockPrice = [2];
        var expectedOutput = 1;

        var result = AmazonAssessments.Result.LocateEarliestMonth(stockPrice);

        result.Should().Be(expectedOutput);
    }

    [Fact(Skip = "Incomplete")]
    public void Excersise1_Test7()
    {
        List<int> stockPrice = [9, 8];
        var expectedOutput = 1;

        var result = AmazonAssessments.Result.LocateEarliestMonth(stockPrice);

        result.Should().Be(expectedOutput);
    }

    [Fact(Skip = "Incomplete")]
    public void Excersise2_Test1()
    {
        List<int> stockPrice = [2, 3, 3, 4, 6, 8, 8, 6];
        var expectedOutput = 48;

        var result = AmazonAssessments.Result.GetMaxTotalArea(stockPrice);

        result.Should().Be(expectedOutput);
    }
}
