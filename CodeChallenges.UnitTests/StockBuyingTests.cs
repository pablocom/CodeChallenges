using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests;

public class StockBuyingTests
{
    [Test]
    public void Test1()
    {
        var stocks = new [] { 1, 2, 3, 4, 5 };

        var result = StockBuying.MaxProfit(stocks);
            
        Assert.That(result, Is.EqualTo(4));
    }
        
    [Test]
    public void Test2()
    {
        var stocks = new [] { 7, 1, 5, 3, 6, 4 };

        var result = StockBuying.MaxProfit(stocks);
            
        Assert.That(result, Is.EqualTo(5));
    }
}