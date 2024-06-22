namespace CodeChallenges.Solutions;

public sealed class LongestValidParentheses
{
    public int Solve(string s)
    {
        var span = s.AsSpan();

        int maxLen = 0;
        var dp = new int[span.Length];
        for (int i = 1; i < span.Length; i++)
        {
            if (span[i] == ')')
            {
                if (span[i - 1] == '(')
                {
                    dp[i] = (i > 2 ? dp[i - 2] : 0) + 2;
                }
                else if (i - dp[i - 1] > 0 && span[i - dp[i - 1] - 1] == '(')
                {
                    int x = (i - dp[i - 1]) >= 2 ? dp[i - dp[i - 1] - 2] : 0;
                    dp[i] = dp[i - 1] + x + 2;
                }
                maxLen = Math.Max(maxLen, dp[i]);
            }
        }

        return maxLen;
    }
}
