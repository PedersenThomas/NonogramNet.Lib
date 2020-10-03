using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace NonogramNet.Lib.Model
{
    public class RulesMatrix: IEnumerable<List<int>>
    {
        private List<List<int>> Rules { get; set; }

        public int NumberOfRules => this.Rules.Count;

        private RulesMatrix()
        {
            this.Rules = new List<List<int>>();
        }
        private RulesMatrix(List<List<int>> rules)
        {
            this.Rules = rules;
        }

        public static RulesMatrix MakeRulesMatrix(List<List<int>> rules)
        {
            if (rules == null)
            {
                throw new ArgumentNullException(nameof(rules));
            }

            List<List<int>> newRules = new List<List<int>>();
            int index = 0;
            foreach (List<int> ruleLine in rules)
            {
                if (ruleLine == null)
                {
                    throw new ArgumentNullException(nameof(rules), $"Rule line {index} is null");
                }

                index++;
                newRules.Add(new List<int>(ruleLine));
            }

            return new RulesMatrix(newRules);
        }

        public int this[int x, int y]
        {
            get { return this.Rules[x][y]; }
            private set { this.Rules[x][y] = value; }
        }

        public List<int> GetRuleLineAt(int index)
        {
            return Rules[index];
        }

        public IEnumerator<List<int>> GetEnumerator()
        {
            return this.Rules.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
