using System;
using System.Collections.Generic;
using System.Text;

namespace NonogramNet.Lib
{
    using Model;

    public class FindCompletedRuleNumbers
    {
        public List<SolvedRules> FindSolved(IBoard board)
        {
            var result = new List<SolvedRules>();

            // Find which rules we know solved.

            throw new NotImplementedException();

            //return result;
        }
    }

    public class SolvedRules
    {
        public int RuleIndex { get; }
        public int StartBoardIndex { get; }

        public SolvedRules(int ruleIndex, int startBoardIndex)
        {
            this.RuleIndex = ruleIndex;
            this.StartBoardIndex = startBoardIndex;
        }
    }
}
