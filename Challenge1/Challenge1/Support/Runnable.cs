// -----------------------------------------------
//     Author: Ramon Bollen
//       File: Challenge1.Runnable.cs
// Created on: 20200216
// -----------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Challenge1.Model;

[assembly: InternalsVisibleTo("Challenge1.tests")]

namespace Challenge1.Support
{
    internal class Runnable
    {
        // TODO: Add more than 3 fill strings (maybe do something with ASCII values)
        private readonly Dictionary<int, string> _fillStrings = new Dictionary<int, string> {{1, "██"}, {2, "┼┼"}, {3, "··"},{4, "[]"}};

        /// <summary>
        ///     Solution(int[][] A) is the given entrance on the challenge website
        /// </summary>
        public int Solution(int[][] A)
        {
            if (A == null) { throw new ArgumentNullException(); }

            DrawData(A);

            IEnumerable<Country> countries = ParseData(A).ToList();

            if (countries.Count() == 1)
            {
                Console.WriteLine("Only one country found!");
                return 1;
            }

            foreach (Country country in countries)
            {
                Console.WriteLine($"Amount of regions of country ({_fillStrings[country.Code]}): {country.AmountOfRegions()}");
            }

            return countries.Sum(country => country.AmountOfRegions());
        }

        private static IEnumerable<Country> ParseData(int[][] data)
        {
            var countries = new List<Country>();

            for (var y = 0; y < data.Length; y++)
            {
                for (var x = 0; x < data[y].Length; x++)
                {
                    int countryCode = data[y][x];

                    if (countries.Any(c => c.Code == countryCode))
                    {
                        Country country = countries.First(c => c.Code == countryCode);
                        country.AddCoordinate(new Coordinate(x, y));
                    }
                    else
                    {
                        var newCountry = new Country(countryCode);
                        newCountry.AddCoordinate(new Coordinate(x, y));
                        countries.Add(newCountry);
                    }
                }
            }

            return countries;
        }

        private void DrawData(IReadOnlyList<int[]> data)
        {
            foreach (int[] y in data)
            {
                foreach (int x in y) { Console.Write($"{_fillStrings[x]}"); }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}