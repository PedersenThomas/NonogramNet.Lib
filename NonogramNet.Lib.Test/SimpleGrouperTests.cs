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
            var expected = new List<Group>
            {
                new Group(CellState.None, 0, 5)
            };
            Assert.Equal(expected, horizontalGroup.Groups);
        }

        [Fact]
        public void EmptyBoardVertical()
        {
            var board = BoardSamples.Board1;
            var horizontalGroup = SimpleGrouper.GroupVertical(board, 0);
            var expected = new List<Group>
            {
                new Group(CellState.None, 0, 5)
            };
            Assert.Equal(expected, horizontalGroup.Groups);
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
            var expected = new List<Group>
            {
                new Group(CellState.Filled, 0, 2),
                new Group(CellState.None, 2, 1),
                new Group(CellState.Filled, 3, 1),
                new Group(CellState.None, 4, 1),
            };
            Assert.Equal(expected, verticalGroup.Groups);
        }

        [Fact]
        public void MixedAllVertical()
        {
            var board = BoardSamples.Board1
                .ApplyChanges(
                    new BoardChange(0, 0, CellState.Filled),
                    new BoardChange(0, 1, CellState.Filled),
                    new BoardChange(0, 3, CellState.Filled),
                    new BoardChange(0,4, CellState.Blocked)
                );
            var verticalGroup = SimpleGrouper.GroupVertical(board, 0);
            var expected = new List<Group>
            {
                new Group(CellState.Filled, 0, 2),
                new Group(CellState.None, 2, 1),
                new Group(CellState.Filled, 3, 1),
                new Group(CellState.Blocked, 4, 1)
            };
            Assert.Equal(expected, verticalGroup.Groups);

            var horizontalGroup = SimpleGrouper.GroupHorizontal(board, 4);
            var expectedHorizontal = new List<Group>
            {
                new Group(CellState.Blocked, 0, 1),
                new Group(CellState.None, 1, 4)
            };
            Assert.Equal(expectedHorizontal, horizontalGroup.Groups);
        }
    }
}
