using System;
using System.Collections.Generic;
using System.Text;
using NonogramNet.Lib.Model;
using NonogramNet.Lib.Solvers;
using Xunit;

namespace NonogramNet.Lib.Test.Solvers
{
    public class FillEntireLineTest
    {
        [Fact]
        public void EmptyBoardWithNoneEmptyRuleLines()
        {
            var board = BoardSamples.Board2;
            var solver = new FillEntireLine();

            var actualChanges = solver.Solve(board);
            Assert.Empty(actualChanges);
        }

        [Fact]
        public void BoardWithVerticalAndHorizontalFullLine()
        {
            var board = BoardSamples.Board3;
            var solver = new FillEntireLine();

            var actualChanges = solver.Solve(board);

            var expected = new List<BoardChange>
            {
                new BoardChange(0,0,CellState.Filled),
                new BoardChange(1,0,CellState.Filled),
                new BoardChange(2,0,CellState.Filled),
                new BoardChange(2,1,CellState.Filled),
                new BoardChange(2,2,CellState.Filled)
            };
            Assert.Equal(expected, actualChanges);
        }
    }
}
