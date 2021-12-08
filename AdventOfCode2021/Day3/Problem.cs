using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.Day3
{

    public enum RatingType
    {
        Oxygen,
        CO2
    }

    public class Problem
    {
        public static int Part1(Stream input)
        {
            var report = parseReport(input);
            var onesColumns = GatherOnesCounts(report);
            onesColumns.Reverse();
            var gammaRate = 0;
            var epsilonRate = 0;
            var halfNumbers = report.Count() / 2;
            for (var i = 0; i < onesColumns.Count(); i++)
            {
                var count = onesColumns[i];
                var bit = count >= halfNumbers ? 1 : 0;
                gammaRate += bit << i;
                epsilonRate += bit == 1 ? 0 : 1 << i;
            }

            return gammaRate * epsilonRate;
        }

        public static int Part2(Stream input)
        {
            var report = parseReport(input);
            var max = report.Max();
            var maxBits = CountBits(max);
            var oxygenGeneratorRating = FindRating(report, RatingType.Oxygen);
            var co2ScrubberRating = FindRating(report, RatingType.CO2);
            return oxygenGeneratorRating * co2ScrubberRating;
        }

        public static int FindRating(IEnumerable<int> report, RatingType type)
        {
            var candidates = report;
            for (
                int i = 0, j = 0, maxBits = CountBits(report.Max());
                candidates.Count() > 1 && j < 20;
                j++, i = (i + 1) % maxBits
            )
            {
                var halfNumbers = candidates.Count() / 2.0;
                var onesColumns = GatherOnesCounts(candidates);
                var onesColumnsIndex = maxBits - i - 1;
                var count = onesColumns.GetValueOrDefault(onesColumnsIndex);
                var searchBit = type switch
                {
                    RatingType.Oxygen => count >= halfNumbers ? 1 : 0,
                    RatingType.CO2 => count >= halfNumbers ? 0 : 1,
                    _ => throw new Exception("Unknown Rating Type")
                };
                var mask = 1 << onesColumnsIndex;
                candidates = candidates
                    .Where(x => (x & mask) == (searchBit == 1 ? mask : 0));
            }

            return candidates.ElementAt(0);
        }

        public static Dictionary<int, int> GatherOnesCounts(
            IEnumerable<int> report
        )
        {
            var onesColumns = new Dictionary<int, int>();
            foreach (var number in report)
            {
                for (int i = 0; 1 << i <= number; i++)
                {
                    var test = 1 << i;
                    var bit = number & test;
                    onesColumns[i] = onesColumns.GetValueOrDefault(i)
                        + Math.Clamp(bit, 0, 1);
                }
            }
            return onesColumns;
        }

        private static int CountBits(int n)
        {
            int count = 0;
            while (n > 0)
            {
                count++;
                n >>= 1;
            }
            return count;
        }

        private static IEnumerable<int> parseReport(Stream input)
        {
            return new StreamReader(input)
                .ReadToEnd()
                .Trim()
                .Split('\n')
                .Select(x => Convert.ToInt32(x, 2));
        }
    }
}
