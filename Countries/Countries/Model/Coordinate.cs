// -----------------------------------------------
//     Author: Ramon Bollen
//      File: Countries.Coordinate.cs
// Created on: 20201207
// -----------------------------------------------

using System;

namespace Countries.Model
{
    /// <summary>
    ///     X/Y position comparable by X/Y values
    /// </summary>
    public sealed class Coordinate : IEquatable<Coordinate>
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public bool Equals(Coordinate? other) => other is { } coordinate && (X.Equals(coordinate.X) && Y.Equals(coordinate.Y));

        public override bool Equals(object? obj) => obj is Coordinate coordinate && Equals(coordinate);

        public override int GetHashCode() => X + Y;
    }
}