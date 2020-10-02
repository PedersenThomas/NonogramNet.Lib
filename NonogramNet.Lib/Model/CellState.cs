using System;
using System.Collections.Generic;
using System.Text;

namespace NonogramNet.Lib.Model
{
    public enum CellState
    {
        /// <summary>
        /// No decision has been take for this cell
        /// </summary>
        None,

        /// <summary>
        /// The cell is filled in.
        /// </summary>
        Filled,

        /// <summary>
        /// This cell should not be filled in.
        /// </summary>
        Blocked,
    }
}
