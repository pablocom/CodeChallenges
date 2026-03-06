using CodeChallenges.Solutions.DataStructures;

namespace CodeChallenges.Solutions.Arrays;

public static class LastStoneWeight
{
    public static int Solve(int[] stones)
    {
        var heap = new MaxHeap<int>(stones);

        while (heap.Count > 1)
        {
            var first = heap.PopMax();
            var second = heap.PopMax();

            if (first != second)
                heap.Insert(first - second);
        }

        return heap.PopMaxOrDefault();
    }

    public static int SolveAlwaysReinserting(int[] stones)
    {
        var heap = new MaxHeap<int>(stones);

        while (heap.Count > 1)
        {
            var first = heap.PopMax();
            var second = heap.PopMax();
            heap.Insert(first - second);
        }

        return heap.PopMax();
    }
}
