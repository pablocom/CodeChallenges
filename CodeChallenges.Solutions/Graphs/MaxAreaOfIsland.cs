using System.Runtime.CompilerServices;

namespace CodeChallenges.Solutions.Graphs;

public static class MaxAreaOfIsland
{
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static int Solve(int[][] grid)
    {
        var maxArea = 0;
        
        for (var i = 0; i < grid.Length; i++)
        for (var j = 0; j < grid[i].Length; j++)
        {
            if (grid[i][j] is not 1)
                continue;

            var islandArea = TraverseIsland(grid, i, j);
            maxArea = Math.Max(maxArea, islandArea);
        }
        
        return maxArea;
    }

    private static int TraverseIsland(int[][] grid, int i, int j)
    {
        if (i < 0 || i >= grid.Length ||
            j < 0 || j >= grid[i].Length ||
            grid[i][j] is not 1)
            return 0;
        
        const int visitedMarker = -1;
        grid[i][j] = visitedMarker;
        
        var area = 1;
        
        area += TraverseIsland(grid, i + 1, j);
        area += TraverseIsland(grid, i - 1, j);
        area += TraverseIsland(grid, i, j + 1);
        area += TraverseIsland(grid, i, j - 1);
        
        return area;
    }
}