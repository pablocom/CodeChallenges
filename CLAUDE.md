# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Overview

C# .NET 10.0 repository of algorithm and data structure solutions, organized by category (Arrays, Strings, Backtracking, DynamicProgramming, Graphs, etc.). Three projects: solutions library, xUnit tests, and BenchmarkDotNet benchmarks.

## Build & Test Commands

```bash
dotnet build                                          # Build entire solution
dotnet test                                           # Run all tests
dotnet test --filter "FullyQualifiedName~ClassName"   # Run tests for a specific problem
dotnet run --project CodeChallenges.Benchmarks        # Run benchmarks
```

## Architecture

- **CodeChallenges.Solutions/**: Problem solutions organized by category (e.g., `Arrays/`, `DynamicProgramming/`, `Graphs/`). Solutions are typically static classes with a `Solve()` entry point.
- **CodeChallenges.UnitTests/**: Mirrors the Solutions directory structure exactly. Uses xUnit + Shouldly (imported globally via `GlobalUsings.cs`). Includes custom test infrastructure in `Builders/` (e.g., `ListNodeBuilder` for linked lists) and `LinkedListAssert.cs`.
- **CodeChallenges.Benchmarks/**: BenchmarkDotNet performance tests for selected algorithms.

## Conventions

- New solutions go in `CodeChallenges.Solutions/{Category}/` with a matching test file in `CodeChallenges.UnitTests/{Category}/`.
- Namespace pattern: `CodeChallenges.Solutions.{Category}` / `CodeChallenges.UnitTests.{Category}`.
- Solution file uses `.slnx` format (lightweight solution file).
