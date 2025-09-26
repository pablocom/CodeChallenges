using BenchmarkDotNet.Running;
using CodeChallenges.Benchmarks;

var switcher = BenchmarkSwitcher.FromAssembly(typeof(IAssemblyMarker).Assembly);

switcher.Run(args);