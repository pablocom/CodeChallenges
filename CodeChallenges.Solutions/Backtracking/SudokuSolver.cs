using System.Numerics;

namespace CodeChallenges.Solutions.Backtracking;

public static class SudokuSolver
{
    public static void Solve(char[][] board)
    {
        Span<int> rowMasks = stackalloc int[9];
        Span<int> colMasks = stackalloc int[9];
        Span<int> boxMasks = stackalloc int[9];

        Span<int> emptyCells = stackalloc int[81];
        var emptyCount = 0;

        for (var r = 0; r < 9; r++)
        {
            for (var c = 0; c < 9; c++)
            {
                if (board[r][c] == '.')
                {
                    emptyCells[emptyCount++] = r * 9 + c;
                }
                else
                {
                    var val = board[r][c] - '0';
                    var bit = 1 << val;
                    rowMasks[r] |= bit;
                    colMasks[c] |= bit;

                    var b = (r / 3) * 3 + (c / 3);
                    boxMasks[b] |= bit;
                }
            }
        }

        Backtrack(board, emptyCells, emptyCount, rowMasks, colMasks, boxMasks);
    }

    public static void SolveFlat(char[][] board)
    {
        Span<char> flat = stackalloc char[81];
        Span<int> rowMasks = stackalloc int[9];
        Span<int> colMasks = stackalloc int[9];
        Span<int> boxMasks = stackalloc int[9];

        Span<int> emptyCells = stackalloc int[81];
        var emptyCount = 0;

        for (var r = 0; r < 9; r++)
        {
            for (var c = 0; c < 9; c++)
            {
                var idx = r * 9 + c;
                var ch = board[r][c];
                flat[idx] = ch;

                if (ch == '.')
                {
                    emptyCells[emptyCount++] = idx;
                }
                else
                {
                    var bit = 1 << (ch - '0');
                    rowMasks[r] |= bit;
                    colMasks[c] |= bit;
                    boxMasks[(r / 3) * 3 + (c / 3)] |= bit;
                }
            }
        }

        BacktrackFlat(flat, emptyCells, emptyCount, rowMasks, colMasks, boxMasks);

        for (var r = 0; r < 9; r++)
            for (var c = 0; c < 9; c++)
                board[r][c] = flat[r * 9 + c];
    }

    private static bool Backtrack(char[][] board, Span<int> emptyCells, int emptyCount, Span<int> rowMasks, Span<int> colMasks, Span<int> boxMasks)
    {
        if (emptyCount == 0)
            return true;

        var bestIdx = -1;
        var minOptionsCount = 10;
        var bestCellValidMask = 0;

        for (var i = 0; i < emptyCount; i++)
        {
            var cell = emptyCells[i];
            var r = cell / 9;
            var c = cell % 9;
            var b = (r / 3) * 3 + (c / 3);

            var usedMask = rowMasks[r] | colMasks[c] | boxMasks[b];

            var availableMask = ~usedMask & 0x3FE;
            var optionsCount = BitOperations.PopCount((uint)availableMask);

            if (optionsCount == 0)
                return false;

            if (optionsCount >= minOptionsCount)
                continue;

            minOptionsCount = optionsCount;
            bestIdx = i;
            bestCellValidMask = availableMask;

            if (optionsCount == 1)
                break;
        }

        var bestCell = emptyCells[bestIdx];
        var cellR = bestCell / 9;
        var cellC = bestCell % 9;
        var cellB = (cellR / 3) * 3 + (cellC / 3);

        emptyCells[bestIdx] = emptyCells[emptyCount - 1];
        emptyCells[emptyCount - 1] = bestCell;

        for (var num = 1; num <= 9; num++)
        {
            var bit = 1 << num;

            if ((bestCellValidMask & bit) is 0)
                continue;

            board[cellR][cellC] = (char)(num + '0');
            rowMasks[cellR] |= bit;
            colMasks[cellC] |= bit;
            boxMasks[cellB] |= bit;

            if (Backtrack(board, emptyCells, emptyCount - 1, rowMasks, colMasks, boxMasks))
            {
                return true;
            }

            board[cellR][cellC] = '.';
            rowMasks[cellR] &= ~bit;
            colMasks[cellC] &= ~bit;
            boxMasks[cellB] &= ~bit;
        }

        emptyCells[emptyCount - 1] = emptyCells[bestIdx];
        emptyCells[bestIdx] = bestCell;

        return false;
    }

    private static bool BacktrackFlat(Span<char> flat, Span<int> emptyCells, int emptyCount, Span<int> rowMasks, Span<int> colMasks, Span<int> boxMasks)
    {
        if (emptyCount == 0)
            return true;

        var bestIdx = -1;
        var minOptionsCount = 10;
        var bestCellValidMask = 0;

        for (var i = 0; i < emptyCount; i++)
        {
            var cell = emptyCells[i];
            var r = cell / 9;
            var c = cell % 9;
            var b = (r / 3) * 3 + (c / 3);

            var usedMask = rowMasks[r] | colMasks[c] | boxMasks[b];

            var availableMask = ~usedMask & 0x3FE;
            var optionsCount = BitOperations.PopCount((uint)availableMask);

            if (optionsCount == 0)
                return false;

            if (optionsCount >= minOptionsCount)
                continue;

            minOptionsCount = optionsCount;
            bestIdx = i;
            bestCellValidMask = availableMask;

            if (optionsCount == 1)
                break;
        }

        var bestCell = emptyCells[bestIdx];
        var cellR = bestCell / 9;
        var cellC = bestCell % 9;
        var cellB = (cellR / 3) * 3 + (cellC / 3);

        emptyCells[bestIdx] = emptyCells[emptyCount - 1];
        emptyCells[emptyCount - 1] = bestCell;

        for (var num = 1; num <= 9; num++)
        {
            var bit = 1 << num;

            if ((bestCellValidMask & bit) is 0)
                continue;

            flat[bestCell] = (char)(num + '0');
            rowMasks[cellR] |= bit;
            colMasks[cellC] |= bit;
            boxMasks[cellB] |= bit;

            if (BacktrackFlat(flat, emptyCells, emptyCount - 1, rowMasks, colMasks, boxMasks))
            {
                return true;
            }

            flat[bestCell] = '.';
            rowMasks[cellR] &= ~bit;
            colMasks[cellC] &= ~bit;
            boxMasks[cellB] &= ~bit;
        }

        emptyCells[emptyCount - 1] = emptyCells[bestIdx];
        emptyCells[bestIdx] = bestCell;

        return false;
    }
}
