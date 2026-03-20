namespace CodeChallenges.Solutions.Arrays;

public static class TopKFrequent
{
    public static int[] Solve(int[] nums, int k)
    {
        var occurrencesByNumber = new Dictionary<int, int>();

        foreach (var number in nums)
        {
            if (occurrencesByNumber.TryGetValue(number, out _))
                occurrencesByNumber[number]++;
            else
                occurrencesByNumber.Add(number, 1);
        }

        var minHeap = new PriorityQueue<int, int>(k);

        foreach (var keyValuePair in occurrencesByNumber)
        {
            if (minHeap.Count < k)
            {
                minHeap.Enqueue(keyValuePair.Key, keyValuePair.Value);
                continue;
            }


            if (minHeap.TryPeek(out _, out var priority) && priority < keyValuePair.Value)
            {
                minHeap.Dequeue();
                minHeap.Enqueue(keyValuePair.Key, keyValuePair.Value);
            }
        }
        
        return minHeap.UnorderedItems.Select(x => x.Element).ToArray();
    }
}