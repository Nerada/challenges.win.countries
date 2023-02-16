// -----------------------------------------------
//     Author: Ramon Bollen
//      File: Countries.RegionCalculator.cs
// Created on: 20220623
// -----------------------------------------------

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using Countries.Model;

[assembly: InternalsVisibleTo("Countries.tests")]

namespace Countries.Support;

public class RegionCalculator
{
    /// <summary>
    ///     Calculate(int[][] A) is the given start on the challenge website
    /// </summary>
    [SuppressMessage("Blocker Code Smell", "S2368:Public methods should not have multidimensional array parameters",
                     Justification = "Challenge made this parameter mandatory")]
    public CalculationSummary Calculate(int[][] a) => new(ParseData(a).ConvertAll(c => (c.CountryCode, AmountOfRegions: c.NumberOfRegions)).ToImmutableArray());

    private static List<Country> ParseData(IReadOnlyList<int[]> data)
    {
        List<Country> countries = new();

        for (int y = 0; y < data.Count; y++)
        {
            for (int x = 0; x < data[y].Length; x++)
            {
                int countryCode = data[y][x];

                if (countries.Any(c => c.CountryCode == countryCode))
                {
                    Country country = countries.First(c => c.CountryCode == countryCode);
                    country.AddCoordinate(new Coordinate(x, y));
                }
                else
                {
                    Country newCountry = new(countryCode);
                    newCountry.AddCoordinate(new Coordinate(x, y));
                    countries.Add(newCountry);
                }
            }
        }

        return countries;
    }
}