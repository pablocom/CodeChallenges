namespace CodeChallenges.Solutions.Arrays;

public static class MaxSubarraySum
{
    public static int Solve(int[] nums)
    {
        var maxSum = int.MinValue;
        var currentSum = 0;

        foreach (var num in nums)
        {
            currentSum += num;
            maxSum = Math.Max(maxSum, currentSum);

            if (currentSum < 0)
                currentSum = 0;
        }
        
        return maxSum;
    }
}