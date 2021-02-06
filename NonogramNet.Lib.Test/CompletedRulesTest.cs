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
                    new List<CompletedRuleMarker>{ },
                    new List<CompletedRuleMarker>{ },
                    new List<CompletedRuleMarker>{ } // Should have new CompletedRuleMarker(0,0)
                });
            Assert.Equal(expected, actualCompletedRules);
        }

    }
}
