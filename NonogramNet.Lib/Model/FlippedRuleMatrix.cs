namespace NonogramNet.Lib.Model
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class FlippedRuleMatrix : IRulesMatrix
    {
        private readonly IRulesMatrix matrix;

        public FlippedRuleMatrix(IRulesMatrix matrix)
        {
            this.matrix = RulesMatrix.MakeRulesMatrix(
                matrix
                    .Reverse()
                    .Select(a => a.Reverse().ToList())
                    .ToList()
                );
        }

        public IRuleLine this[int x] => this.matrix[x];

        public int this[int x, int y] => this.matrix[x, y];

        public int NumberOfRules => this.matrix.NumberOfRules;

        public IEnumerator<IRuleLine> GetEnumerator()
        {
            return this.matrix.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.matrix.GetEnumerator();
        }
    }
}
