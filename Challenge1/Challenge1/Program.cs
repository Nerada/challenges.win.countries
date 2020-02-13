//-----------------------------------------------
//      Autor: Ramon Bollen	
//       File: Challenge1.Program.cs
// Created on: 202028
//-----------------------------------------------

using System;

namespace Challenge1
{
    internal static class Program
    {
        private static void Main()
        {
            var run = new Runnable();

            Console.WriteLine($"{Environment.NewLine}Total amount of regions: {run.Solution(run.CreateData())}");
            Console.ReadKey();

            Environment.Exit(0);
        }
    }
}
