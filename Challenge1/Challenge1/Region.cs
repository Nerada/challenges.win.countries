//-----------------------------------------------
//      Author: Ramon Bollen
//       File: Challenge1.Region.cs
// Created on: 2020213
//-----------------------------------------------

namespace Challenge1
{
    /// <summary>
    /// A collection of coordinates that form a region (are neighbors of each other)
    /// </summary>
    internal class Region
    {
        public List<Coordinate> Coordinates { get; } = new List<Coordinate>();
    }
}