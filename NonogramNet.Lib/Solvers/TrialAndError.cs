namespace NonogramNet.Lib.Solvers
{
    using NonogramNet.Lib.Model;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TrialAndError : ISolver
    {
        public IEnumerable<BoardChange> Solve(Board board)
        {
            var results = new HashSet<BoardChange>();

            for (int y = 0; y < board.Height; y++)
            {

            }


            return results;
        }

        private void TrialHorizontalLine(Board board, int y, HashSet<BoardChange> results)
        {
            var ruleLine = board.LeftRules.GetRuleLineAt(y);

            //Nothing to do
            if(ruleLine.Count == 0)
            {
                return;
            }

            // Starting from all the way to the left. Fill in the rules to the best possible.

            List<RuleFit> startsFit = new List<RuleFit>();
            int currentRuleIndex = 0;
            for (int x = 0; x < board.Width; x++)
            {
                if(currentRuleIndex >= ruleLine.Count)
                {
                    // All Rules has been placed.
                    break;
                }

                var ruleLength = ruleLine[currentRuleIndex];
                if (DoesRuleFitsAtThePositionHorizontal(board, x, y, ruleLength))
                {
                    startsFit.Add(new RuleFit()
                    {
                        RuleIndex = currentRuleIndex,
                        StartIndex = x,
                        EndINdex = x + ruleLength - 1
                    });
                    currentRuleIndex += 1;
                    x = x + ruleLength - 1;
                }
            }
            if (currentRuleIndex < ruleLine.Count)
            {
                // Not all rules could be placed.
                return;
            }

            // Starting from the end and fill int he rules to the best way possible,
            // if there is an overlap in some rules add those changes.

            List<RuleFit> endFit = new List<RuleFit>();
            currentRuleIndex = ruleLine.Count -1;
            for (int x = 0; x < board.Width; x++)
            {
                if (currentRuleIndex < 0)
                {
                    // All Rules has been placed.
                    break;
                }

                var ruleLength = ruleLine[currentRuleIndex];
                if (DoesRuleFitsAtThePositionHorizontal(board, x, y, ruleLength))
                {
                    endFit.Add(new RuleFit()
                    {
                        RuleIndex = currentRuleIndex,
                        StartIndex = x,
                        EndINdex = x + ruleLength - 1
                    });
                    currentRuleIndex += 1;
                }
            }

        }

        private bool DoesRuleFitsAtThePositionHorizontal(Board board, int y, int x, int ruleLength)
        {
            if(x + ruleLength >= board.Width)
            {
                return true;
            }

            for (int dx = 0; dx < board.Width && dx < x + ruleLength; dx++)
            {
                if (board[dx, y] == CellState.Blocked)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Captures a given fit for a rule.
        /// 
        /// The Start- and End-Index is inclusive of the indexes.
        /// </summary>
        private struct RuleFit
        {
            public int RuleIndex { get; set; }
            public int StartIndex { get; set; }
            public int EndINdex { get; set; }
        }
    }
}
/*




 */