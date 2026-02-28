using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CodeChallenges.Solutions;
using CodeChallenges.Solutions.Strings;

namespace CodeChallenges.Benchmarks;

[MemoryDiagnoser(true)]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class RepeatedSubstringPatternBenchmarks
{
    [ParamsSource(nameof(Inputs))]
    public string Input { get; set; } = null!;

    public static IEnumerable<string> Inputs()
    {
        // Short repeating pattern
        yield return "abcabc";

        // Short non-repeating
        yield return "abcdef";

        // Medium repeating — "ab" x 500
        yield return new string('a', 500).Replace("a", "ab");

        // Medium non-repeating — 1000 chars, last char breaks the pattern
        yield return new string('a', 999) + "b";

        // Long repeating — "abcd" x 2500
        yield return string.Concat(Enumerable.Repeat("abcd", 2500));

        // Long non-repeating — 10000 chars, no repeat
        yield return string.Concat(Enumerable.Range(0, 10000).Select(i => (char)('a' + i % 26)));
    }

    [Benchmark(Baseline = true)]
    public bool Divisors() => RepeatedSubstringPattern.SolveWithDivisors(Input);

    [Benchmark]
    public bool Kmp() => RepeatedSubstringPattern.SolveWithKmp(Input);
}
