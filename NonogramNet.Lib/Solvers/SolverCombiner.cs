using System;
using System.Collections.Generic;
using System.Text;
using NonogramNet.Lib.Model;

namespace NonogramNet.Lib.Solvers
{
    public class SolverCombiner : ISolver
    {
        private List<ISolver> solvers { get; }

        public SolverCombiner()
        {
            this.solvers = new List<ISolver>();
        }

        public void Add(ISolver solver)
        {
            this.solvers.Add(solver);
        }

        public IEnumerable<BoardChange> Solve(IBoard board)
        {
            var changes = new List<BoardChange>();
            foreach (var solver in solvers)
            {
                var c = solver.Solve(board);
                if (c != null)
                {
                    changes.AddRange(c);
                }
            }

            return changes;
        }
    }
}
