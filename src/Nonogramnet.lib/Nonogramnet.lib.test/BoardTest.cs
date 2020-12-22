using System;
using Xunit;

namespace Nonogramnet.lib.test
{
    public class BoardTest
    {
        [Fact]
        public void EmptyBoard()
        {
            int width = 3;
            int height = 5;
            var board = new NonogramBoard(width, height, BoardConstraints.Empty, new Manifest(string.Empty, string.Empty));
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Assert.Equal(CellState.Free, board[x, y]);
                }
            }
        }
    }
}
