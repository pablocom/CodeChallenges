﻿using System;
using BenchmarkDotNet.Running;

namespace CodeChallenges.Benchmarks;

class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<RomanToIntBenchmarks>();
    }
}