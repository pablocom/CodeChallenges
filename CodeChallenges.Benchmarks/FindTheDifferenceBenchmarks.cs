using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CodeChallenges.Solutions.Strings;

namespace CodeChallenges.Benchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class FindTheDifferenceBenchmarks
{
    [ParamsSource(nameof(Inputs))]
    public (string S, string T) Input { get; set; }

    public static IEnumerable<(string S, string T)> Inputs()
    {
        // Short strings
        yield return ("abcd", "abcde");

        // Empty s
        yield return ("", "y");

        // Medium strings — 500 chars + 1 extra
        var medium = new string(Enumerable.Range(0, 500).Select(i => (char)('a' + i % 26)).ToArray());
        yield return (medium, medium + 'z');

        // Long strings — 10000 chars + 1 extra
        var longStr = new string(Enumerable.Range(0, 10000).Select(i => (char)('a' + i % 26)).ToArray());
        yield return (longStr, longStr + 'z');
    }

    [Benchmark(Baseline = true)]
    public char Dictionary() => FindTheDifference.SolveWithDictionary(Input.S, Input.T);

    [Benchmark]
    public char Xor() => FindTheDifference.SolveWithXor(Input.S, Input.T);
}
