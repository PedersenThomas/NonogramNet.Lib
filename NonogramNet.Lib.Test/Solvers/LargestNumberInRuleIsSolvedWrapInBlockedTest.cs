using System;
using System.Collections.Generic;
using System.Text;
using NonogramNet.Lib.Model;
using NonogramNet.Lib.Solvers;
using Xunit;

namespace NonogramNet.Lib.Test.Solvers
{
    using Xunit.Abstractions;

    public class LargestNumberInRuleIsSolvedWrapInBlockedTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public LargestNumberInRuleIsSolvedWrapInBlockedTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void EmptyBoard_NoChanges()
        {
            var board = BoardSamples.Board2;
            var solver = new LargestNumberInRuleIsSolvedWrapInBlocked();

            var actualChanges = solver.Solve(board);
            Assert.Empty(actualChanges);
        }

        [Fact]
        public void HighestUpAgainEndOfRow()
        {
            var board = BoardSamples.Board2
                .ApplyChanges(
                    new BoardChange(1, 0, CellState.Filled),
                    new BoardChange(2, 0, CellState.Filled)
                );
            var solver = new LargestNumberInRuleIsSolvedWrapInBlocked();

            var actualChanges = solver.Solve(board);

            var expected = new List<BoardChange>
            {
                new BoardChange(2,1,CellState.Blocked),
                new BoardChange(0,0,CellState.Blocked)
            };
            Assert.Equal(expected, actualChanges);
        }

        [Fact]
        public void EntireRowsAndColumnsFilled()
        {
            var board = BoardSamples.Board3
                .ApplyChanges(
                    new BoardChange(0, 0, CellState.Filled),
                    new BoardChange(1, 0, CellState.Filled),
                    new BoardChange(2, 0, CellState.Filled),
                    new BoardChange(2, 1, CellState.Filled),
                    new BoardChange(2, 2, CellState.Filled)
                );
            _testOutputHelper.WriteLine(BoardASCIIArt.BoardOnlyAsciiArt(board));
            var solver = new LargestNumberInRuleIsSolvedWrapInBlocked();

            var actualChanges = solver.Solve(board);

            var expected = new List<BoardChange>
            {
                new BoardChange(0, 1, CellState.Blocked),
                new BoardChange(1, 2, CellState.Blocked)
            };
            Assert.Equal(expected, actualChanges);
        }

        [Fact]
        public void BoardWithEmptyLine()
        {
            var board = BoardSamples.Board4;
            var solver = new LargestNumberInRuleIsSolvedWrapInBlocked();

            var actualChanges = solver.Solve(board);
            Assert.Empty(actualChanges);
        }
    }
}
