namespace NonogramNet.Lib.Solvers
{
    using System.Collections.Generic;
    using System.Linq;
    using Model;

    // if the sum of all the rule numbers + count of rules + minus 1 = grid size
    public class OnlyOneWayToFill : ISolver
    {
        public IEnumerable<BoardChange> Solve(IBoard board)
        {
            var changes = new HashSet<BoardChange>();
            VerticalCheck(board, changes);
            var transposedChanges = new HashSet<BoardChange>();
            VerticalCheck(new TransposedBoard(board), transposedChanges);
            if (transposedChanges.Count > 0)
            {
                changes.UnionWith(transposedChanges.Transpose());
            }

            return changes;
        }

        private void VerticalCheck(IBoard board, HashSet<BoardChange> changes)
        {
            for (int x = 0; x < board.Width; x++)
            {
                var ruleLine = board.TopRules[x];
                var sum = ruleLine.Sum();
                var numberOfRules = ruleLine.Count;
                var sizeNeeded = sum + numberOfRules - 1;
                if (sizeNeeded == board.Height)
                {
                    int y = 0;
                    foreach (var rule in ruleLine)
                    {
                        for (int i = 0; i < rule; i++)
                        {
                            if (board[x, y] == CellState.None)
                            {
                                changes.Add(BoardChange.Filled(x,y));
                            }
                            y += 1;
                        }

                        if (y < board.Height)
                        {
                            if (board[x, y] == CellState.None)
                            {
                                changes.Add(BoardChange.Blocked(x,y));
                            }
                            y += 1;
                        }
                    }
                }
            }
        }
    }
}
