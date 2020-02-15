// -----------------------------------------------
//     Author: Ramon Bollen
//       File: Challenge1.Runnable.cs
// Created on: 20200215
// -----------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Challenge1.Model;

[assembly: InternalsVisibleTo("Challenge1.tests")]
namespace Challenge1
{
    internal class Runnable
    {
        private readonly Dictionary<int, string> _fillStrings = new Dictionary<int, string> {{1, "··"}, {2, "##"}, {3, "¤¤"}};

        /// <summary>
        ///     Solution(int[][] A) is the given entrance on the challenge website
        /// </summary>
        public int Solution(int[][] A)
        {
            if (A == null) { throw new ArgumentNullException(); }

            DrawData(A);

            IEnumerable<Country> countries = ParseData(A).ToList();
            foreach (var country in countries)
            {
                Console.WriteLine($"Amount of regions of country ({_fillStrings[country.CountryCode]}): {country.AmountOfRegions()}");
            }

            return countries.Sum(country => country.AmountOfRegions());
        }

        private static IEnumerable<Country> ParseData(int[][] data)
        {
            var countries = new List<Country>();

            for (var y = 0; y < data.GetLength(0); y++)
            {
                for (var x = 0; x < data[1].Length; x++)
                {
                    int countryCode = data[y][x];

                    if (countries.Any(r => r.CountryCode == countryCode))
                    {
                        var country = countries.First(r => r.CountryCode == countryCode);
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

        private void DrawData(int[][] data)
        {
            for (var y = 0; y < data.GetLength(0); y++)
            {
                for (var x = 0; x < data[1].Length; x++) { Console.Write($"{_fillStrings[data[y][x]]}"); }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}