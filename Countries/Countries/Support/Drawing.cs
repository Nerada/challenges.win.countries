// -----------------------------------------------
//     Author: Ramon Bollen
//      File: Countries.Drawing.cs
// Created on: 20220623
// -----------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Countries.tests")]

namespace Countries.Support;

internal class Drawing
{
    // TODO: Add more than 4 fill strings (maybe do something with ASCII values), and have a function with a guard for undefined country codes
    public static readonly ImmutableDictionary<int, string> CountryFlags = new Dictionary<int, string> {{1, "██"}, {2, "┼┼"}, {3, "··"}, {4, "[]"}}.ToImmutableDictionary();

    public void Draw(string layoutName, IReadOnlyList<int[]> data)
    {
        // 2 for empty space left and right
        int titleSize = layoutName.Length + 2;

        Console.WriteLine($"┌{new string('─', titleSize)}┐");
        Console.WriteLine($"│ {layoutName} │");
        Console.WriteLine($"├{new string('─', titleSize)}┴─{new string('─', data[0].Length * 2 - titleSize)}┐");
        DrawData(data);
    }

    private void DrawData(IReadOnlyList<int[]> data)
    {
        if (data.Count == 0) return;

        foreach (int[] y in data)
        {
            Console.Write("│ ");

            foreach (int x in y) { Console.Write($"{CountryFlags[x]}"); }

            Console.Write(" │");

            Console.WriteLine();
        }

        Console.WriteLine($"└─{new string('─', data[0].Length * 2)}─┘");
    }
}