using System;
using System.Collections.Generic;
using System.Text;
using NonogramNet.Lib.Model;

namespace NonogramNet.Lib.Solvers
{
    public class SolverCombiner : ISolver
    {
        public static Lazy<ISolver> AllSolvers = new Lazy<ISolver>(() =>
        {
            var combine = new SolverCombiner();

            combine.Add(new CrossOutCompletedLine());
            combine.Add(new SingleGiantNumber());
            combine.Add(new OnlyOneWayToFill());
            combine.Add(new LargestNumberInRuleIsSolvedWrapInBlocked());
            combine.Add(new FirstGroupTooSmall());

            return combine;
        });

        private List<ISolver> Solvers { get; }

        public SolverCombiner()
        {
            this.Solvers = new List<ISolver>();
        }

        public void Add(ISolver solver)
        {
            this.Solvers.Add(solver);
        }

        public IEnumerable<BoardChange> Solve(IBoard board)
        {
            var changes = new List<BoardChange>();
            foreach (var solver in Solvers)
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
