using BenchmarkDotNet.Running;
using CodeChallenges.Benchmarks;

BenchmarkSwitcher
    .FromAssembly(typeof(IAssemblyMarker).Assembly)
    .Run(args);
