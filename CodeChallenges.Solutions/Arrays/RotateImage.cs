using System.Runtime.CompilerServices;

namespace CodeChallenges.Solutions.Arrays;

public static class RotateImage
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Solve(int[][] matrix)
    {
        var imageSize = matrix.Length;
        var layers = imageSize / 2;

        for (var layer = 0; layer < layers; layer++)
        {
            var rotations = (imageSize - 2 * layer) - 1;

            for (var rotation = 0; rotation < rotations; rotation++)
            {
                var topLeftValue = matrix[layer][layer + rotation];
                var topRightValue = matrix[layer + rotation][matrix.Length - 1 - layer];
                var bottomRightValue = matrix[matrix.Length - 1 - layer][matrix.Length - 1 - layer - rotation];
                var bottomLeftValue = matrix[matrix.Length - 1 - layer - rotation][layer];

                matrix[layer][layer + rotation] 
                    = bottomLeftValue;
                matrix[layer + rotation][matrix.Length - 1 - layer] 
                    = topLeftValue;
                matrix[matrix.Length - 1 - layer][matrix.Length - 1 - layer - rotation] 
                    = topRightValue;
                matrix[matrix.Length - 1 - layer - rotation][layer] 
                    = bottomRightValue;
            }
        }
    }
}