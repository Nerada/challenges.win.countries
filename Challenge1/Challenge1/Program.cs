// -----------------------------------------------
//     Author: Ramon Bollen
//       File: Challenge1.Program.cs
// Created on: 20200210
// -----------------------------------------------

using System;

namespace Challenge1
{
    internal static class Program
    {
        private static void Main()
        {
            var run = new Runnable();

            Console.WriteLine($"{Environment.NewLine}Total amount of regions: {run.Solution(TestData.Get())}");
            Console.ReadKey();

            Environment.Exit(0);
        }
    }
}