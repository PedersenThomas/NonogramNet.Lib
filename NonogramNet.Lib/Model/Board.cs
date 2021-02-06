namespace NonogramNet.Lib.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Board : IBoard
    {
        private Board(IRulesMatrix topRules, IRulesMatrix leftRules)
        {
            this.TopRules = topRules;
            this.LeftRules = leftRules;
            this.Matrix = new CellState[topRules.NumberOfRules, leftRules.NumberOfRules];
        }

        private Board(IRulesMatrix topRules, IRulesMatrix leftRules, CellState[,] matrix)
        {
            this.TopRules = topRules;
            this.LeftRules = leftRules;
            this.Matrix = matrix;
        }

        private CellState[,] Matrix { get; }

        public IRulesMatrix TopRules { get; }

        public IRulesMatrix LeftRules { get; }

        public int Width => this.Matrix.GetLength(0);

        public int Height => this.Matrix.GetLength(1);

        public CellState this[int x, int y] => this.Matrix[x, y];

        public IBoard ApplyChange(BoardChange change)
        {
            // Check if no change is about to happen. In that case just return the same board since it is immutable.
            if (this.Matrix[change.X, change.Y] == change.NewValue)
            {
                return this;
            }

            CellState[,]? newMatrix = CloneMatrix(this.Matrix);
            newMatrix[change.X, change.Y] = change.NewValue;

            return new Board(this.TopRules, this.LeftRules, newMatrix);
        }

        public IBoard ApplyChanges(IEnumerable<BoardChange> changes)
        {
            CellState[,]? newMatrix = this.Matrix;
            bool isCloned = false;
            foreach (BoardChange change in changes)
            {
                if (newMatrix[change.X, change.Y] == change.NewValue)
                {
                    continue;
                }

                if (!isCloned)
                {
                    newMatrix = CloneMatrix(this.Matrix);
                    isCloned = true;
                }

                newMatrix[change.X, change.Y] = change.NewValue;
            }

            return isCloned ? new Board(this.TopRules, this.LeftRules, newMatrix) : this;
        }

        public IBoard ApplyChanges(params BoardChange[] changes)
        {
            CellState[,]? newMatrix = this.Matrix;
            bool isCloned = false;
            foreach (BoardChange change in changes)
            {
                if (newMatrix[change.X, change.Y] == change.NewValue)
                {
                    continue;
                }

                if (!isCloned)
                {
                    newMatrix = CloneMatrix(this.Matrix);
                    isCloned = true;
                }

                newMatrix[change.X, change.Y] = change.NewValue;
            }

            return isCloned ? new Board(this.TopRules, this.LeftRules, newMatrix) : this;
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
                throw new ArgumentException(
                    $"The number of TopRules doesn't match the dimension of the matrix. TopRules: {topRules.NumberOfRules} <> Matrix: {matrix.GetLength(0)}");
            }

            if (leftRules.NumberOfRules != matrix.GetLength(1))
            {
                throw new ArgumentException(
                    $"The number of LeftRules doesn't match the dimension of the matrix. LeftRules: {leftRules.NumberOfRules} <> Matrix: {matrix.GetLength(0)}");
            }

            CellState[,]? newMatrix = CloneMatrix(matrix);

            return new Board(topRules, leftRules, newMatrix);
        }

        private static CellState[,] CloneMatrix(CellState[,] oldMatrix)
        {
            CellState[,]? newMatrix = new CellState[oldMatrix.GetLength(0), oldMatrix.GetLength(1)];
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