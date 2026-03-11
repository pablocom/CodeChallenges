namespace CodeChallenges.Solutions.DynamicProgramming;

public static class CoinChange
{
    public static int Solve(int[] coins, int amount)
    {
        Span<int> dp = stackalloc int[amount + 1];
        dp.Fill(amount + 1);
        dp[0] = 0;

        for (var a = 1; a <= amount; a++)
            foreach (var coin in coins)
                if (a - coin >= 0)
                    dp[a] = Math.Min(dp[a], 1 + dp[a - coin]);

        return dp[amount] != amount + 1 
            ? dp[amount]
            : -1;
    }
}