using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CodeChallenges.Solutions.Backtracking;

namespace CodeChallenges.Benchmarks;

[ShortRunJob]
[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class SudokuSolverBenchmarks
{
    private char[][] _templateAiEscargot = null!;
    private char[][] _templateMinimum17Clue = null!;
    private char[][] _templatePlatinumBlonde = null!;

    private char[][] _optimizedBoard = null!;
    private char[][] _flatBoard = null!;
    private char[][] _naiveBoard = null!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _templateAiEscargot = ParseBoard(
            "1.....7.9" +
            ".3..2...8" +
            "..96..5.." +
            "..53..9.." +
            ".1..8...2" +
            "6....4..." +
            "3......1." +
            ".4......7" +
            "..3.....6");

        _templateMinimum17Clue = ParseBoard(
            ".......1." +
            "4........" +
            ".2......." +
            "....5.4.7" +
            "..8...3.." +
            "..1.9...." +
            "3..4..2.." +
            ".5.1....." +
            "...8.6...");

        _templatePlatinumBlonde = ParseBoard(
            ".........."+
            "......3.85"+
            "..1.2...." +
            "...5.7..." +
            "..4...1.." +
            ".9......."+
            "5......73" +
            "..2.1...." +
            "....4...9");
    }

    // --- AI Escargot ---

    [IterationSetup(Target = nameof(Optimized_AiEscargot))]
    public void SetupOptimized_AiEscargot() => _optimizedBoard = Clone(_templateAiEscargot);

    [IterationSetup(Target = nameof(Flat_AiEscargot))]
    public void SetupFlat_AiEscargot() => _flatBoard = Clone(_templateAiEscargot);

    [IterationSetup(Target = nameof(Naive_AiEscargot))]
    public void SetupNaive_AiEscargot() => _naiveBoard = Clone(_templateAiEscargot);

    [Benchmark(Baseline = true, Description = "Optimized - AI Escargot")]
    public void Optimized_AiEscargot() => SudokuSolver.Solve(_optimizedBoard);

    [Benchmark(Description = "Flat - AI Escargot")]
    public void Flat_AiEscargot() => SudokuSolver.SolveFlat(_flatBoard);

    [Benchmark(Description = "Naive - AI Escargot")]
    public void Naive_AiEscargot() => NaiveSudokuSolver.Solve(_naiveBoard);

    // --- 17-Clue Minimum ---

    [IterationSetup(Target = nameof(Optimized_Minimum17Clue))]
    public void SetupOptimized_Minimum17Clue() => _optimizedBoard = Clone(_templateMinimum17Clue);

    [IterationSetup(Target = nameof(Flat_Minimum17Clue))]
    public void SetupFlat_Minimum17Clue() => _flatBoard = Clone(_templateMinimum17Clue);

    [IterationSetup(Target = nameof(Naive_Minimum17Clue))]
    public void SetupNaive_Minimum17Clue() => _naiveBoard = Clone(_templateMinimum17Clue);

    [Benchmark(Description = "Optimized - 17-Clue Minimum")]
    public void Optimized_Minimum17Clue() => SudokuSolver.Solve(_optimizedBoard);

    [Benchmark(Description = "Flat - 17-Clue Minimum")]
    public void Flat_Minimum17Clue() => SudokuSolver.SolveFlat(_flatBoard);

    [Benchmark(Description = "Naive - 17-Clue Minimum")]
    public void Naive_Minimum17Clue() => NaiveSudokuSolver.Solve(_naiveBoard);

    // --- Platinum Blonde ---

    [IterationSetup(Target = nameof(Optimized_PlatinumBlonde))]
    public void SetupOptimized_PlatinumBlonde() => _optimizedBoard = Clone(_templatePlatinumBlonde);

    [IterationSetup(Target = nameof(Flat_PlatinumBlonde))]
    public void SetupFlat_PlatinumBlonde() => _flatBoard = Clone(_templatePlatinumBlonde);

    [IterationSetup(Target = nameof(Naive_PlatinumBlonde))]
    public void SetupNaive_PlatinumBlonde() => _naiveBoard = Clone(_templatePlatinumBlonde);

    [Benchmark(Description = "Optimized - Platinum Blonde")]
    public void Optimized_PlatinumBlonde() => SudokuSolver.Solve(_optimizedBoard);

    [Benchmark(Description = "Flat - Platinum Blonde")]
    public void Flat_PlatinumBlonde() => SudokuSolver.SolveFlat(_flatBoard);

    [Benchmark(Description = "Naive - Platinum Blonde")]
    public void Naive_PlatinumBlonde() => NaiveSudokuSolver.Solve(_naiveBoard);

    private static char[][] Clone(char[][] board)
    {
        var clone = new char[9][];
        for (var i = 0; i < 9; i++)
        {
            clone[i] = new char[9];
            board[i].AsSpan().CopyTo(clone[i]);
        }
        return clone;
    }

    private static char[][] ParseBoard(string flat)
    {
        var board = new char[9][];
        for (var i = 0; i < 9; i++)
        {
            board[i] = new char[9];
            for (var j = 0; j < 9; j++)
                board[i][j] = flat[i * 9 + j];
        }
        return board;
    }
}
