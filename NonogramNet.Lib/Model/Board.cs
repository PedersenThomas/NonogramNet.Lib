namespace NonogramNet.Lib.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Board : IBoard
    {
        private Board(RulesMatrix topRules, RulesMatrix leftRules)
        {
            TopRules = topRules;
            LeftRules = leftRules;
            matrix = new CellState[topRules.NumberOfRules, leftRules.NumberOfRules];
        }

        private Board(RulesMatrix topRules, RulesMatrix leftRules, CellState[,] matrix)
        {
            TopRules = topRules;
            LeftRules = leftRules;
            this.matrix = matrix;
        }

        private CellState[,] matrix { get; }
        public RulesMatrix TopRules { get; }

        public RulesMatrix LeftRules { get; }

        public int Width => matrix.GetLength(0);

        public int Height => matrix.GetLength(1);

        public CellState this[int x, int y] => matrix[x, y];

        public IBoard ApplyChange(BoardChange change)
        {
            // Check if no change is about to happen. In that case just return the same board since it is immutable.
            if (matrix[change.X, change.Y] == change.NewValue)
            {
                return this;
            }

            var newMatrix = CloneMatrix(matrix);
            newMatrix[change.X, change.Y] = change.NewValue;

            return new Board(TopRules, LeftRules, newMatrix);
        }

        public IBoard ApplyChanges(IEnumerable<BoardChange> changes)
        {
            var newMatrix = matrix;
            var isCloned = false;
            foreach (var change in changes)
            {
                if (newMatrix[change.X, change.Y] == change.NewValue)
                {
                    continue;
                }

                if (!isCloned)
                {
                    newMatrix = CloneMatrix(matrix);
                    isCloned = true;
                }

                newMatrix[change.X, change.Y] = change.NewValue;
            }

            return isCloned ? new Board(TopRules, LeftRules, newMatrix) : this;
        }

        public IBoard ApplyChanges(params BoardChange[] changes)
        {
            var newMatrix = matrix;
            var isCloned = false;
            foreach (var change in changes)
            {
                if (newMatrix[change.X, change.Y] == change.NewValue)
                {
                    continue;
                }

                if (!isCloned)
                {
                    newMatrix = CloneMatrix(matrix);
                    isCloned = true;
                }

                newMatrix[change.X, change.Y] = change.NewValue;
            }

            return isCloned ? new Board(TopRules, LeftRules, newMatrix) : this;
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

            var newMatrix = CloneMatrix(matrix);

            return new Board(topRules, leftRules, newMatrix);
        }

        private static CellState[,] CloneMatrix(CellState[,] oldMatrix)
        {
            var newMatrix = new CellState[oldMatrix.GetLength(0), oldMatrix.GetLength(1)];
            for (var y = 0; y < oldMatrix.GetLength(1); y++)
            {
                for (var x = 0; x < oldMatrix.GetLength(0); x++)
                {
                    newMatrix[x, y] = oldMatrix[x, y];
                }
            }

            return newMatrix;
        }
    }
}