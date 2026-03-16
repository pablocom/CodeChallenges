namespace CodeChallenges.Solutions.Arrays;

public static class LongestSubarrayWithAbsDiffLimit
{
    public static int Solve(int[] nums, int limit)
    {
        var descendingMaxCandidates = new LinkedList<int>();
        var ascendingMinCandidates = new LinkedList<int>();

        var windowStart = 0;
        var longestWindow = 0;

        for (var windowEnd = 0; windowEnd < nums.Length; windowEnd++)
        {
            while (descendingMaxCandidates.Count > 0 && nums[descendingMaxCandidates.Last!.Value] <= nums[windowEnd])
                descendingMaxCandidates.RemoveLast();

            while (ascendingMinCandidates.Count > 0 && nums[ascendingMinCandidates.Last!.Value] >= nums[windowEnd])
                ascendingMinCandidates.RemoveLast();

            descendingMaxCandidates.AddLast(windowEnd);
            ascendingMinCandidates.AddLast(windowEnd);

            while (nums[descendingMaxCandidates.First!.Value] - nums[ascendingMinCandidates.First!.Value] > limit)
            {
                windowStart++;

                if (descendingMaxCandidates.First.Value < windowStart)
                    descendingMaxCandidates.RemoveFirst();

                if (ascendingMinCandidates.First.Value < windowStart)
                    ascendingMinCandidates.RemoveFirst();
            }

            longestWindow = Math.Max(longestWindow, windowEnd - windowStart + 1);
        }

        return longestWindow;
    }
}
