// If a line contains a number that satisfies n*2 > LineSize. Ie. the number must meet in the middle of the line.

namespace NonogramNet.Lib.Solvers
{
    using System.Collections.Generic;
    using NonogramNet.Lib.Model;

    public class SingleGiantNumber : ISolver
    {
        public IEnumerable<BoardChange> Solve(IBoard board)
        {
            HashSet<BoardChange>? changes = new HashSet<BoardChange>();
            this.Vertical(board, changes);
            HashSet<BoardChange>? transposedChanges = new HashSet<BoardChange>();
            this.Vertical(new TransposedBoard(board), transposedChanges);
            if (transposedChanges.Count > 0)
            {
                changes.Add(transposedChanges.Transpose());
            }

            return changes;
        }

        private void Vertical(IBoard board, HashSet<BoardChange> changes)
        {
            for (int x = 0; x < board.Width; x++)
            {
                IRuleLine? ruleLine = board.TopRules[x];

                if (ruleLine.Count != 1)
                {
                    continue;
                }

                int f = (ruleLine[0] * 2) - board.Height;
                if (f > 0)
                {
                    int e = ruleLine[0] - f;
                    for (int filledCells = e; filledCells < e + f; filledCells++)
                    {
                        if (board[x, filledCells] == CellState.None)
                        {
                            changes.Add(BoardChange.Filled(x,filledCells));
                        }
                    }
                }
            }
        }
    }
}