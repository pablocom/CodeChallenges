# CodeChallenges

A collection of 113+ algorithm and data structure solutions implemented in C# (.NET 10.0), with comprehensive unit tests and performance benchmarks.

## Categories

| Category | Solutions |
|---|---|
| Arrays | 27 |
| Strings | 20 |
| DynamicProgramming | 11 |
| LinkedLists | 10 |
| BinaryTrees | 9 |
| Backtracking | 8 |
| Graphs | 8 |
| Mathematics | 6 |
| DataStructures | 5 |
| Searching | 5 |
| Assessments | 3 |
| Concurrency | 1 |

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

## Getting Started

```bash
# Build
dotnet build

# Run all tests
dotnet test

# Run tests for a specific problem
dotnet test --filter "FullyQualifiedName~SudokuSolver"

# Run benchmarks
dotnet run --project CodeChallenges.Benchmarks
```

## Project Structure

```
CodeChallenges.Solutions/       # Problem solutions organized by category
CodeChallenges.UnitTests/       # xUnit + FluentAssertions tests (mirrors Solutions structure)
CodeChallenges.Benchmarks/      # BenchmarkDotNet performance benchmarks
```
