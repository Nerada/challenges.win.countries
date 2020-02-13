//-----------------------------------------------
//      Autor: Ramon Bollen	
//       File: Challenge1.Runnable.cs
// Created on: 202028
//-----------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge1
{
    internal class Runnable
    {
        /// <summary>
        /// Solution(int[][] A) is the given entrance on the challenge website
        /// </summary>
        public int Solution(int[][] A)
        {
            DrawData(A);

            return ParseData(A).Sum(country => country.AmountOfRegionsOfCountry());
        }

        public int[][] CreateData()
        {
            var testData = new int[11][];

            for (var i = 0; i < testData.GetLength(0); i++)
            {
                testData[i] = new int[9];
            }

            //  0                   1                   2                   3                   4                   5                   6                   7                   8
            testData[0][0] = 2; testData[0][1] = 3; testData[0][2] = 3; testData[0][3] = 3; testData[0][4] = 3; testData[0][5] = 2; testData[0][6] = 2; testData[0][7] = 2; testData[0][8] = 2;
            testData[1][0] = 2; testData[1][1] = 1; testData[1][2] = 1; testData[1][3] = 1; testData[1][4] = 1; testData[1][5] = 1; testData[1][6] = 1; testData[1][7] = 1; testData[1][8] = 2;
            testData[2][0] = 2; testData[2][1] = 1; testData[2][2] = 3; testData[2][3] = 3; testData[2][4] = 1; testData[2][5] = 3; testData[2][6] = 3; testData[2][7] = 3; testData[2][8] = 2;
            testData[3][0] = 2; testData[3][1] = 1; testData[3][2] = 3; testData[3][3] = 3; testData[3][4] = 1; testData[3][5] = 3; testData[3][6] = 2; testData[3][7] = 2; testData[3][8] = 2;
            testData[4][0] = 2; testData[4][1] = 1; testData[4][2] = 3; testData[4][3] = 3; testData[4][4] = 1; testData[4][5] = 3; testData[4][6] = 3; testData[4][7] = 3; testData[4][8] = 2;
            testData[5][0] = 2; testData[5][1] = 1; testData[5][2] = 1; testData[5][3] = 1; testData[5][4] = 1; testData[5][5] = 1; testData[5][6] = 1; testData[5][7] = 1; testData[5][8] = 2;
            testData[6][0] = 3; testData[6][1] = 3; testData[6][2] = 4; testData[6][3] = 3; testData[6][4] = 1; testData[6][5] = 2; testData[6][6] = 2; testData[6][7] = 1; testData[6][8] = 2;
            testData[7][0] = 2; testData[7][1] = 2; testData[7][2] = 4; testData[7][3] = 3; testData[7][4] = 1; testData[7][5] = 2; testData[7][6] = 2; testData[7][7] = 1; testData[7][8] = 2;
            testData[8][0] = 2; testData[8][1] = 2; testData[8][2] = 4; testData[8][3] = 3; testData[8][4] = 1; testData[8][5] = 2; testData[8][6] = 2; testData[8][7] = 1; testData[8][8] = 2;
            testData[9][0] = 2; testData[9][1] = 1; testData[9][2] = 1; testData[9][3] = 1; testData[9][4] = 1; testData[9][5] = 2; testData[9][6] = 2; testData[9][7] = 1; testData[9][8] = 2;
            testData[10][0] = 2; testData[10][1] = 2; testData[10][2] = 2; testData[10][3] = 2; testData[10][4] = 2; testData[10][5] = 3; testData[10][6] = 2; testData[10][7] = 2; testData[10][8] = 2;

            return testData;
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
                        Country country = countries.First(r => r.CountryCode == countryCode);
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

        private static void DrawData(int[][] data)
        {
            for (var y = 0; y < data.GetLength(0); y++)
            {
                for (var x = 0; x < data[1].Length; x++)
                {
                    Console.Write($"{data[y][x].ToString().PadLeft(2, '0')} ");
                }
                Console.WriteLine();
            }
        }
    }
}
