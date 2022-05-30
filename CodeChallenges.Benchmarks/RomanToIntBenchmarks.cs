using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CodeChallenges.Solutions;

namespace CodeChallenges.Benchmarks;

[MemoryDiagnoser(true)]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class RomanToIntBenchmarks
{
    private static readonly string RomanNumeralToConvert = "MCMXXXVII";
    private static readonly RomanToInt RomanToInt = new RomanToInt();
    
    [Benchmark]
    public void WithSpan()
    {
        RomanToInt.Solve(RomanNumeralToConvert);
    }
        
    [Benchmark]
    public void WithStrings()
    {
        RomanToInt.SolveWithoutSpan(RomanNumeralToConvert);
    }
}