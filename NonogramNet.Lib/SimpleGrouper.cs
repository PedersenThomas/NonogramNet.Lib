using System;
using System.Collections.Generic;
using System.Text;
using NonogramNet.Lib.Model;

namespace NonogramNet.Lib
{
    public static class SimpleGrouper
    {
        public static GroupCollection GroupVertical(IBoard board, int lineIndex)
        {
            var result = new List<Group>();
            int count = 0;
            int startIndex = 0;
            CellState lastState = board[lineIndex, 0];
            for (int i = 0; i < board.Height; i++)
            {
                var current = board[lineIndex, i];
                if (current != lastState)
                {
                    result.Add(new Group(lastState, startIndex, count));
                    lastState = current;
                    count = 1;
                    startIndex = i;
                }
                else
                {
                    count += 1;
                }
            }
            result.Add(new Group(lastState, startIndex, count));

            return new GroupCollection(result);
        }

        public static GroupCollection GroupHorizontal(IBoard board, int lineIndex)
        {
            var result = new List<Group>();
            int count = 0;
            int startIndex = 0;
            CellState lastState = board[0, lineIndex];
            for (int i = 0; i < board.Width; i++)
            {
                var current = board[i, lineIndex];
                if (current != lastState)
                {
                    result.Add(new Group(lastState, startIndex, count));
                    lastState = current;
                    count = 1;
                    startIndex = i;
                }
                else
                {
                    count += 1;
                }
            }
            result.Add(new Group(lastState, startIndex, count));

            return new GroupCollection(result);
        }
    }
}
