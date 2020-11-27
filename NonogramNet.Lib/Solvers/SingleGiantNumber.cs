// If a line contains a number that satisfies n*2 > LineSize. Ie. the number must meet in the middle of the line.

using System;
using System.Collections.Generic;
using System.Text;
using NonogramNet.Lib.Model;

namespace NonogramNet.Lib.Solvers
{
    public class SingleGiantNumber : ISolver
    {
        public IEnumerable<BoardChange> Solve(IBoard board)
        {
            var changes = new HashSet<BoardChange>();
            Vertical(board, changes);
            Vertical(new TransposedBoard(board), changes);

            return changes;
        }

        private void Vertical(IBoard board, HashSet<BoardChange> changes)
        {
            for (int x = 0; x < board.Width; x++)
            {
                var ruleLine = board.TopRules.GetRuleLineAt(x);

                if (ruleLine.Count != 1)
                {
                    continue;
                }

                var f = (ruleLine[0] * 2) - board.Height;
                if (f > 0)
                {
                    var e = ruleLine[0] - f;
                    for (int filledCells = e; filledCells < e + f; filledCells++)
                    {
                        if (board[x, filledCells] == CellState.None)
                        {
                            changes.Add(new BoardChange(x, filledCells, CellState.Filled));
                        }
                    }
                }
            }
        }
    }
}