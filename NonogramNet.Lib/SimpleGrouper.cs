using System;
using System.Collections.Generic;
using System.Text;
using NonogramNet.Lib.Model;

namespace NonogramNet.Lib
{
    public static class SimpleGrouper
    {
        public static Group GroupVertical(IBoard board, int lineIndex)
        {
            var result = new List<(CellState state, int count)>();
            int count = 0;
            CellState lastState = board[lineIndex, 0];
            for (int i = 0; i < board.Height; i++)
            {
                var current = board[lineIndex, i];
                if (current != lastState)
                {
                    result.Add((lastState, count));
                    lastState = current;
                    count = 1;
                }
                else
                {
                    count += 1;
                }
            }
            result.Add((lastState, count));

            return new Group(result);
        }

        public static Group GroupHorizontal(IBoard board, int lineIndex)
        {
            var result = new List<(CellState state, int count)>();
            int count = 0;
            CellState lastState = board[0, lineIndex];
            for (int i = 0; i < board.Width; i++)
            {
                var current = board[i, lineIndex];
                if (current != lastState)
                {
                    result.Add((lastState, count));
                    lastState = current;
                    count = 1;
                }
                else
                {
                    count += 1;
                }
            }
            result.Add((lastState, count));

            return new Group(result);
        }
    }
}
