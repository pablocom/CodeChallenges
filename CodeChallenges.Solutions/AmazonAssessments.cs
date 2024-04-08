using System.Runtime.InteropServices;

namespace CodeChallenges.UnitTests;

public class AmazonAssessments
{
    public static class Result
    {
        public static int LocateEarliestMonth(List<int> stockPrice)
        {
            var stockPriceSpan = CollectionsMarshal.AsSpan(stockPrice);

            if (stockPriceSpan.Length is 2)
            {
                if (stockPriceSpan[0] <= stockPriceSpan[1])
                    return 1;
                
                return 2;
            }
            
            long total = 0;
            foreach (var price in stockPriceSpan) 
                total += price;
            
            int lowestNetPriceIndex = -1;
            long lowestNetPrice = long.MaxValue;
            long sumUntilCurrentMonth = 0;
            
            for (int i = 0; i < stockPriceSpan.Length; i++)
            {
                sumUntilCurrentMonth += stockPriceSpan[i];
                var currentAverage = sumUntilCurrentMonth / (i + 1);

                long remainingAverage = 0;

                if (i < stockPriceSpan.Length - 1)
                    remainingAverage = (total - sumUntilCurrentMonth) / (stockPriceSpan.Length - (i + 1));

                if (lowestNetPrice > Math.Abs(currentAverage - remainingAverage))
                {
                    lowestNetPrice = Math.Abs(currentAverage - remainingAverage);
                    lowestNetPriceIndex = i;
                }
            }
            
            return lowestNetPriceIndex + 1;
        }

        public static int GetMaxTotalArea(List<int> sideLengths)
        {
            var sideLengthsSpan = CollectionsMarshal.AsSpan(sideLengths);
            sideLengthsSpan.Sort((a, b) => b.CompareTo(a));

            var lengthCounts = new Dictionary<int, int>();

            foreach (var stickLength in sideLengthsSpan)
            {
                lengthCounts.TryAdd(stickLength, 0);
                lengthCounts[stickLength]++;
            }

            const int module = 1000000007;
            long totalArea = 0;
            var firstSide = 0;

            return (int)totalArea;
        }
    }
}
