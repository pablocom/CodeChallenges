using CodeChallenges.Solutions.DataStructures;

namespace CodeChallenges.Solutions.Arrays;

public static class KthLargest
{
    public static int SolveWithSort(int[] nums, int k)
    {
        Array.Sort(nums);

        return nums[nums.Length - 1 - (k - 1)];
    }

    public static int SolveWithMaxHeap(int[] nums, int k)
    {
        var heap = new MaxHeap<int>(nums);

        for (var i = 1; i < k; i++)
            heap.PopMax();

        return heap.PopMax();
    }
}