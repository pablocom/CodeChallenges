namespace CodeChallenges.Solutions.Arrays;

public static class SubarraySumEqualK
{
    public static int Solve(int[] nums, int k)
    {
        var prefixCountBySum = new Dictionary<int, int> { { 0, 1 } };
        var result = 0;
        var contiguousSum = 0;

        foreach (var number in nums)
        {
            contiguousSum += number;
            var complement = contiguousSum - k;

            result += prefixCountBySum.GetValueOrDefault(complement, 0);
            prefixCountBySum[contiguousSum] = 1 + prefixCountBySum.GetValueOrDefault(contiguousSum, 0);
        }

        return result;
    }
}