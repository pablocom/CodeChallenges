namespace CodeChallenges.Solutions.Arrays;

public static class StockBuying
{
    public static int MaxProfit(int[] prices)
    {
        int maxCur = 0, maxSoFar = 0;
            
        for (var i = 1; i < prices.Length; i++) 
        {
            maxCur = System.Math.Max(0, maxCur + (prices[i] - prices[i-1]));
            maxSoFar = System.Math.Max(maxCur, maxSoFar);
        }
        return maxSoFar;
    }
}