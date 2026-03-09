namespace CodeChallenges.Solutions;

public static class NumberOfIslands
{
    public static int Solve(char[][] grid)
    {
        var result = 0;

        for (int i = 0; i < grid.Length; i++)
        for (int j = 0; j < grid[i].Length; j++)
        {
            if (grid[i][j] is '1')
            {
                MarkIslandAsVisited(grid, i, j);
                result++;
            }
        }
        
        return result;
    }

    private static void MarkIslandAsVisited(char[][] grid, int x, int y)
    {
        if (x < 0 || x >= grid.Length)
            return;

        if (y < 0 || y >= grid[x].Length)
            return;

        if (grid[x][y] is not '1')
            return;

        grid[x][y] = 'X';
        
        MarkIslandAsVisited(grid, x + 1, y);
        MarkIslandAsVisited(grid, x, y + 1);
        MarkIslandAsVisited(grid, x - 1, y);
        MarkIslandAsVisited(grid, x, y - 1);
    }
}