using System.Collections.Generic;
using NonogramNet.Lib.Model;
using NonogramNet.Lib.Solvers;
using Xunit;

namespace NonogramNet.Lib.Test.Solvers
{
    public class CrossOutCompletedLineTest
    {
        [Fact]
        public void NoCompletedLines()
        {
            var board = BoardSamples.Board2;
            var solver = new CrossOutCompletedLine();

            var actualChanges = solver.Solve(board);
            Assert.Empty(actualChanges);
        }

        [Fact]
        public void OneVerticalLineFixed()
        {
            var board = BoardSamples.Board2
                .ApplyChange(new BoardChange(0, 2, CellState.Filled));
            var solver = new CrossOutCompletedLine();

            var actualChanges = solver.Solve(board);

            var expected = new List<BoardChange>
            {
                new BoardChange(0,0,CellState.Blocked),
                new BoardChange(0,1,CellState.Blocked)
            };
            Assert.Equal(expected, actualChanges);
        }

        [Fact]
        public void OneHorizontalLineFixed()
        {
            var board = BoardSamples.Board2
                .ApplyChange(new BoardChange(1, 1, CellState.Filled));
            var solver = new CrossOutCompletedLine();

            var actualChanges = solver.Solve(board);

            var expected = new List<BoardChange>
            {
                new BoardChange(0,1,CellState.Blocked),
                new BoardChange(2,1,CellState.Blocked)
            };
            Assert.Equal(expected, actualChanges);
        }

        [Fact]
        public void TwoCrossingLine_NoDuplicates()
        {
            var board = BoardSamples.Board2
                .ApplyChanges(
                    new BoardChange(0, 2, CellState.Filled),
                    new BoardChange(1, 1, CellState.Filled));
            var solver = new CrossOutCompletedLine();

            var actualChanges = solver.Solve(board);

            var expected = new List<BoardChange>
            {
                new BoardChange(0,0,CellState.Blocked),
                new BoardChange(0,1,CellState.Blocked),
                new BoardChange(2,1,CellState.Blocked)
            };
            Assert.Equal(expected, actualChanges);
        }
    }
}
