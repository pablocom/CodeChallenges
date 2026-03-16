using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CodeChallenges.Solutions.LinkedLists;

namespace CodeChallenges.Benchmarks;

[ShortRunJob]
[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class MergeKSortedListsBenchmarks
{
    [Params(10, 100, 1000)]
    public int ListCount { get; set; }

    private ListNode[] _lists = null!;

    [IterationSetup]
    public void Setup()
    {
        _lists = new ListNode[ListCount];

        for (var i = 0; i < ListCount; i++)
        {
            var head = new ListNode(i * 5 + 1);
            var current = head;
            for (var j = 2; j <= 5; j++)
            {
                current.next = new ListNode(i * 5 + j);
                current = current.next;
            }

            _lists[i] = head;
        }
    }

    [Benchmark(Description = "Min-Heap")]
    public ListNode? SolveWithMinHeap() => MergeKSortedLists.Solve(CopyLists());

    [Benchmark(Description = "Divide and Conquer")]
    public ListNode? SolveOptimized() => MergeKSortedLists.SolveOptimized(CopyLists());

    [Benchmark(Description = "Divide and Conquer (recursive)")]
    public ListNode SolveWithDivideAndConquer() => new MergeKListsSolution().MergeKLists(CopyLists());

    private ListNode[] CopyLists()
    {
        var copy = new ListNode[_lists.Length];
        Array.Copy(_lists, copy, _lists.Length);
        return copy;
    }
}
