namespace CodeChallenges.Solutions;

public class NumberOfClusters
{
    public static int Rows { get; set; }
    public static int Cols { get; set; }

    public static int NumIslands(char[][] grid)
    {
        if (grid == null || grid.Length <= 0) return 0;
        int count = 0;

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == '1')
                {
                    DiscoverClusterRecursively(grid, i, j);
                    count++;
                }
            }
        }
        return count;
    }

    private static void DiscoverClusterRecursively(char[][] grid, int i, int j)
    {
        if (i < 0 || i >= grid.Length || j < 0 || j >= grid[i].Length || grid[i][j] == '0') return;
        grid[i][j] = '0';

        DiscoverClusterRecursively(grid, i + 1, j);
        DiscoverClusterRecursively(grid, i - 1, j);
        DiscoverClusterRecursively(grid, i, j + 1);
        DiscoverClusterRecursively(grid, i, j - 1);
    }
}