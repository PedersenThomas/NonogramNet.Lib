using System;
using System.Collections.Generic;
using System.Text;
using NonogramNet.Lib.Model;

namespace NonogramNet.Lib.Solvers
{
    public class FillEntireLine : ISolver
    {
        public IEnumerable<BoardChange> Solve(IBoard board)
        {
            var changes = new HashSet<BoardChange>();

            for (int y = 0; y < board.Height; y++)
            {
                var ruleLine = board.LeftRules.GetRuleLineAt(y);
                if (ruleLine.Count == 1 && board.Width == ruleLine[0])
                {
                    for (int x = 0; x < board.Width; x++)
                    {
                        if (board[x, y] == CellState.None)
                        {
                            changes.Add(new BoardChange(x, y, CellState.Filled));
                        }
                    }
                }
            }

            for (int x = 0; x < board.Width; x++)
            {
                var ruleLine = board.TopRules.GetRuleLineAt(x);
                if (ruleLine.Count == 1 && board.Height == ruleLine[0])
                {
                    for (int y = 0; y < board.Height; y++)
                    {
                        if (board[x, y] == CellState.None)
                        {
                            changes.Add(new BoardChange(x, y, CellState.Filled));
                        }
                    }
                }
            }

            return changes;
        }
    }
}
