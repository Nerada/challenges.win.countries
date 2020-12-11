// -----------------------------------------------
//     Author: Ramon Bollen
//      File: Countries.tests.CountryT.cs
// Created on: 20201207
// -----------------------------------------------

using Countries.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Countries.tests.Model
{
    [TestClass]
    public class CountryT
    {
        private Country _country = new Country(42);

        [TestInitialize]
        public void Initializer() => _country = new Country(42);

        [TestMethod]
        public void No_Coordinates() => Assert.AreEqual(0, _country.AmountOfRegions());

        [TestMethod]
        public void Valid_Country_Code() => Assert.AreEqual(42, _country.Code);

        [TestMethod]
        public void Can_Handle_Double_Coordinates()
        {
            _country.AddCoordinate(new Coordinate(1, 1));
            _country.AddCoordinate(new Coordinate(1, 1));
            _country.AddCoordinate(new Coordinate(1, 1));

            Assert.AreEqual(1, _country.AmountOfRegions());
        }

        [TestMethod]
        public void Valid_Amount_Of_Regions_Positive_Coordinates()
        {
            _country.AddCoordinate(new Coordinate(0, 0));
            _country.AddCoordinate(new Coordinate(0, 1));
            _country.AddCoordinate(new Coordinate(2, 0));

            Assert.AreEqual(2, _country.AmountOfRegions());
        }

        [TestMethod]
        public void Valid_Amount_Of_Regions_Negative_Coordinates()
        {
            _country.AddCoordinate(new Coordinate(-1, -1));
            _country.AddCoordinate(new Coordinate(-1, -2));
            _country.AddCoordinate(new Coordinate(-3, -1));

            Assert.AreEqual(2, _country.AmountOfRegions());
        }

        [TestMethod]
        public void Valid_Amount_Of_Regions_Mixed_Coordinates()
        {
            _country.AddCoordinate(new Coordinate(-1, -1));
            _country.AddCoordinate(new Coordinate(-1, 0));
            _country.AddCoordinate(new Coordinate(-1, 1));

            _country.AddCoordinate(new Coordinate(3, 3));

            _country.AddCoordinate(new Coordinate(-3, -3));

            Assert.AreEqual(3, _country.AmountOfRegions());
        }
    }
}