using System;
using System.Collections;
using System.Collections.Generic;

namespace NonogramNet.Lib.Model
{
    public class RulesMatrix: IRulesMatrix
    {
        private List<IRuleLine> Rules { get; set; }

        public int NumberOfRules => this.Rules.Count;

        private RulesMatrix()
        {
            this.Rules = new List<IRuleLine>();
        }

        private RulesMatrix(List<IRuleLine> rules)
        {
            this.Rules = rules;
        }

        public static RulesMatrix MakeRulesMatrix(List<List<int>> rules)
        {
            if (rules == null)
            {
                throw new ArgumentNullException(nameof(rules));
            }

            List<IRuleLine> newRules = new List<IRuleLine>();
            int index = 0;
            foreach (List<int> ruleLine in rules)
            {
                if (ruleLine == null)
                {
                    throw new ArgumentNullException(nameof(rules), $"Rule line {index} is null");
                }

                index++;
                newRules.Add(new RuleLine(ruleLine));
            }

            return new RulesMatrix(newRules);
        }

        public IRuleLine this[int x] => this.Rules[x];

        public int this[int x, int y] => this.Rules[x][y];

        public IEnumerator<IRuleLine> GetEnumerator()
        {
            return this.Rules.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
