using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class StockBuyingTests
{
    [Fact]
    public void Test1()
    {
        var stocks = new [] { 1, 2, 3, 4, 5 };

        var result = StockBuying.MaxProfit(stocks);

        result.Should().Be(4);
    }
        
    [Fact]
    public void Test2()
    {
        var stocks = new [] { 7, 1, 5, 3, 6, 4 };

        var result = StockBuying.MaxProfit(stocks);
            
        result.Should().Be(5);
    }
}