namespace CodeChallenges.Solutions.DynamicProgramming;

public static class MaximalSquare
{
    public static int Solve(char[][] matrix)
    {
        var maxArea = 0;
        
        var cache = new int[matrix.Length][];
        for (var i = 0; i < matrix.Length; i++)
            cache[i] = new int[matrix[0].Length];
        
        for (var i = matrix.Length - 1; i >= 0; i--)
        for (var j = matrix[i].Length - 1; j >= 0; j--)
        {
            if (matrix[i][j] is '0')
                continue;

            var perimeterRight = i + 1 > matrix.Length - 1 ? 0 : Convert.ToInt32(matrix[i + 1][j]);
            var perimeterDown = j + 1 > matrix[i].Length - 1 ? 0 : Convert.ToInt32(matrix[i][j + 1]);

            cache[i][j] = 1 + Math.Min(perimeterRight, perimeterDown);
            maxArea = Math.Max(maxArea, cache[i][j] * cache[i][j]);
        }
        
        return maxArea;
    }
}