//-----------------------------------------------
//      Autor: Ramon Bollen	
//       File: Challenge1.Country.cs
// Created on: 202028
//-----------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Challenge1
{
    internal class Country
    {
        public Country(int code)
        {
            CountryCode = code;
        }

        public int CountryCode;
        public List<Coordinate> Coordinates { get; } = new List<Coordinate>();

        public int AmountOfRegionsOfCountry()
        {
            return Coordinates.Count - GetNeighborAmount(Coordinates);
        }

        private int GetNeighborAmount(IReadOnlyList<Coordinate> coordinates)
        {
            var neighborList = new List<Coordinate>();

            for (int i = coordinates.Count - 1; i >= 0; i--)
            {
                var currentCoordinate = new Coordinate(coordinates[i].X, coordinates[i].Y);

                if (!neighborList.Contains(currentCoordinate))
                {
                    neighborList.AddRange(GetNeighbors(currentCoordinate));
                }
            }

            return neighborList.Count;
        }

        private IEnumerable<Coordinate> GetNeighbors(Coordinate coordinate)
        {
            var neighborList = new List<Coordinate>();
            var checkList = new List<Coordinate> { coordinate };

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
