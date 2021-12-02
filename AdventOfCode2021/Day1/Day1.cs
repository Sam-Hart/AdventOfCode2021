using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day1
{
    public class Problem
    {
        static public int Part1(Stream depthsInput)
        {
            var depths = parseInput(depthsInput);
            var depthIncreases = 0;
            for (var i = 1; i < depths.Count(); i++)
            {
                depthIncreases += depths.ElementAt(i - 1) < depths.ElementAt(i)
                    ? 1
                    : 0;
            }
            return depthIncreases;
        }

        static public int Part2(Stream depthsInput)
        {
            var depths = parseInput(depthsInput).ToArray();
            var windowSumIncreases = 0;
            for (var i = 0; i < depths.Count() - 3; i++)
            {
                var currentRange = i..(i + 3);
                var nextRange = (i + 1)..(i + 4);
                var nextWindow = depths[nextRange];
                var currentWindow = depths[currentRange];
                windowSumIncreases += nextWindow.Sum() > currentWindow.Sum()
                    ? 1
                    : 0;
            }
            return windowSumIncreases;
        }

        static IEnumerable<int> parseInput(Stream input)
        {
            var inputContents = new StreamReader(input).ReadToEnd();
            var depthInputs = inputContents
               .Trim()
               .Split('\n');
            return depthInputs
                .Aggregate(
                    new List<int>(),
                    (
                        List<int> depths,
                        string depthInput
                    ) =>
                    {
                        if (int.TryParse(depthInput, out var depth))
                        {
                            depths.Add(depth);
                        }
                        return depths;
                    }
                );
        }

    }
}
