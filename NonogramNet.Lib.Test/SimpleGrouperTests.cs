using System;
using System.Collections.Generic;
using System.Text;
using NonogramNet.Lib.Model;
using Xunit;

namespace NonogramNet.Lib.Test
{
    public class SimpleGrouperTests
    {
        [Fact]
        public void EmptyBoardHorizontal()
        {
            var board = BoardSamples.Board1;
            var horizontalGroup = SimpleGrouper.GroupHorizontal(board, 0);
            var expected = new List<(CellState state, int count)>
            {
                (CellState.None, 5)
            };
            Assert.Equal(expected, horizontalGroup);
        }

        [Fact]
        public void EmptyBoardVertical()
        {
            var board = BoardSamples.Board1;
            var horizontalGroup = SimpleGrouper.GroupVertical(board, 0);
            var expected = new List<(CellState state, int count)>
            {
                (CellState.None, 5)
            };
            Assert.Equal(expected, horizontalGroup);
        }

        [Fact]
        public void MixedFilledAndEmptyVertical()
        {
            var board = BoardSamples.Board1
                .ApplyChanges(
                    new BoardChange(0, 0, CellState.Filled),
                    new BoardChange(0, 1, CellState.Filled),
                    new BoardChange(0, 3, CellState.Filled)
                );
            var verticalGroup = SimpleGrouper.GroupVertical(board, 0);
            var expected = new List<(CellState state, int count)>
            {
                (CellState.Filled, 2),
                (CellState.None, 1),
                (CellState.Filled, 1),
                (CellState.None, 1),
            };
            Assert.Equal(expected, verticalGroup);
        }
    }
}
