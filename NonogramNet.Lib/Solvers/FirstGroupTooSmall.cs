// If you have a line with too little space for the first rule number, it can be converted from None to Blocked.
namespace NonogramNet.Lib.Solvers
{
    using NonogramNet.Lib;
    using NonogramNet.Lib.Model;
    using System.Collections.Generic;
    using System.Linq;

    public class FirstGroupTooSmall : ISolver
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
            bool lineIsCompleted;
            for (int x = 0; x < board.Width; x++)
            {
                lineIsCompleted = false;
                var ruleLine = board.TopRules[x];
                var firstRule = ruleLine?.FirstOrDefault();
                if(firstRule == null)
                {
                    continue;
                }
                var groups = SimpleGrouper.GroupVertical(board, x);
                if (groups == null)
                {
                    continue;
                }

                Group? firstEmptyGroup = default;
                int totalSpace = 0;
                foreach (Group group in groups.Groups)
                {
                    switch (group.State)
                    {
                        case CellState.None:
                            if (firstEmptyGroup == null)
                            {
                                firstEmptyGroup = group;
                            }
                            totalSpace += group.Count;
                            break;
                        case CellState.Filled:
                            totalSpace += group.Count;
                            break;
                        case CellState.Blocked:
                            if (totalSpace < firstRule.Value && firstEmptyGroup != null)
                            {
                                for (int i = 0; i < firstEmptyGroup.Value.Count; i++)
                                {
                                    changes.Add(BoardChange.Blocked(x, i + firstEmptyGroup.Value.StartIndex));
                                }
                                lineIsCompleted = true;
                            }
                            break;
                        default:
                            break;
                    }

                    // Jump out of the group loop
                    if (lineIsCompleted)
                    {
                        break;
                    }
                }
            }
        }
    }

}