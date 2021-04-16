using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CodeChallenges.Tests;

namespace CodeChallenges.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class LongestSubsetBenchmark
    {
        [Benchmark]
        public void SolveLongestSubset()
        {
            var integerArray = new int[100];

            var randNum = new Random();
            for (var i = 0; i < integerArray.Length; i++)
            {
                integerArray[i] = randNum.Next(-10, 10);
            }

            LongestSubset.Solve(integerArray, 3);
        }
    }
}