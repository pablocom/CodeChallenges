namespace CodeChallenges.Solutions.DynamicProgramming;

public static class LengthOfLongestIncreasingSubsequence
{
    public static int Solve(int[] nums)
    {
        if (nums.Length is 0)
            return 0;
        
        if (nums.Length is 1)
            return 1;
        
        Span<int> dp = stackalloc int[nums.Length];
        dp.Fill(1);

        for (var i = nums.Length - 1; i >= 0; i--)
        for (var j = i + 1; j < nums.Length; j++)
            if (nums[i] < nums[j]) 
                dp[i] = Math.Max(dp[i], 1 + dp[j]);

        var max = 1;
        foreach (var result in dp) 
            max = Math.Max(max, result);
        return max;
    }
}