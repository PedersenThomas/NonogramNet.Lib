using System;
using System.Collections.Generic;
using System.Text;

namespace NonogramNet.Lib
{
    using Model;

    public static class BoardChecker
    {
        public static bool IsBoardCompleted(IBoard board)
        {
            for (int x = 0; x < board.Width; x++)
            {
                var ruleLine = board.TopRules[x];
                var groups = SimpleGrouper.GroupVertical(board, x);
                if (!groups.SatisfiesRuleLine(ruleLine))
                {
                    return false;
                }
            }

            for (int y = 0; y < board.Height; y++)
            {
                var ruleLine = board.LeftRules[y];
                var groups = SimpleGrouper.GroupHorizontal(board, y);
                if (!groups.SatisfiesRuleLine(ruleLine))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
