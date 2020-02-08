//-----------------------------------------------
//      Autor: Ramon Bollen	
//       File: Challenge1.Coordinate.cs
// Created on: 202028
//-----------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;

namespace Challenge1
{
    class Coordinate : IEquatable<Coordinate>
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public bool Equals([DisallowNull] Coordinate other)
        {
            return X.Equals(other?.X) && Y.Equals(other?.Y);
        }

        public override int GetHashCode()
        {
            return X + Y;
        }
    }
}
