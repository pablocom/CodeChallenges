using System.Runtime.CompilerServices;

namespace CodeChallenges.Solutions.Backtracking;

public static class UniquePaths2
{
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        var memoization = new Dictionary<(int X, int Y), int>(obstacleGrid.Length * obstacleGrid[0].Length);
        var uniquePaths = TraversePaths(obstacleGrid, 0, 0, memoization);
        
        return uniquePaths;
    }

    private static int TraversePaths(int[][] obstacleGrid, int x, int y, Dictionary<(int X, int Y), int> memoization)
    {
        if (memoization.TryGetValue((x, y), out var cachedNumberOfPaths))
            return cachedNumberOfPaths;
        
        if (obstacleGrid[x][y] is 1)
            return 0;
        
        if (x == obstacleGrid.Length - 1 && y == obstacleGrid[0].Length - 1)
            return 1;

        var numberOfPaths = 0;
        if (x < obstacleGrid.Length - 1)
            numberOfPaths += TraversePaths(obstacleGrid, x + 1, y, memoization);
        
        if (y < obstacleGrid[0].Length - 1)
            numberOfPaths += TraversePaths(obstacleGrid, x, y + 1, memoization);

        memoization.Add((x, y), numberOfPaths);
        
        return numberOfPaths;
    }
}