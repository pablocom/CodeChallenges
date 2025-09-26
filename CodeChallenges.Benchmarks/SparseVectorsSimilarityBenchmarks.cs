using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CodeChallenges.Solutions;

namespace CodeChallenges.Benchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[ShortRunJob]
[RankColumn]
public class SparseVectorsSimilarityBenchmarks
{
    [Params(16384)]
    public int NonZeroIndexes { get; set; }

    [Params(25, 75)]
    public int OverlapPercent { get; set; }

    private List<int> _keysA = null!;
    private List<double> _valsA = null!;
    private List<int> _keysB = null!;
    private List<double> _valsB = null!;

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random(420);

        var buildArgs = Enumerable.Range(0, NonZeroIndexes)
            .Where(x => x % 2 == 0)
            .Select(x => new IndexBuildArguments(x, random.Next(0, 100) < OverlapPercent))
            .ToArray();
        
        _keysA = buildArgs.Select(x => x.Value).ToList();
        _valsA = Enumerable.Range(0, buildArgs.Length).Select(_ => random.NextDouble()).ToList();

        _keysB = buildArgs.Select(x => x.HasOverlapping ? x.Value : x.Value + 1).ToList();
        _valsB = Enumerable.Range(0, buildArgs.Length).Select(_ => random.NextDouble()).ToList();
    }
    
    [Benchmark(Baseline = true, Description = "List<T> indexing (no ReadOnlySpan)")]
    public double Cosine_NoReadOnlySpan()
        => SparseVectorsSimilarity.Solve(_keysA, _valsA, _keysB, _valsB);

    [Benchmark(Description = "CollectionsMarshal.AsSpan + ReadOnlySpan")]
    public double Cosine_WithReadOnlySpan()
        => SparseVectorsSimilarity.SolveOptimized(_keysA, _valsA, _keysB, _valsB);
}
public record struct IndexBuildArguments(int Value, bool HasOverlapping);