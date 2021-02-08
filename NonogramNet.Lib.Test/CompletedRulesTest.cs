using NonogramNet.Lib.Model;
using System.Collections.Generic;
using Xunit;

namespace NonogramNet.Lib.Test
{
    public class CompletedRulesTest
    {
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
                    new List<CompletedRuleMarker>{ },
                    new List<CompletedRuleMarker>{ },
                    new List<CompletedRuleMarker>{ new CompletedRuleMarker(0, 0) }
                },
                new List<List<CompletedRuleMarker>> {
                    new List<CompletedRuleMarker>{ new CompletedRuleMarker(0, 1) },
                    new List<CompletedRuleMarker>{ },
                    new List<CompletedRuleMarker>{ }
                });
            Assert.Equal(expected, actualCompletedRules);
        }

        [Fact]
        public void LineIsCompletButWithEmptySpace()
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
                    new List<CompletedRuleMarker>{ },
                    new List<CompletedRuleMarker>{ },
                    new List<CompletedRuleMarker>{ },
                    new List<CompletedRuleMarker>{ },
                    new List<CompletedRuleMarker>{ }
                },
                new List<List<CompletedRuleMarker>> {
                    new List<CompletedRuleMarker>{ },
                    new List<CompletedRuleMarker>{ },
                    new List<CompletedRuleMarker>{ new CompletedRuleMarker(0,0), new CompletedRuleMarker(1,2), new CompletedRuleMarker(2,4) },
                    new List<CompletedRuleMarker>{ },
                    new List<CompletedRuleMarker>{ }
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
                    new List<CompletedRuleMarker>{ },
                    new List<CompletedRuleMarker>{ },
                    new List<CompletedRuleMarker>{ },
                    new List<CompletedRuleMarker>{ },
                    new List<CompletedRuleMarker>{ }
                },
                new List<List<CompletedRuleMarker>> {
                    new List<CompletedRuleMarker>{ },
                    new List<CompletedRuleMarker>{ },
                    new List<CompletedRuleMarker>{ new CompletedRuleMarker(0,0), new CompletedRuleMarker(2,4) },
                    new List<CompletedRuleMarker>{ },
                    new List<CompletedRuleMarker>{ }
                });
            Assert.Equal(expected, actualCompletedRules);
        }

    }
}
