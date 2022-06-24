// -----------------------------------------------
//     Author: Ramon Bollen
//      File: Countries.tests.CountryT.cs
// Created on: 20201207
// -----------------------------------------------

using Countries.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Countries.tests.Model;

[TestClass]
public class CountryT
{
    private Country _country = new(42);

    [TestInitialize]
    public void Initializer() => _country = new Country(42);

    [TestMethod]
    public void No_Coordinates() => Assert.AreEqual(0, _country.NumberOfRegions);

    [TestMethod]
    public void Valid_Country_Code() => Assert.AreEqual(42, _country.CountryCode);

    [TestMethod]
    public void Can_Handle_Double_Coordinates()
    {
        _country.AddCoordinate(new Coordinate(1, 1));
        _country.AddCoordinate(new Coordinate(1, 1));
        _country.AddCoordinate(new Coordinate(1, 1));

        _country.NumberOfRegions.Should().Be(1);
    }

    [TestMethod]
    public void Valid_Amount_Of_Regions_Positive_Coordinates()
    {
        _country.AddCoordinate(new Coordinate(0, 0));
        _country.AddCoordinate(new Coordinate(0, 1));
        _country.AddCoordinate(new Coordinate(2, 0));

        _country.NumberOfRegions.Should().Be(2);
    }

    [TestMethod]
    public void Valid_Amount_Of_Regions_Negative_Coordinates()
    {
        _country.AddCoordinate(new Coordinate(-1, -1));
        _country.AddCoordinate(new Coordinate(-1, -2));
        _country.AddCoordinate(new Coordinate(-3, -1));

        _country.NumberOfRegions.Should().Be(2);
    }

    [TestMethod]
    public void Valid_Amount_Of_Regions_Mixed_Coordinates()
    {
        _country.AddCoordinate(new Coordinate(-1, -1));
        _country.AddCoordinate(new Coordinate(-1, 0));
        _country.AddCoordinate(new Coordinate(-1, 1));

        _country.AddCoordinate(new Coordinate(3, 3));

        _country.AddCoordinate(new Coordinate(-3, -3));

        _country.NumberOfRegions.Should().Be(3);
    }
}