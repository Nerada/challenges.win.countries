// -----------------------------------------------
//     Author: Ramon Bollen
//      File: Countries.tests.RegionCalculatorT.cs
// Created on: 20201207
// -----------------------------------------------

using System;
using System.Linq;
using Countries.Support;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Countries.tests;

[TestClass]
public class RegionCalculatorT
{
    private RegionCalculator _regionCalculator = new();

    [TestInitialize]
    public void Initializer() => _regionCalculator = new RegionCalculator();

    /// <summary>
    ///     Integration Test, check valid output based on specified region.
    /// </summary>
    [TestMethod]
    public void Has_Valid_Solution() => _regionCalculator.Calculate(TestData.GetSpecificLayout()).Results.Sum(c => c.AmountOfRegions).Should().Be(8);

    [TestMethod]
    public void Valid_Output_On_Empty_Input() => _regionCalculator.Calculate(Array.Empty<int[]>()).Results.Sum(c => c.AmountOfRegions).Should().Be(0);

    [TestMethod]
    public void Valid_Output_On_Single_Value_Input()
    {
        int[][] testArray = CreateInitialArray(1, 1);

        foreach (int[] y in testArray)
        {
            foreach (int x in y)
            {
                y[x] = 1;
            }
        }

        _regionCalculator.Calculate(testArray).Results.Sum(c => c.AmountOfRegions).Should().Be(1);
    }

    private static int[][] CreateInitialArray(int x, int y)
    {
        int[][] array = new int[x][];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = new int[y];
        }

        return array;
    }
}