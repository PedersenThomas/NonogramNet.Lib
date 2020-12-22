using System;
using System.Collections.Immutable;

namespace Nonogramnet.lib
{
    public class NonogramBoard
    {
        private CellState[,] data;
        public BoardConstraints Constraints { get; }
        public Manifest Manifest { get; }

        public NonogramBoard(int width, int height, BoardConstraints constraints, Manifest manifest)
        {
            data = new CellState[width, height];
            this.Constraints = constraints;
            this.Manifest = manifest;
        }

        public CellState this[int x, int y]
        {
            get { return data[x, y]; }
            set { this.data[x, y] = value; }
        }
    }
}
