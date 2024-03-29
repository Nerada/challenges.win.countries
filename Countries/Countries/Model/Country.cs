﻿// -----------------------------------------------
//     Author: Ramon Bollen
//      File: Countries.Country.cs
// Created on: 20220623
// -----------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Countries.Model;

/// <summary>
///     A collection of Regions based on given coordinates
///     A country is responsible for calculating its regions
/// </summary>
internal class Country
{
    public Country(int countryCode)
    {
        CountryCode = countryCode;
    }

    public int CountryCode { get; }

    public int NumberOfRegions
    {
        get
        {
            // Coordinates are added since last region calculation
            if (Regions.Count == 0) CalculateRegions();

            return Regions.Count;
        }
    }

    private List<Coordinate> Coordinates { get; } = new();

    private List<Region> Regions { get; } = new();

    public void AddCoordinate(Coordinate coordinate)
    {
        if (Coordinates.Contains(coordinate)) return;

        Regions.Clear();
        Coordinates.Add(coordinate);
    }

    private void CalculateRegions()
    {
        for (int i = Coordinates.Count - 1; i >= 0; i--)
        {
            Coordinate currentCoordinate = new(Coordinates[i].X, Coordinates[i].Y);

            // Check if the current coordinate is already a neighbor
            if (Regions.Any(r => r.Coordinates.Contains(currentCoordinate))) continue;

            Region region = new();
            region.Coordinates.Add(currentCoordinate);
            region.Coordinates.AddRange(GetNeighbors(currentCoordinate));

            Regions.Add(region);
        }
    }

    private IEnumerable<Coordinate> GetNeighbors(Coordinate coordinate)
    {
        List<Coordinate> neighborList = new();
        List<Coordinate> checkList    = new() {coordinate};

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
        List<Coordinate> neighbors = new();

        // Right
        if (Coordinates.Any(c => c.X == coordinate.X + 1 && c.Y == coordinate.Y)) neighbors.Add(new Coordinate(coordinate.X + 1, coordinate.Y));

        // Left
        if (Coordinates.Any(c => c.X == coordinate.X - 1 && c.Y == coordinate.Y)) neighbors.Add(new Coordinate(coordinate.X - 1, coordinate.Y));

        // Up
        if (Coordinates.Any(c => c.X == coordinate.X && c.Y == coordinate.Y + 1)) neighbors.Add(new Coordinate(coordinate.X, coordinate.Y + 1));

        // Down
        if (Coordinates.Any(c => c.X == coordinate.X && c.Y == coordinate.Y - 1)) neighbors.Add(new Coordinate(coordinate.X, coordinate.Y - 1));

        return neighbors;
    }
}