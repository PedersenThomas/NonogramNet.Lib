using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NonogramNet.Lib.Model;

namespace NonogramNet.Lib.Solvers
{
    public class CrossOutCompletedLine: ISolver
    {
        public IEnumerable<BoardChange> Solve(IBoard board)
        {
            var changes = new HashSet<BoardChange>();

            VerticalRulesCheck(board, changes);
            HorizontalRulesCheck(board, changes);

            return changes;
        }

        private static void VerticalRulesCheck(IBoard board, HashSet<BoardChange> changes)
        {
            for (int x = 0; x < board.Width; x++)
            {
                var groups = SimpleGrouper.GroupVertical(board, x);
                var ruleLine = board.TopRules.GetRuleLineAt(x);
                if (groups.ContainsNones && groups.SatisfiesRuleLine(ruleLine))
                {
                    for (int y = 0; y < board.Height; y++)
                    {
                        var state = board[x, y];
                        if (state == CellState.None)
                        {
                            changes.Add(BoardChange.Blocked(x,y));
                        }
                    }
                }
            }
        }

        private static void HorizontalRulesCheck(IBoard board, HashSet<BoardChange> changes)
        {
            for (int y = 0; y < board.Height; y++)
            {
                var groups = SimpleGrouper.GroupHorizontal(board, y);
                var ruleLine = board.LeftRules.GetRuleLineAt(y);
                if (groups.ContainsNones && groups.SatisfiesRuleLine(ruleLine))
                {
                    for (int x = 0; x < board.Width; x++)
                    {
                        var state = board[x, y];
                        if (state == CellState.None)
                        {
                            changes.Add(BoardChange.Blocked(x,y));
                        }
                    }
                }
            }
        }
    }
}
