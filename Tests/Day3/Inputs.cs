using System.Reflection;

using AdventOfCode2021.Day3;
using Xunit;

namespace Tests.Day3
{
    public class Inputs
    {
        [Fact]
        public void Part1TestInput()
        {
            var assembly = typeof(Inputs).GetTypeInfo().Assembly;
            var testInput = assembly.GetManifestResourceStream(
                "Tests.Day3.Inputs.TestInput.txt"
            );
            Assert.Equal(198, Problem.Part1(testInput));
        }

        [Fact]
        public void Part1ChallengeInput()
        {
            var assembly = typeof(Inputs).GetTypeInfo().Assembly;
            var challengeInput = assembly.GetManifestResourceStream(
                "Tests.Day3.Inputs.ChallengeInput.txt"
            );
            Assert.Equal(2583164, Problem.Part1(challengeInput));
        }

        [Fact]
        public void Part2TestInput()
        {
            var assembly = typeof(Inputs).GetTypeInfo().Assembly;
            var testInput = assembly.GetManifestResourceStream(
                "Tests.Day3.Inputs.TestInput.txt"
            );
            Assert.Equal(230, Problem.Part2(testInput));
        }

        [Fact]
        public void Part2ChallengeInput()
        {
            var assembly = typeof(Inputs).GetTypeInfo().Assembly;
            var challengeInput = assembly.GetManifestResourceStream(
                "Tests.Day3.Inputs.ChallengeInput.txt"
            );
            Assert.Equal(2784375, Problem.Part2(challengeInput));
        }
    }
}
