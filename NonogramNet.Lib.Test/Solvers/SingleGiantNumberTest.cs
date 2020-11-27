namespace NonogramNet.Lib.Test.Solvers
{
    using System.Collections.Generic;
    using Lib.Solvers;
    using Model;
    using Xunit;

    public class SingleGiantNumberTest
    {
        [Fact]
        public void SingleCellOverlap_Vertical()
        {
            var board = BoardSamples.Board4;
            var solver = new SingleGiantNumber();

            var actualChanges = solver.Solve(board);

            var expected = new List<BoardChange>
            {
                new BoardChange(2,1,CellState.Filled)
            };
            Assert.Equal(expected, actualChanges);
        }

        [Fact]
        public void SingleCellOverlap_Horizontal()
        {
            var board = BoardSamples.Board5;
            var solver = new SingleGiantNumber();

            var actualChanges = solver.Solve(board);

            var expected = new List<BoardChange>
            {
                new BoardChange(1,1,CellState.Filled)
            };
            Assert.Equal(expected, actualChanges);
        }
    }
}