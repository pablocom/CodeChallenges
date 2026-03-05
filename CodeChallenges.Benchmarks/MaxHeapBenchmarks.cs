using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CodeChallenges.Solutions.DataStructures;

namespace CodeChallenges.Benchmarks;

[ShortRunJob]
[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class MaxHeapBenchmarks
{
    [Params(1000, 10000)]
    public int ItemsCount { get; set; }

    private int[] _data = null!;
    private (int Element, int Priority)[] _priorityQueueData = null!;

    private MaxHeap<int> _populatedMaxHeap = null!;
    private PriorityQueue<int, int> _populatedPriorityQueue = null!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var random = new Random(69);
        _data = new int[ItemsCount];

        for (var i = 0; i < ItemsCount; i++)
            _data[i] = random.Next();

        _priorityQueueData = new (int, int)[ItemsCount];
        for (var i = 0; i < ItemsCount; i++)
            _priorityQueueData[i] = (_data[i], _data[i]);
    }

    [IterationSetup(Targets = [nameof(PopAll_MaxHeap), nameof(PopAll_PriorityQueue)])]
    public void SetupPopulatedHeaps()
    {
        _populatedMaxHeap = new MaxHeap<int>(_data);
        _populatedPriorityQueue = new PriorityQueue<int, int>(_priorityQueueData, ReverseComparer.Instance);
    }

    // ----- Insert N items -----

    [Benchmark(Description = "Insert N — MaxHeap")]
    public MaxHeap<int> Insert_MaxHeap()
    {
        var heap = new MaxHeap<int>(ItemsCount);

        for (var i = 0; i < _data.Length; i++)
            heap.Insert(_data[i]);

        return heap;
    }

    [Benchmark(Description = "Insert N — PriorityQueue")]
    public PriorityQueue<int, int> Insert_PriorityQueue()
    {
        var queue = new PriorityQueue<int, int>(ItemsCount, ReverseComparer.Instance);

        for (var i = 0; i < _data.Length; i++)
            queue.Enqueue(_data[i], _data[i]);

        return queue;
    }

    // ----- Pop/Dequeue all items -----

    [Benchmark(Description = "Pop all — MaxHeap")]
    public int PopAll_MaxHeap()
    {
        var last = 0;

        while (_populatedMaxHeap.Count > 0)
            last = _populatedMaxHeap.PopMaxOrDefault();

        return last;
    }

    [Benchmark(Description = "Pop all — PriorityQueue")]
    public int PopAll_PriorityQueue()
    {
        var last = 0;

        while (_populatedPriorityQueue.Count > 0)
            last = _populatedPriorityQueue.Dequeue();

        return last;
    }

    // ----- Peek -----

    [Benchmark(Description = "Peek — MaxHeap")]
    public int Peek_MaxHeap()
    {
        var heap = new MaxHeap<int>(_data);
        return heap.PeekMaxOrDefault();
    }

    [Benchmark(Description = "Peek — PriorityQueue")]
    public int Peek_PriorityQueue()
    {
        var queue = new PriorityQueue<int, int>(_priorityQueueData, ReverseComparer.Instance);
        return queue.Peek();
    }

    // ----- Bulk construction -----

    [Benchmark(Description = "Bulk build — MaxHeap")]
    public MaxHeap<int> BulkBuild_MaxHeap()
    {
        return new MaxHeap<int>(_data);
    }

    [Benchmark(Description = "Bulk build — PriorityQueue")]
    public PriorityQueue<int, int> BulkBuild_PriorityQueue()
    {
        return new PriorityQueue<int, int>(_priorityQueueData, ReverseComparer.Instance);
    }

    private sealed class ReverseComparer : IComparer<int>
    {
        public static readonly ReverseComparer Instance = new();

        public int Compare(int x, int y) => y.CompareTo(x);
    }
}
