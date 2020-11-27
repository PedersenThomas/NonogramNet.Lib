using System;
using System.Collections.Generic;
using System.Text;

namespace NonogramNet.Lib.Test.Solvers
{
    using Lib.Solvers;
    using Model;
    using Xunit;

    public class OnlyOneWayToFillTest
    {
        [Fact]
        public void HorizontalChanges()
        {
            var board = BoardSamples.Board1;
            var solver = new OnlyOneWayToFill();

            var actualChanges = solver.Solve(board);

            var expected = new List<BoardChange>
            {
                new BoardChange(0,0,CellState.Filled),
                new BoardChange(1,0,CellState.Filled),
                new BoardChange(2,0,CellState.Filled),
                new BoardChange(3,0,CellState.Blocked),
                new BoardChange(4,0,CellState.Filled),
                new BoardChange(0,1,CellState.Filled),
                new BoardChange(1,1,CellState.Filled),
                new BoardChange(2,1,CellState.Blocked),
                new BoardChange(3,1,CellState.Filled),
                new BoardChange(4,1,CellState.Filled),
                new BoardChange(0,2,CellState.Filled),
                new BoardChange(1,2,CellState.Blocked),
                new BoardChange(2,2,CellState.Filled),
                new BoardChange(3,2,CellState.Blocked),
                new BoardChange(4,2,CellState.Filled),
            };
            TestUtilities.VerifyChanges(expected, actualChanges);
        }

        [Fact]
        public void VerticalChanges()
        {
            var board = new TransposedBoard(BoardSamples.Board1);
            var solver = new OnlyOneWayToFill();

            var actualChanges = solver.Solve(board);

            var expected = new HashSet<BoardChange>
            {
                new BoardChange(0,0,CellState.Filled),
                new BoardChange(1,0,CellState.Filled),
                new BoardChange(2,0,CellState.Filled),
                new BoardChange(3,0,CellState.Blocked),
                new BoardChange(4,0,CellState.Filled),
                new BoardChange(0,1,CellState.Filled),
                new BoardChange(1,1,CellState.Filled),
                new BoardChange(2,1,CellState.Blocked),
                new BoardChange(3,1,CellState.Filled),
                new BoardChange(4,1,CellState.Filled),
                new BoardChange(0,2,CellState.Filled),
                new BoardChange(1,2,CellState.Blocked),
                new BoardChange(2,2,CellState.Filled),
                new BoardChange(3,2,CellState.Blocked),
                new BoardChange(4,2,CellState.Filled),
            };
            TestUtilities.VerifyChanges(expected.Transpose(), actualChanges);
        }
    }
}
