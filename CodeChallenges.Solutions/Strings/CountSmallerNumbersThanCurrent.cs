namespace CodeChallenges.Solutions.Strings;

public static class CountSmallerNumbersThanCurrent
{
    public static int[] Solve(int[] nums)
    {
        var lowerCountByNumber = new Dictionary<int, int>();

        var sortedNums = nums.ToArray(); sortedNums.Sort();

        for (var i = 0; i < sortedNums.Length; i++) 
            lowerCountByNumber.TryAdd(sortedNums[i], i);

        var result = new int[nums.Length];

        for (var i = 0; i < result.Length; i++)
            result[i] = lowerCountByNumber[nums[i]];

        return result;
    }
}