using System;
using System.Collections.Generic;
using System.Text;
using NonogramNet.Lib.Model;

namespace NonogramNet.Lib.Solvers
{
    public interface ISolver
    {
        IEnumerable<BoardChange> Solve(IBoard board);
    }
}
