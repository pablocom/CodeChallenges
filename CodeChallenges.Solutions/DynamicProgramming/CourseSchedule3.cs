namespace CodeChallenges.Solutions.DynamicProgramming;

public static class CourseSchedule3
{
    public static int Solve(int[][] courses)
    {
        Array.Sort(courses, static (c1, c2) => c1[1].CompareTo(c2[1]));

        var maxHeap = new PriorityQueue<int, int>(new ReverseIntegerComparer());
        var currentTime = 0;

        foreach (var course in courses)
        {
            var duration = course[0];
            var deadline = course[1];

            maxHeap.Enqueue(duration, duration);
            currentTime += duration;

            if (currentTime > deadline)
            {
                var longestDuration = maxHeap.Dequeue();
                currentTime -= longestDuration;
            }
        }

        return maxHeap.Count;
    }

    private sealed class ReverseIntegerComparer : IComparer<int>
    {
        public int Compare(int x, int y) => y.CompareTo(x);
    }
}
