﻿using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CodeChallenges.Solutions;

namespace CodeChallenges.Benchmarks;

[MemoryDiagnoser(false)]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class LongestSubsetBenchmark
{
    [Benchmark]
    public void SolveLongestSubset()
    {
        var integerArray = new int[300];
        var randNum = new Random();
        for (var i = 0; i < integerArray.Length; i++)
        {
            integerArray[i] = randNum.Next(-10, 10);
        }

        LongestSubset.Solve(integerArray, 3);
    }
        
    [Benchmark]
    public void SolveLongestSubsetOptimized()
    {
        var integerArray = new int[200];

        var randNum = new Random();
        for (var i = 0; i < integerArray.Length; i++)
        {
            integerArray[i] = randNum.Next(-10, 10);
        }

        LongestSubset.SolveOptimized(integerArray, 3);
    }
}