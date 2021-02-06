// If you have a line with too little space for the first rule number, it can be converted from None to Blocked.
namespace NonogramNet.Lib.Solvers
{
    using NonogramNet.Lib;
    using NonogramNet.Lib.Model;
    using System.Collections.Generic;
    using System.Linq;

    public class FirstGroupTooSmall : ISolver
    {
        // TODO: Implement FlippedBoard or make it work from the other end as well
        public IEnumerable<BoardChange> Solve(IBoard board)
        {
            HashSet<BoardChange>? changes = new HashSet<BoardChange>();
            this.VerticalCheck(board, changes);
            HashSet<BoardChange>? transposedChanges = new HashSet<BoardChange>();
            TransposedBoard? transposedBoard = new TransposedBoard(board);
            this.VerticalCheck(transposedBoard, transposedChanges);
            if (transposedChanges.Count > 0)
            {
                changes.Add(transposedChanges.Transpose());
            }

            HashSet<BoardChange>? flippedChanges = new HashSet<BoardChange>();
            FlippedBoard? flippedBoard = new FlippedBoard(board);
            this.VerticalCheck(flippedBoard, flippedChanges);
            if(flippedChanges.Count > 0)
            {
                changes.Add(flippedChanges.Flip(board.Width, board.Height));
            }

            HashSet<BoardChange>? flippedTransposedChanges = new HashSet<BoardChange>();
            FlippedBoard? flippedTransposedBoard = new FlippedBoard(transposedBoard);
            this.VerticalCheck(flippedTransposedBoard, flippedTransposedChanges);
            if (flippedTransposedChanges.Count > 0)
            {
                changes.Add(flippedTransposedChanges.Flip(board.Width, board.Height).Transpose());
            }

            return changes;
        }

        private void VerticalCheck(IBoard board, HashSet<BoardChange> changes)
        {
            bool lineIsCompleted;
            for (int x = 0; x < board.Width; x++)
            {
                lineIsCompleted = false;
                IRuleLine? ruleLine = board.TopRules[x];
                int? firstRule = ruleLine?.FirstOrDefault();
                if(firstRule == null)
                {
                    continue;
                }
                GroupCollection? groups = SimpleGrouper.GroupVertical(board, x);
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