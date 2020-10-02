using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NonogramNet.Lib.Model;

namespace NonogramNet.Lib.Solvers
{
    public class CrossOutCompletedLine: ISolver
    {
        public IEnumerable<BoardChange> Solve(Board board)
        {
            var changes = new HashSet<BoardChange>();

            VerticalRulesCheck(board, changes);
            HorizontalRulesCheck(board, changes);

            return changes;
        }

        private static void VerticalRulesCheck(Board board, HashSet<BoardChange> changes)
        {
            var lastCellState = CellState.None;
            var count = 0;
            for (int x = 0; x < board.Width; x++)
            {
                var groups = Grouper.GroupVertical(board, x);
                var containsNones = groups.Any(p => p.state == CellState.None);
                var filledIn = groups.Where(p => p.state == CellState.Filled).ToList();

                var ruleLine = board.TopRules.GetRuleLineAt(x);
                bool match = false;
                if (containsNones && filledIn.Count == ruleLine.Count)
                {
                    match = true;
                    for (int i = 0; i < filledIn.Count; i++)
                    {
                        if (filledIn[i].count != ruleLine[i])
                        {
                            match = false;
                            break;
                        }
                    }
                }

                if (match)
                {
                    for (int y = 0; y < board.Height; y++)
                    {
                        var state = board[x, y];
                        if (state == CellState.None)
                        {
                            changes.Add(new BoardChange(x, y, CellState.Blocked));
                        }
                    }
                }
            }
        }

        private static void HorizontalRulesCheck(Board board, HashSet<BoardChange> changes)
        {
            var lastCellState = CellState.None;
            var count = 0;
            for (int y = 0; y < board.Height; y++)
            {
                var groups = Grouper.GroupHorizontal(board, y);
                var containsNones = groups.Any(p => p.state == CellState.None);
                var filledIn = groups.Where(p => p.state == CellState.Filled).ToList();

                var ruleLine = board.LeftRules.GetRuleLineAt(y);
                bool match = false;
                if (containsNones && filledIn.Count == ruleLine.Count)
                {
                    match = true;
                    for (int i = 0; i < filledIn.Count; i++)
                    {
                        if (filledIn[i].count != ruleLine[i])
                        {
                            match = false;
                            break;
                        }
                    }
                }

                if (match)
                {
                    for (int x = 0; x < board.Width; x++)
                    {
                        var state = board[x, y];
                        if (state == CellState.None)
                        {
                            changes.Add(new BoardChange(x, y, CellState.Blocked));
                        }
                    }
                }
            }
        }
    }
}
