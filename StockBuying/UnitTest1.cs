using NUnit.Framework;

namespace StockBuying
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var stocks = new [] { 1, 2, 3, 4, 5 };

            var result = Solution.MaxProfit(stocks);
            
            Assert.That(result, Is.EqualTo(5));
        }
        
        [Test]
        public void Test2()
        {
            var stocks = new [] { 7, 1, 5, 3, 6, 4 };

            var result = Solution.MaxProfit(stocks);
            
            Assert.That(result, Is.EqualTo(5));
        }
    }
}