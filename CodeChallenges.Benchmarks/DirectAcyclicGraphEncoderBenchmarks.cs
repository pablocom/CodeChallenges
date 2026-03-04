using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CodeChallenges.Solutions.Graphs;

namespace CodeChallenges.Benchmarks;

[ShortRunJob]
[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class DirectAcyclicGraphEncoderBenchmarks
{
    private GraphNode _simpleGraph = null!;
    private GraphNode _largeGraph = null!;

    [GlobalSetup]
    public void Setup()
    {
        _simpleGraph = BuildCompleteGraph(5);
        _largeGraph = BuildCompleteGraph(50);
    }

    [Benchmark(Baseline = true, Description = "Original (5 nodes)")]
    public string Simple() => DirectAcyclicGraphEncoder.Encode(_simpleGraph);
    
    [Benchmark(Description = "Original (50 nodes)")]
    public string Large() => DirectAcyclicGraphEncoder.Encode(_largeGraph);

    private static GraphNode BuildCompleteGraph(int nodeCount)
    {
        var rng = new Random(42);
        var nodes = new List<GraphNode>();

        for (var i = 0; i < nodeCount; i++)
            nodes.Add(new GraphNode(rng.Next(-1000, 1000)));

        for (var i = 0; i < nodeCount; i++)
            for (var j = i + 1; j < nodeCount; j++)
                nodes[i].Neighbors.Add(nodes[j]);

        return nodes[0];
    }
}
