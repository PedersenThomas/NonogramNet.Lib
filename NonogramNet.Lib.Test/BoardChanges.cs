using System;
using System.Collections.Generic;
using System.Text;
using NonogramNet.Lib.Model;
using Xunit;

namespace NonogramNet.Lib.Test
{
    public class BoardChanges
    {
        [Fact]
        public void DefaultChange()
        {
            var startBoard = BoardSamples.Board1;
            var updatedBoard = startBoard.ApplyChange(default);

            Assert.Same(startBoard, updatedBoard);
        }

        [Fact]
        public void ChangeToBlocked()
        {
            var startBoard = BoardSamples.Board1;
            var boardChange = new BoardChange(0, 0, CellState.Blocked);
            var updatedBoard = startBoard.ApplyChange(boardChange);

            Assert.NotSame(startBoard, updatedBoard);
            Assert.Equal(boardChange.NewValue, updatedBoard[boardChange.X, boardChange.Y]);
        }

        [Fact]
        public void EmptyListOfChanges()
        {
            var startBoard = BoardSamples.Board1;
            var updatedBoard = startBoard.ApplyChanges(new List<BoardChange>());

            Assert.Same(startBoard, updatedBoard);
        }

        [Fact]
        public void ListOfDefaultChanges()
        {
            var startBoard = BoardSamples.Board1;
            var updatedBoard = startBoard.ApplyChanges(new List<BoardChange>() {default, default});

            Assert.Same(startBoard, updatedBoard);
        }

        [Fact]
        public void ListOfMixChanges()
        {
            var startBoard = BoardSamples.Board1;
            var updatedBoard = startBoard.ApplyChanges(new List<BoardChange>() { default, new BoardChange(0, 1, CellState.Blocked), default, new BoardChange(1, 1, CellState.Filled), default });

            Assert.NotSame(startBoard, updatedBoard);
            Assert.Equal(CellState.Blocked, updatedBoard[0,1]);
            Assert.Equal(CellState.Filled, updatedBoard[1,1]);
        }
    }
}
