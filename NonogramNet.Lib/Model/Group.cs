using System;
using System.Collections.Generic;
using System.Linq;

namespace NonogramNet.Lib.Model
{
    public class Group
    {
        public List<(CellState state, int count)> Groups { get; }

        public bool ContainsNones { get; private set; }

        private Lazy<List<(CellState state, int count)>> FilledGroupsLazy;

        public List<(CellState state, int count)> FilledGroups => this.FilledGroupsLazy.Value;

        public Group(List<(CellState state, int count)> groups)
        {
            this.Groups = groups;
            this.FilledGroupsLazy = new Lazy<List<(CellState state, int count)>>(computeFilledGroups);

            Analyze();
        }

        public bool SatisfiesRuleLine(List<int> ruleLine)
        {
            bool matches = false;
            if (this.ContainsNones && this.FilledGroups.Count == ruleLine.Count)
            {
                matches = true;
                for (int i = 0; i < FilledGroups.Count; i++)
                {
                    if (FilledGroups[i].count != ruleLine[i])
                    {
                        matches = false;
                        break;
                    }
                }
            }
            return matches;
        }

        private void Analyze()
        {
            this.ContainsNones = Groups.Any(g => g.state == CellState.None);
        }

        private List<(CellState state, int count)> computeFilledGroups()
        {
            return Groups.Where(p => p.state == CellState.Filled).ToList();
        }
    }
}