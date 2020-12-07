using System;
using System.Collections.Generic;
using System.Linq;

namespace NonogramNet.Lib.Model
{
    public class GroupCollection
    {
        public List<Group> Groups { get; }

        public bool ContainsNones { get; private set; }

        private Lazy<List<Group>> FilledGroupsLazy;

        public List<Group> FilledGroups => this.FilledGroupsLazy.Value;

        public GroupCollection(List<Group> groups)
        {
            this.Groups = groups;
            this.FilledGroupsLazy = new Lazy<List<Group>>(computeFilledGroups);

            Analyze();
        }

        public bool SatisfiesRuleLine(List<int> ruleLine)
        {
            bool matches = false;
            if (this.FilledGroups.Count == ruleLine.Count)
            {
                matches = true;
                for (int i = 0; i < FilledGroups.Count; i++)
                {
                    if (FilledGroups[i].Count != ruleLine[i])
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
            this.ContainsNones = Groups.Any(g => g.State == CellState.None);
        }

        private List<Group> computeFilledGroups()
        {
            return Groups.Where(p => p.State == CellState.Filled).ToList();
        }
    }
}