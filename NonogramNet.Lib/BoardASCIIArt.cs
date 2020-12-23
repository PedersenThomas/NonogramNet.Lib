using System;
using System.Collections.Generic;
using System.Text;

namespace NonogramNet.Lib
{
    using Model;

    public static class BoardASCIIArt
    { 
        public static string BoardOnlyAsciiArt(IBoard board)
        {
            var buffer = new StringBuilder();

            for (var y = 0; y < board.Height; y++)
            {
                for (var x = 0; x < board.Width; x++)
                {
                    var state = board[x, y];
                    var ascii = StateAsAsciiArt(state);
                    buffer.Append(ascii);
                }

                buffer.AppendLine();
            }

            return buffer.ToString();
        }

        private static string StateAsAsciiArt(CellState state)
        {
            switch (state)
            {
                case CellState.None:
                    return "_";
                case CellState.Filled:
                    return "o";
                case CellState.Blocked:
                    return "x";
            }

            return state.ToString();
        }
    }
}
