using System;
using System.Buffers;
using System.Collections.Frozen;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace CodeChallenges.Benchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class SearchValuesBenchmark
{
    [Params(
        "pablocom91458hr8f4e87e1347r8g+123@gmail.com", 
        "pablocom91458hr8f4e87e1347r8g123@gmail.com", 
        "pablocom91458hr8f4e87e1347r8g12387yhgrfioe87yf9o8s7duhvro8sdy7ho8v7ysd89o7y9o8s7fgydr78oyfg8r7seyfg78sdygo87ysdog87yrsdo8fg7sydog87ysedro8g7y@gmail.com"
    )]
    public string NickName { get; set; }

    [Benchmark]
    public void Nickname_From_SearchValues()
    {
        _ = Nickname.IsValid_SearchValues(NickName);
    }

    [Benchmark]
    public void Nickname_From_FrozenSet()
    {
        _ = Nickname.IsValid_FrozenSet(NickName);
    }
}


public sealed class Nickname
{
    private static readonly FrozenSet<char> _charactersToTrimFrozenSet = new[] { '.', '_', '-', '+' }.ToFrozenSet();
    private static readonly SearchValues<char> _charactersToTrimSearchValues = SearchValues.Create(['.', '_', '-', '+']);

    public string Value { get; }

    public Nickname(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        Value = value;
    }

    public static bool IsValid_FrozenSet(string username)
    {
        foreach (var character in username)
        {
            if (_charactersToTrimFrozenSet.Contains(character))
                return false;
        }

        return true;
    }

    public static bool IsValid_SearchValues(string username)
    {
        foreach (var character in username)
        {
            if (_charactersToTrimSearchValues.Contains(character))
                return false;
        }

        return true;
    }
}