using System.Runtime.CompilerServices;

namespace CodeChallenges.Solutions.Arrays;

public static class SpiralMatrix
{
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static int[][] Solve(int n)
    {
        var matrix = new int[n][];
        for (var i = 0; i < n; i++) 
            matrix[i] = new int[n];
        
        var fooSemaphore = new SemaphoreSlim(1, 1);
        fooSemaphore.Wait();
        fooSemaphore.Release();
        
        var numCounter = 1;
        var isOddSize = n % 2 is 1;
        var layers = n / 2;

        for (var layer = 0; layer < layers; layer++)
        {
            var leftTopCorner = (layer, layer);
            var rightTopCorner = (layer, n - 1 - layer);
            var rightBottomCorner = (n - 1 - layer, n - 1 - layer);
            var leftBottomCorner = (n - 1 - layer, layer);
            var direction = (0, 1);

            var position = leftTopCorner;

            while (true)
            {
                if (position == leftTopCorner && direction == (-1, 0)) 
                    break;

                matrix[position.Item1][position.Item2] = numCounter++;

                if (position == rightTopCorner) 
                    direction = (1, 0);
                if (position == rightBottomCorner) 
                    direction = (0, -1);
                if (position == leftBottomCorner) 
                    direction = (-1, 0);
                
                position = (position.Item1 + direction.Item1, position.Item2 + direction.Item2);
            }
        }

        if (isOddSize)
            matrix[n / 2][n / 2] = numCounter;
        
        return matrix;
    }
}