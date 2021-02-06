using System;

namespace NonogramNet.Lib
{
    public class CompletedRuleMarker : IEquatable<CompletedRuleMarker>
    {
        public CompletedRuleMarker(int ruleIndex, int startIndex)
        {
            this.RuleIndex = ruleIndex;
            this.StartIndex = startIndex;
        }

        public int RuleIndex { get; set; }
        public int StartIndex { get; set; }

        public bool Equals(CompletedRuleMarker other)
        {
            if(ReferenceEquals(other,null))
            {
                return false;
            }

            return this.RuleIndex == other.RuleIndex &&
                this.StartIndex == other.StartIndex;
        }

        public override string ToString() => $"Rule:{this.RuleIndex}, StartIndex:{this.StartIndex}";
    }
}
