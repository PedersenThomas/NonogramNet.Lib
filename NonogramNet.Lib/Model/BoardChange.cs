using System;
using System.Collections.Generic;
using System.Text;

namespace NonogramNet.Lib.Model
{
    public struct BoardChange
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public CellState NewValue { get; private set; }

        public BoardChange(int x, int y, CellState value)
        {
            this.X = x;
            this.Y = y;
            this.NewValue = value;
        }
    }
}
