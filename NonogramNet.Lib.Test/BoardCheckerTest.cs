using System;
using System.Collections.Generic;
using System.Text;

namespace NonogramNet.Lib.Test
{
    using Model;
    using Xunit;

    public class BoardCheckerTest
    {
        [Fact]
        public void SolvedBoard2_OnlyFilled()
        {
            var board = BoardSamples.Board2;
            board = board.ApplyChanges(
                new BoardChange(0,2,CellState.Filled),
                new BoardChange(1,0,CellState.Filled),
                new BoardChange(1,1,CellState.Filled),
                new BoardChange(2,0,CellState.Filled),
                new BoardChange(2,2,CellState.Filled)
                );

            Assert.True(BoardChecker.IsBoardCompleted(board));
        }

        [Fact]
        public void SolvedBoard2_AllCellsMarked()
        {
            var board = BoardSamples.Board2;
            board = board.ApplyChanges(
                new BoardChange(0, 0, CellState.Blocked),
                new BoardChange(0, 1, CellState.Blocked),
                new BoardChange(0, 2, CellState.Filled),
                new BoardChange(1, 0, CellState.Filled),
                new BoardChange(1, 1, CellState.Filled),
                new BoardChange(1, 2, CellState.Blocked),
                new BoardChange(2, 0, CellState.Filled),
                new BoardChange(2, 1, CellState.Blocked),
                new BoardChange(2, 2, CellState.Filled)
            );

            Assert.True(BoardChecker.IsBoardCompleted(board));
        }

        [Fact]
        public void SolvedBoard2_OnlyFilled_MissingOne1()
        {
            var board = BoardSamples.Board2;
            board = board.ApplyChanges(
                new BoardChange(0, 2, CellState.Filled),
                //new BoardChange(1, 0, CellState.Filled),
                new BoardChange(1, 1, CellState.Filled),
                new BoardChange(2, 0, CellState.Filled),
                new BoardChange(2, 2, CellState.Filled)
            );

            Assert.False(BoardChecker.IsBoardCompleted(board));
        }

        [Fact]
        public void SolvedBoard2_OnlyFilled_MissingOne2()
        {
            var board = BoardSamples.Board2;
            board = board.ApplyChanges(
                new BoardChange(0, 2, CellState.Filled),
                new BoardChange(1, 0, CellState.Filled),
                new BoardChange(1, 1, CellState.Filled),
                //new BoardChange(2, 0, CellState.Filled),
                new BoardChange(2, 2, CellState.Filled)
            );

            Assert.False(BoardChecker.IsBoardCompleted(board));
        }
    }
}
