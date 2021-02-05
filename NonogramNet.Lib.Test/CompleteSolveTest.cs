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
        public void SolveBoard(string name, IBoard board) => SolveAndVerifyBoard(name, board);

        public static IEnumerable<object[]> AllBoards() =>
            new List<object[]>
            {
                new object[]{nameof(BoardSamples.Board1), BoardSamples.Board1},
                new object[]{nameof(BoardSamples.Board2), BoardSamples.Board2},
                new object[]{nameof(BoardSamples.Board3), BoardSamples.Board3},
                new object[]{nameof(BoardSamples.Board4), BoardSamples.Board4},
                //new object[]{nameof(BoardSamples.Board5), BoardSamples.Board5},
                //new object[]{nameof(BoardSamples.Board6), BoardSamples.Board6},
                //new object[]{nameof(BoardSamples.Board7), BoardSamples.Board7},
            };

        private void SolveAndVerifyBoard(string name, IBoard board)
        {
            var solver = SolverCombiner.AllSolvers.Value;

            IEnumerable<BoardChange> changes;
            do
            {
                changes = solver.Solve(board);
                board = board.ApplyChanges(changes);
            } while (changes.Any());

            Assert.True(BoardChecker.IsBoardCompleted(board), $"Board: {name}\n{BoardASCIIArt.BoardOnlyAsciiArt(board)}");
        }
    }
}
