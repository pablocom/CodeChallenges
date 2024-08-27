using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CodeChallenges.Solutions;

namespace CodeChallenges.Benchmarks;

[MemoryDiagnoser]
[ShortRunJob]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class AvlTreeBenchmarks
{
    [Params(10, 1000, 10000, 100000, 1000000)]
    public int ItemsCount { get; set; }

    private readonly AvlTree<int> _tree = new();
    private readonly Random _random = new(69);
    
    [GlobalSetup]
    public void Setup()
    {
        for (var i = 0; i < ItemsCount; i++)
        {
            _tree.Insert(_random.Next());
        }
    }

    [Benchmark]
    public void InsertItemsIntoAvlTree()
    {
        for (int i = 0; i < 10; i++)
        {
            _tree.Insert(_random.Next());
        }
    }
}