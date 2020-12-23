// If you find a group with the same length of the largest number in a ruleLine, it is safe to wrap it in blocked cells
namespace NonogramNet.Lib.Solvers
{
    using System.Collections.Generic;
    using System.Linq;
    using Model;

    // if the sum of all the rule numbers + count of rules + minus 1 = grid size
    public class LargestNumberInRuleIsSolvedWrapInBlocked : ISolver
    {
        public IEnumerable<BoardChange> Solve(IBoard board)
        {
            var changes = new HashSet<BoardChange>();
            VerticalCheck(board, changes);
            var transposedChanges = new HashSet<BoardChange>();
            VerticalCheck(new TransposedBoard(board), transposedChanges);
            if (transposedChanges.Count > 0)
            {
                changes.Add(transposedChanges.Transpose());
            }

            return changes;
        }

        private void VerticalCheck(IBoard board, HashSet<BoardChange> changes)
        {
            for (int x = 0; x < board.Width; x++)
            {
                var groups = SimpleGrouper.GroupVertical(board, x);
                var ruleLine = board.TopRules[x];
                if (ruleLine.Count == 0)
                {
                    continue;
                }
                var highestRuleNumber = ruleLine.Max();
                if (!groups.ContainsNones || highestRuleNumber == 0)
                {
                    continue;
                }
                foreach (var group in groups.Groups)
                {
                    if (group.State == CellState.Filled && group.Count == highestRuleNumber)
                    {
                        // Block off before the start of the group.
                        if (group.StartIndex > 0 && board[x, group.StartIndex-1] == CellState.None)
                        {
                            changes.Add(BoardChange.Blocked(x, group.StartIndex-1));
                        }

                        var lastIndex = group.StartIndex + group.Count;
                        if (lastIndex < board.Height && board[x, lastIndex] == CellState.None)
                        {
                            changes.Add(BoardChange.Blocked(x, lastIndex));
                        }
                    }
                }
            }
        }
    }
}
