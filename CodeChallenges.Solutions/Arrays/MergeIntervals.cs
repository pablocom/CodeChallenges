namespace CodeChallenges.Solutions.Arrays;

public static class MergeIntervals
{
    public static IList<int[]> Solve(int[][] intervals)
    {
        if (intervals.Length <= 1) 
            return intervals;

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        var merged = new List<int[]>();
        
        var currentInterval = intervals[0];
        merged.Add(currentInterval);

        foreach (var interval in intervals)
        {
            var currentEnd = currentInterval[1];
            var nextStart = interval[0];
            var nextEnd = interval[1];

            if (currentEnd >= nextStart) 
                currentInterval[1] = Math.Max(currentEnd, nextEnd);
            else 
            {
                currentInterval = interval;
                merged.Add(currentInterval);
            }
        }

        return merged.ToArray();
    }
}