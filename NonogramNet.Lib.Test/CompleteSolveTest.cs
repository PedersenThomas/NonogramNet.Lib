using System;
using System.Collections.Generic;
using System.Text;

namespace NonogramNet.Lib.Test
{
    using System.Linq;
    using Lib.Solvers;
    using Model;
    using Xunit;

    public class CompleteSolveTest
    {
        [Theory]
        [MemberData(nameof(AllBoards))]
        public void SolveBoard(IBoard board) => SolveAndVerifyBoard(board);

        public static IEnumerable<object[]> AllBoards() =>
            new List<object[]>
            {
                new object[]{BoardSamples.Board1},
                new object[]{BoardSamples.Board2},
                new object[]{BoardSamples.Board3},
                new object[]{BoardSamples.Board4},
                new object[]{BoardSamples.Board5},
                new object[]{BoardSamples.Board6},
            };

        private void SolveAndVerifyBoard(IBoard board)
        {
            var solver = SolverCombiner.AllSolvers.Value;

            IEnumerable<BoardChange> changes;
            do
            {
                changes = solver.Solve(board);
                board = board.ApplyChanges(changes);
            } while (changes.Any());

            Assert.True(BoardChecker.IsBoardCompleted(board));
        }
    }
}
