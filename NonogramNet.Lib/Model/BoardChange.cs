﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NonogramNet.Lib.Model
{
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

        public override string ToString()
        {
            return $"({this.X},{this.Y}) -> {this.NewValue}";
        }

        public bool Equals(BoardChange other)
        {
            return X == other.X && Y == other.Y && NewValue == other.NewValue;
        }

        public override bool Equals(object? obj)
        {
            return obj is BoardChange other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X;
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ (int) NewValue;
                return hashCode;
            }
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
