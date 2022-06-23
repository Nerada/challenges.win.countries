// -----------------------------------------------
//     Author: Ramon Bollen
//      File: Countries.CalculationSummary.cs
// Created on: 20220218
// -----------------------------------------------

using System.Collections.Immutable;

namespace Countries.Support;

public record CalculationSummary(ImmutableArray<(int CountryCode, int AmountOfRegions)> Results);