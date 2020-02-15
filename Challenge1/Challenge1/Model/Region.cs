// -----------------------------------------------
//     Author: Ramon Bollen
//       File: Challenge1.Region.cs
// Created on: 20200215
// -----------------------------------------------

using System.Collections.Generic;

namespace Challenge1.Model
{
    /// <summary>
    ///     A collection of coordinates that form a region (are neighbors of each other)
    /// </summary>
    internal class Region
    {
        public List<Coordinate> Coordinates { get; } = new List<Coordinate>();
    }
}