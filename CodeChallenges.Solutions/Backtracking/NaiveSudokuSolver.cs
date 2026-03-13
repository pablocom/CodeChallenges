namespace CodeChallenges.Solutions.Backtracking;

public static class NaiveSudokuSolver
{
    public static void Solve(char[][] board)
    {
        Backtrack(board, 0, 0);
    }

    private static bool Backtrack(char[][] board, int row, int col)
    {
        if (row == 9)
            return true;

        var nextRow = col == 8 ? row + 1 : row;
        var nextCol = col == 8 ? 0 : col + 1;

        if (board[row][col] != '.')
            return Backtrack(board, nextRow, nextCol);

        for (var num = '1'; num <= '9'; num++)
        {
            if (!IsValid(board, row, col, (char)num))
                continue;

            board[row][col] = (char)num;

            if (Backtrack(board, nextRow, nextCol))
                return true;

            board[row][col] = '.';
        }

        return false;
    }

    private static bool IsValid(char[][] board, int row, int col, char num)
    {
        for (var i = 0; i < 9; i++)
        {
            if (board[row][i] == num)
                return false;

            if (board[i][col] == num)
                return false;
        }

        var boxRow = (row / 3) * 3;
        var boxCol = (col / 3) * 3;

        for (var r = boxRow; r < boxRow + 3; r++)
            for (var c = boxCol; c < boxCol + 3; c++)
                if (board[r][c] == num)
                    return false;

        return true;
    }
}
