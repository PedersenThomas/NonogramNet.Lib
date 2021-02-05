using NonogramNet.Lib.Model;
using NonogramNet.Lib.Solvers;
using System.Collections.Generic;
using Xunit;

namespace NonogramNet.Lib.Test.Solvers
{
    public class FirstGroupTooSmallTest
    {
        [Fact]
        public void EmptyBoard_NoChange()
        {
            var board = BoardSamples.Board2;
            var solver = new FirstGroupTooSmall();

            var actualChanges = solver.Solve(board);
            Assert.Empty(actualChanges);
        }

        [Fact]
        public void BoardWithTwoToFillVertical_MarkOneAsBlocked()
        {
            var board = BoardSamples.Board7
                .ApplyChanges(
                    BoardChange.Blocked(0, 1)
                );
            var solver = new FirstGroupTooSmall();

            var actualChanges = solver.Solve(board);
            var expected = new List<BoardChange>
            {
                BoardChange.Blocked(0,0)
            };
            Assert.Equal(expected, actualChanges);
        }

        [Fact]
        public void BoardWithTwoToFillHorizontal_MarkOneAsBlocked()
        {
            var board = BoardSamples.Board7
                .ApplyChanges(
                    BoardChange.Blocked(1, 0)
                );
            var solver = new FirstGroupTooSmall();

            var actualChanges = solver.Solve(board);
            var expected = new List<BoardChange>
            {
                BoardChange.Blocked(0,0)
            };
            Assert.Equal(expected, actualChanges);
        }
    }
}
