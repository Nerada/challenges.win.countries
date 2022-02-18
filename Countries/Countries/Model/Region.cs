// -----------------------------------------------
//     Author: Ramon Bollen
//      File: Countries.Region.cs
// Created on: 20201207
// -----------------------------------------------

using System.Collections.Generic;

namespace Countries.Model
{
    /// <summary>
    ///     A collection of coordinates that form a region (are neighbors of each other)
    /// </summary>
    public class Region
    {
        public List<Coordinate> Coordinates { get; } = new();
    }
}