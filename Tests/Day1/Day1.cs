using System.Reflection;

using AdventOfCode2021.Day1;
using Xunit;

namespace Tests.Day1
{
    public class Inputs
    {
        [Fact]
        public void Part1TestInput()
        {
            var assembly = typeof(Inputs).GetTypeInfo().Assembly;
            var testInput = assembly.GetManifestResourceStream(
                "Tests.Day1.Inputs.TestInput.txt"
            );
            Assert.Equal(7, Problem.Part1(testInput));
        }

        [Fact]
        public void Part1ChallengeInput()
        {
            var assembly = typeof(Inputs).GetTypeInfo().Assembly;
            var challengeInput = assembly.GetManifestResourceStream(
                "Tests.Day1.Inputs.ChallengeInput.txt"
            );
            Assert.Equal(1298, Problem.Part1(challengeInput));
        }

        [Fact]
        public void Part2TestInput()
        {
            var assembly = typeof(Inputs).GetTypeInfo().Assembly;
            var testInput = assembly.GetManifestResourceStream(
                "Tests.Day1.Inputs.TestInput.txt"
            );
            Assert.Equal(5, Problem.Part2(testInput));
        }

        [Fact]
        public void Part2ChallengeInput()
        {
            var assembly = typeof(Inputs).GetTypeInfo().Assembly;
            var testInput = assembly.GetManifestResourceStream(
                "Tests.Day1.Inputs.ChallengeInput.txt"
            );
            Assert.Equal(1248, Problem.Part2(testInput));
        }
    }
}
