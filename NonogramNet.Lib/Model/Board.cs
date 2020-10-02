using System;
using System.Collections.Generic;
using System.Text;

namespace NonogramNet.Lib.Model
{
    public class Board
    {
        public RulesMatrix TopRules { get; }

        public RulesMatrix LeftRules { get; }

        public int Width => this.matrix.GetLength(0);

        public int Height => this.matrix.GetLength(1);

        private CellState[,] matrix { get; }

        private Board(RulesMatrix topRules, RulesMatrix leftRules)
        {
            this.TopRules = topRules;
            this.LeftRules = leftRules;
            matrix = new CellState[topRules.NumberOfRules, leftRules.NumberOfRules];
        }

        private Board(RulesMatrix topRules, RulesMatrix leftRules, CellState[,] matrix)
        {
            this.TopRules = topRules;
            this.LeftRules = leftRules;
            this.matrix = matrix;
        }

        public static Board MakeBoard(RulesMatrix topRules, RulesMatrix leftRules)
        {
            if (topRules == null)
            {
                throw new ArgumentNullException(nameof(topRules));
            }
            if (leftRules == null)
            {
                throw new ArgumentNullException(nameof(leftRules));
            }
            return new Board(topRules, leftRules);
        }

        public static Board MakeBoard(RulesMatrix topRules, RulesMatrix leftRules, CellState[,] matrix)
        {
            if (topRules == null)
            {
                throw new ArgumentNullException(nameof(topRules));
            }
            if (leftRules == null)
            {
                throw new ArgumentNullException(nameof(leftRules));
            }

            if (topRules.NumberOfRules != matrix.GetLength(0))
            {
                throw new ArgumentException($"The number of TopRules doesn't match the dimension of the matrix. TopRules: {topRules.NumberOfRules} <> Matrix: {matrix.GetLength(0)}");
            }

            if (leftRules.NumberOfRules != matrix.GetLength(1))
            {
                throw new ArgumentException($"The number of LeftRules doesn't match the dimension of the matrix. LeftRules: {leftRules.NumberOfRules} <> Matrix: {matrix.GetLength(0)}");
            }

            CellState[,] newMatrix = CloneMatrix(matrix);

            return new Board(topRules, leftRules, newMatrix);
        }

        public CellState this[int x, int y] => this.matrix[x, y];

        public Board ApplyChange(BoardChange change)
        {
            // Check if no change is about to happen. In that case just return the same board since it is immutable.
            if (this.matrix[change.X, change.Y] == change.NewValue)
            {
                return this;
            }

            var newMatrix = CloneMatrix(this.matrix);
            newMatrix[change.X, change.Y] = change.NewValue;

            return new Board(this.TopRules, this.LeftRules, newMatrix);
        }

        public Board ApplyChanges(IEnumerable<BoardChange> changes)
        {
            var newMatrix = this.matrix;
            bool isCloned = false;
            foreach (var change in changes)
            {
                if (newMatrix[change.X, change.Y] == change.NewValue)
                {
                    continue;
                }

                if (!isCloned)
                {
                    newMatrix = CloneMatrix(this.matrix);
                    isCloned = true;
                }

                newMatrix[change.X, change.Y] = change.NewValue;
            }

            return isCloned ? new Board(this.TopRules, this.LeftRules, newMatrix) : this;
        }
        public Board ApplyChanges(params BoardChange[] changes)
        {
            var newMatrix = this.matrix;
            bool isCloned = false;
            foreach (var change in changes)
            {
                if (newMatrix[change.X, change.Y] == change.NewValue)
                {
                    continue;
                }

                if (!isCloned)
                {
                    newMatrix = CloneMatrix(this.matrix);
                    isCloned = true;
                }

                newMatrix[change.X, change.Y] = change.NewValue;
            }

            return isCloned ? new Board(this.TopRules, this.LeftRules, newMatrix) : this;
        }

        private static CellState[,] CloneMatrix(CellState[,] oldMatrix)
        {
            CellState[,] newMatrix = new CellState[oldMatrix.GetLength(0), oldMatrix.GetLength(0)];
            for (int y = 0; y < oldMatrix.GetLength(1); y++)
            {
                for (int x = 0; x < oldMatrix.GetLength(0); x++)
                {
                    newMatrix[x, y] = oldMatrix[x, y];
                }
            }

            return newMatrix;
        }
    }
}
