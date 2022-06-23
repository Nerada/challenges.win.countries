// -----------------------------------------------
//     Author: Ramon Bollen
//      File: Countries.Program.cs
// Created on: 20201207
// -----------------------------------------------

using System;
using System.Linq;
using System.Text;
using Countries.Support;

namespace Countries;

internal static class Program
{
    private static readonly RegionCalculator RegionCalculator = new();
    private static readonly Drawing          RegionDrawer     = new();

    private static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.SetWindowSize(55, 50);

        int[][] specificData = TestData.GetSpecificLayout();
        RegionDrawer.Draw("Predefined layout", specificData);
        WriteResults(RegionCalculator.Calculate(specificData));

        RandomRun(1);

        int randomRuns = 1;

        while (Console.ReadKey().Key != ConsoleKey.Escape)
        {
            RandomRun(++randomRuns);
        }

        Environment.Exit(0);
    }

    private static void RandomRun(int run)
    {
        int[][] randomData = TestData.GetRandomLayout();
        RegionDrawer.Draw($"Random layout {run}", randomData);
        WriteResults(RegionCalculator.Calculate(randomData));
    }

    private static void WriteResults(CalculationSummary summary)
    {
        if (summary.Results.Length == 1)
        {
            Console.WriteLine("Only one country found!");
        }

        foreach ((int countryCode, int regions) in summary.Results)
        {
            Console.WriteLine($"Amount of regions of country ({Drawing.CountryFlags[countryCode]}): {regions}");
        }

        Console.WriteLine($"{Environment.NewLine}Total amount of regions: {summary.Results.Sum(result => result.AmountOfRegions)}");
        Console.WriteLine();
    }
}