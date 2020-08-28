using System;
using System.Collections.Generic;
using System.Text;

namespace NonogramNet.Lib.Model
{
    public class RulesMatrix
    {
        private List<List<int>> Rules { get; set; }
        public int NumberOfRules => this.Rules.Count;

        public RulesMatrix()
        {
            this.Rules = new List<List<int>>();
        }

        public List<int> GetRuleLineAt(int index)
        {
            return Rules[index];
        }
    }
}
