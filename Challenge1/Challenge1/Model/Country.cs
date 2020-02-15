// -----------------------------------------------
//     Author: Ramon Bollen
//       File: Challenge1.Country.cs
// Created on: 20200215
// -----------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Challenge1.Model
{
    /// <summary>
    ///     A collection of Regions based on given coordinates
    ///     A country is responsible for calculating its regions
    /// </summary>
    internal class Country
    {
        public Country(int code) => CountryCode = code;

        public int CountryCode { get; }

        private List<Coordinate> Coordinates { get; } = new List<Coordinate>();

        private List<Region> Regions { get; } = new List<Region>();

        public void AddCoordinate(Coordinate coordinate)
        {
            if (coordinate == null || Coordinates.Contains(coordinate)) { return; }

            Regions.Clear();
            Coordinates.Add(coordinate);
        }

        public int AmountOfRegions()
        {
            // Only (re)calculate when new coordinates are present
            if (Regions.Count == 0) { CalculateRegions(); }

            return Regions.Count;
        }

        private void CalculateRegions()
        {
            for (int i = Coordinates.Count - 1; i >= 0; i--)
            {
                var currentCoordinate = new Coordinate(Coordinates[i].X, Coordinates[i].Y);

                // Check if the current coordinate is already a neighbor
                if (Regions.Any(r => r.Coordinates.Contains(currentCoordinate))) { continue; }

                var region = new Region();
                region.Coordinates.Add(currentCoordinate);
                region.Coordinates.AddRange(GetNeighbors(currentCoordinate));

                Regions.Add(region);
            }
        }

        private IEnumerable<Coordinate> GetNeighbors(Coordinate coordinate)
        {
            var neighborList = new List<Coordinate>();
            var checkList    = new List<Coordinate> {coordinate};

            while (checkList.Count != 0)
            {
                Coordinate checkCoordinate = checkList[0];

                checkList.AddRange(CheckDirectNeighbors(checkList[0]).Where(cl => !neighborList.Contains(cl)));

                neighborList.Add(checkCoordinate);
                checkList.Remove(checkCoordinate);
            }

            // The initial coordinate is not a neighbor
            neighborList.RemoveAll(c => c.Equals(coordinate));

            return neighborList.Distinct().ToList();
        }

        private IEnumerable<Coordinate> CheckDirectNeighbors(Coordinate coordinate)
        {
            var neighbors = new List<Coordinate>();

            // Right
            if (Coordinates.Any(c => c.X == coordinate.X + 1 && c.Y == coordinate.Y))
            {
                neighbors.Add(new Coordinate(coordinate.X + 1, coordinate.Y));
            }

            // Left
            if (Coordinates.Any(c => c.X == coordinate.X - 1 && c.Y == coordinate.Y))
            {
                neighbors.Add(new Coordinate(coordinate.X - 1, coordinate.Y));
            }

            // Up
            if (Coordinates.Any(c => c.X == coordinate.X && c.Y == coordinate.Y + 1))
            {
                neighbors.Add(new Coordinate(coordinate.X, coordinate.Y + 1));
            }

            // Down
            if (Coordinates.Any(c => c.X == coordinate.X && c.Y == coordinate.Y - 1))
            {
                neighbors.Add(new Coordinate(coordinate.X, coordinate.Y - 1));
            }

            return neighbors;
        }
    }
}