namespace CodeChallenges.Solutions.Backtracking;

public static class WordSearch
{
    public static bool Solve(char[][] board, string word)
    {
        var wordSpan = word.AsSpan();

        for (var i = 0; i < board.Length; i++)
            for (var j = 0; j < board[i].Length; j++)
            {
                if (wordSpan[0] != board[i][j])
                    continue;

                var canFormEntireWord = TraverseWord(wordSpan, board, i, j, 0);
                if (canFormEntireWord)
                    return true;
            }

        return false;
    }

    private static bool TraverseWord(ReadOnlySpan<char> wordSpan, char[][] board, int i, int j, int actualPosition)
    {
        if (actualPosition == wordSpan.Length - 1)
            return true;

        var nextPosition = actualPosition + 1;
        var nextWordChar = wordSpan[nextPosition];

        var tempChar = board[i][j];
        board[i][j] = '#';

        var found = false;
        
        if (i + 1 < board.Length && board[i + 1][j] == nextWordChar)
            found = TraverseWord(wordSpan, board, i + 1, j, nextPosition);

        if (!found && j + 1 < board[i].Length && board[i][j + 1] == nextWordChar)
            found = TraverseWord(wordSpan, board, i, j + 1, nextPosition);

        if (!found && i - 1 >= 0 && board[i - 1][j] == nextWordChar)
            found = TraverseWord(wordSpan, board, i - 1, j, nextPosition);

        if (!found && j - 1 >= 0 && board[i][j - 1] == nextWordChar)
            found = TraverseWord(wordSpan, board, i, j - 1, nextPosition);

        board[i][j] = tempChar;
        return found;
    }
}
