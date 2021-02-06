using System;
using System.Collections.Generic;
using System.Text;

namespace NonogramNet.Lib
{
    public class CompletedBoardRules : IEquatable<CompletedBoardRules>
    {
        public CompletedBoardRules(List<List<CompletedRuleMarker>> topRules, List<List<CompletedRuleMarker>> leftRules)
        {
            this.TopRules = topRules ?? throw new ArgumentNullException(nameof(topRules));
            this.LeftRules = leftRules ?? throw new ArgumentNullException(nameof(leftRules));
        }

        public List<List<CompletedRuleMarker>> TopRules { get; }

        public List<List<CompletedRuleMarker>> LeftRules { get; }

        public bool Equals(CompletedBoardRules other)
        {
            if(ReferenceEquals(other, null))
            {
                return false;
            }

            if(this.TopRules.Count != other.TopRules.Count ||
                this.LeftRules.Count != other.LeftRules.Count)
            {
                return false;
            }

            return EqualCompletedRulesMatrix(this.TopRules, other.TopRules) &&
                EqualCompletedRulesMatrix(this.LeftRules, other.LeftRules);

        }

        private static bool EqualCompletedRulesMatrix(List<List<CompletedRuleMarker>> thisMatrix, List<List<CompletedRuleMarker>> otherMatrix)
        {
            for (int x = 0; x < thisMatrix.Count; x++)
            {
                var thisTopLine = thisMatrix[x];
                var otherTopLine = otherMatrix[x];
                
                if (thisTopLine.Count != otherTopLine.Count)
                {
                    return false;   
                }

                for (int y = 0; y < thisTopLine.Count; y++)
                {
                    if (!thisTopLine[y].Equals(otherTopLine[y]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
