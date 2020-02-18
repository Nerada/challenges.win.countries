// -----------------------------------------------
//     Author: Ramon Bollen
//       File: Challenge1.Program.cs
// Created on: 20200210
// -----------------------------------------------

using System;
using Challenge1.Support;

namespace Challenge1
{
    internal static class Program
    {
        private static void Main()
        {
            Console.SetWindowSize(55, 50);

            var run = new Runnable();
            string divider = $"--------------------------------------------------";

            Console.WriteLine(divider);
            Console.WriteLine($"Predefined layout:");
            Console.WriteLine($"{Environment.NewLine}Total amount of regions: {run.Solution(TestData.GetSpecificLayout())}");
            Console.WriteLine(divider);
            Console.WriteLine($"Random layout:");
            Console.WriteLine($"{Environment.NewLine}Total amount of regions: {run.Solution(TestData.GetRandomLayout())}");
            Console.WriteLine(divider);

            Console.ReadKey();

            Environment.Exit(0);
        }
    }
}