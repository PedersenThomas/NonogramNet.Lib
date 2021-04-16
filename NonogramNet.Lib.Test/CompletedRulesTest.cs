using NonogramNet.Lib.Model;
using System.Collections.Generic;
using Xunit;

namespace NonogramNet.Lib.Test
{
    public class CompletedRulesTest
    {
        private static readonly List<CompletedRuleMarker> EmptyMarkerList = new List<CompletedRuleMarker>();

        [Fact]
        public void OneRuleOnTheLineTest()
        {
            var board = BoardSamples.Board2
                .ApplyChanges(
                    BoardChange.Filled(1, 0),
                    BoardChange.Filled(2, 0)
                );
            var calculator = new CompletedRulesCalculator();
            var actualCompletedRules = calculator.CalculateForBoard(board);
            var expected = new CompletedBoardRules(
                new List<List<CompletedRuleMarker>> {
                    EmptyMarkerList,
                    EmptyMarkerList,
                    new List<CompletedRuleMarker>{ new CompletedRuleMarker(0, 0) }
                },
                new List<List<CompletedRuleMarker>> {
                    new List<CompletedRuleMarker>{ new CompletedRuleMarker(0, 1) },
                    EmptyMarkerList,
                    EmptyMarkerList
                });
            Assert.Equal(expected, actualCompletedRules);
        }

        [Fact]
        public void LineIsCompleteButWithEmptySpace()
        {
            var board = BoardSamples.Board1
                .ApplyChanges(
                    BoardChange.Filled(0, 2),
                    BoardChange.Filled(2, 2),
                    BoardChange.Filled(4, 2)
                );
            var calculator = new CompletedRulesCalculator();
            var actualCompletedRules = calculator.CalculateForBoard(board);
            var expected = new CompletedBoardRules(
                new List<List<CompletedRuleMarker>> {
                    EmptyMarkerList,
                    EmptyMarkerList,
                    EmptyMarkerList,
                    EmptyMarkerList,
                    EmptyMarkerList
                },
                new List<List<CompletedRuleMarker>> {
                    EmptyMarkerList,
                    EmptyMarkerList,
                    new List<CompletedRuleMarker>{ new CompletedRuleMarker(0,0), new CompletedRuleMarker(1,2), new CompletedRuleMarker(2,4) },
                    EmptyMarkerList,
                    EmptyMarkerList
                });
            Assert.Equal(expected, actualCompletedRules);
        }

        [Fact]
        public void StartingFromEitherSideBothGivesACompletedRule()
        {
            var board = BoardSamples.Board1
                .ApplyChanges(
                    BoardChange.Filled(0, 2),
                    BoardChange.Filled(4, 2)
                );
            var calculator = new CompletedRulesCalculator();
            var actualCompletedRules = calculator.CalculateForBoard(board);
            var expected = new CompletedBoardRules(
                new List<List<CompletedRuleMarker>> {
                    EmptyMarkerList,
                    EmptyMarkerList,
                    EmptyMarkerList,
                    EmptyMarkerList,
                    EmptyMarkerList
                },
                new List<List<CompletedRuleMarker>> {
                    EmptyMarkerList,
                    EmptyMarkerList,
                    new List<CompletedRuleMarker>{ new CompletedRuleMarker(0,0), new CompletedRuleMarker(2,4) },
                    EmptyMarkerList,
                    EmptyMarkerList
                });
            Assert.Equal(expected, actualCompletedRules);
        }

        [Fact]
        public void FindsBottomRule()
        {
            var board = BoardSamples.Board2
                .ApplyChanges(
                    BoardChange.Filled(2, 2)
                );
            var calculator = new CompletedRulesCalculator();
            var actualCompletedRules = calculator.CalculateForBoard(board);
            var expected = new CompletedBoardRules(
                new List<List<CompletedRuleMarker>> {
                    EmptyMarkerList,
                    EmptyMarkerList,
                    new List<CompletedRuleMarker>{ new CompletedRuleMarker(1,2) },
                },
                new List<List<CompletedRuleMarker>> {
                    EmptyMarkerList,
                    EmptyMarkerList,
                    new List<CompletedRuleMarker>{ new CompletedRuleMarker(1,2) },
                });
            Assert.Equal(expected, actualCompletedRules);
        }

        [Fact]
        public void BottomCrossedLineUntilOneFilled()
        {
            var board = BoardSamples.Board1
                .ApplyChanges(
                    BoardChange.Filled(2, 2),
                    BoardChange.Blocked(2, 3),
                    BoardChange.Blocked(2, 4)
                );
            var calculator = new CompletedRulesCalculator();
            var actualCompletedRules = calculator.CalculateForBoard(board);
            var expected = new CompletedBoardRules(
                new List<List<CompletedRuleMarker>> {
                    EmptyMarkerList,
                    EmptyMarkerList,
                    new List<CompletedRuleMarker>{ new CompletedRuleMarker(1,2) },
                    EmptyMarkerList,
                    EmptyMarkerList
                },
                new List<List<CompletedRuleMarker>> {
                    EmptyMarkerList,
                    EmptyMarkerList,
                    EmptyMarkerList,
                    EmptyMarkerList,
                    EmptyMarkerList
                });
            Assert.Equal(expected, actualCompletedRules);
        }
    }
}
