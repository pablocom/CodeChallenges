namespace CodeChallenges.Solutions;

public class SpiralOrderSolution
{
    private enum Direction
    {
        Right, 
        Down,
        Left,
        Up,
    }

    public IList<int> SpiralOrder(int[][] matrix)
    {
        var result = new List<int>();

        var topLimit = 0;
        var bottomLimit = matrix.Length - 1;
        var leftLimit = 0;
        var rightLimit = matrix[0].Length - 1;

        var direction = Direction.Right;
        var x = 0;
        var y = 0;
        var changedDirection = false;

        while (result.Count < matrix.Length * matrix[0].Length)
        {
            if (!changedDirection)
                result.Add(matrix[x][y]);

            switch (direction)
            {
                case Direction.Right:
                    if (y < rightLimit)
                    {
                        y++;
                        changedDirection = false;
                    }
                    else
                    {
                        direction = Direction.Down;
                        topLimit++;
                        changedDirection = true;
                    }
                    break;

                case Direction.Down:
                    if (x < bottomLimit)
                    {
                        x++;
                        changedDirection = false;
                    }
                    else
                    {
                        direction = Direction.Left;
                        rightLimit--;
                        changedDirection = true;
                    }
                    break;

                case Direction.Left:
                    if (y > leftLimit)
                    {
                        y--;
                        changedDirection = false;
                    }
                    else
                    {
                        direction = Direction.Up;
                        bottomLimit--;
                        changedDirection = true;
                    }
                    break;

                case Direction.Up:
                    if (x > topLimit)
                    {
                        x--;
                        changedDirection = false;
                    }
                    else
                    {
                        direction = Direction.Right;
                        leftLimit++;
                        changedDirection = true;
                    }
                    break;
            }
        }

        return result;
    }
}
