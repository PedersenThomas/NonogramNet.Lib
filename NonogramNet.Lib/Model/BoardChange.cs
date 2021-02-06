namespace NonogramNet.Lib.Model
{
    using System;

    public readonly struct BoardChange : IEquatable<BoardChange>
    {
        public int X { get; }

        public int Y { get; }

        public CellState NewValue { get; }

        public BoardChange(int x, int y, CellState value)
        {
            this.X = x;
            this.Y = y;
            this.NewValue = value;
        }

        public static BoardChange Filled(int x, int y) => new BoardChange(x, y, CellState.Filled);

        public static BoardChange None(int x, int y) => new BoardChange(x, y, CellState.None);

        public static BoardChange Blocked(int x, int y) => new BoardChange(x, y, CellState.Blocked);

        public BoardChange Transpose()
        {
            return new BoardChange(this.Y, this.X, this.NewValue);
        }

        public BoardChange Flipped(int width, int height)
        {
            return new BoardChange(width - this.X - 1, height - this.Y - 1, this.NewValue);
        }

        public override string ToString()
        {
            return $"({this.X},{this.Y}) -> {this.NewValue}";
        }

        public bool Equals(BoardChange other)
        {
            return this.X == other.X && this.Y == other.Y && this.NewValue == other.NewValue;
        }

        public override bool Equals(object? obj)
        {
            return obj is BoardChange other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.X, this.Y, this.NewValue);
        }

        public static bool operator ==(BoardChange left, BoardChange right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BoardChange left, BoardChange right)
        {
            return !left.Equals(right);
        }
    }
}
