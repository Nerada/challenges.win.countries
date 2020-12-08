// -----------------------------------------------
//     Author: Ramon Bollen
//       File: Countries.Coordinate.cs
// Created on: 20200215
// -----------------------------------------------

using System;

namespace Countries.Model
{
    /// <summary>
    ///     X/Y position comparable by X/Y values
    /// </summary>
    internal class Coordinate : IEquatable<Coordinate>
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public bool Equals(Coordinate? other) => X.Equals(other?.X) && Y.Equals(other.Y);

        public override int GetHashCode() => X + Y;
    }
}