using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CodeChallenges.Solutions.Mathematics;

namespace CodeChallenges.Benchmarks;

[MemoryDiagnoser]
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