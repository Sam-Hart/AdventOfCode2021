using System;
using System.IO;
using System.Reflection;

using AdventOfCode2021.Day1;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Benchmarks.Day1
{
    public class Inputs
    {
        private Stream input;
        public Inputs()
        {
            var assembly = typeof(Inputs).GetTypeInfo().Assembly;
            foreach (var s in assembly.GetManifestResourceNames())
            {
                Console.WriteLine(s);

            }
            var testInput = assembly.GetManifestResourceStream(
                "Benchmarks.Inputs.ChallengeInput.txt"
            );
            input = testInput;
        }

        [Benchmark]
        public int Part1() => Problem.Part1(input);

        [Benchmark]
        public int Part2() => Problem.Part2(input);
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}
