using System.Runtime.CompilerServices;

namespace CodeChallenges.Solutions.DynamicProgramming;

public static class MinimumPathSum
{
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static int Solve(int[][] grid)
    {
        for (var i = grid.Length - 1; i >= 0; i--)
        for (var j = grid[i].Length - 1; j >= 0; j--)
        {
            var downMin = i + 1 < grid.Length ? grid[i + 1][j] : int.MaxValue;
            var rightMin = j + 1 < grid[i].Length ? grid[i][j + 1] : int.MaxValue;

            var min = Math.Min(downMin, rightMin);
            grid[i][j] += min is int.MaxValue ? 0 : min;
        }

        return grid[0][0];
    }
}
