namespace CodeChallenges.Solutions.DataStructures;

public static class TaskScheduler
{
    public static int Solve(char[] tasks, int n)
    {
        var tasksCount = new Dictionary<char, int>();

        foreach (var task in tasks)
            if (!tasksCount.TryAdd(task, 1))
                tasksCount[task]++;

        var maxHeap = new MaxHeap<int>(tasksCount.Values);
        var queue = new Queue<(int RemainingExecutions, int NextAllowedTime)>();
        var time = 0;

        while (maxHeap.Count > 0 || queue.Count > 0)
        {
            time++;

            if (maxHeap.Count > 0)
            {
                var remainingExecutions = maxHeap.PopMax() - 1;
                if (remainingExecutions is not 0)
                    queue.Enqueue((remainingExecutions, time + n));
            }

            if (queue.Count > 0 && queue.Peek().NextAllowedTime == time)
            {
                maxHeap.Insert(queue.Dequeue().RemainingExecutions);
            }
        }
        
        return time;
    }

    public static int SolveWithFormula(char[] tasks, int n)
    {
        var frequencies = new int[26];

        foreach (var task in tasks)
            frequencies[task - 'A']++;

        var maxFrequency = frequencies.Max();
        var maxFrequencyCount = frequencies.Count(f => f == maxFrequency);

        // Idle slots are dictated by the most frequent task(s); remaining tasks fill the gaps
        var minLength = (maxFrequency - 1) * (n + 1) + maxFrequencyCount;

        return Math.Max(tasks.Length, minLength);
    }
}