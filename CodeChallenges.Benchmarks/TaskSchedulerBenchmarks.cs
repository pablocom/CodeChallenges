using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using TaskScheduler = CodeChallenges.Solutions.DataStructures.TaskScheduler;

namespace CodeChallenges.Benchmarks;

[ShortRunJob]
[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class TaskSchedulerBenchmarks
{
    [Params(12, 100, 1000)]
    public int TaskCount { get; set; }

    private char[] _tasks = null!;
    private const int CooldownInterval = 2;

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random(69);
        _tasks = new char[TaskCount];

        for (var i = 0; i < TaskCount; i++)
            _tasks[i] = (char)('A' + random.Next(0, 6));
    }

    [Benchmark(Description = "Greedy + MaxHeap")]
    public int Solve() => TaskScheduler.Solve(_tasks, CooldownInterval);

    [Benchmark(Description = "Math Formula")]
    public int SolveWithFormula() => TaskScheduler.SolveWithFormula(_tasks, CooldownInterval);
}
