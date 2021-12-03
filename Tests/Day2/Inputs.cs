using System.Reflection;

using AdventOfCode2021.Day2;
using Xunit;

namespace Tests.Day2
{
    public class Inputs
    {
        [Fact]
        public void Part1TestInput()
        {
            var assembly = typeof(Inputs).GetTypeInfo().Assembly;
            var testInput = assembly.GetManifestResourceStream(
                "Tests.Day2.Inputs.TestInput.txt"
            );
            Assert.Equal(150, Problem.Part1(testInput));
        }

        [Fact]
        public void Part1ChallengeInput()
        {
            var assembly = typeof(Inputs).GetTypeInfo().Assembly;
            var challengeInput = assembly.GetManifestResourceStream(
                "Tests.Day2.Inputs.ChallengeInput.txt"
            );
            Assert.Equal(1990000, Problem.Part1(challengeInput));
        }

        [Fact]
        public void Part2TestInput()
        {
            var assembly = typeof(Inputs).GetTypeInfo().Assembly;
            var testInput = assembly.GetManifestResourceStream(
                "Tests.Day2.Inputs.TestInput.txt"
            );
            Assert.Equal(900, Problem.Part2(testInput));
        }

        [Fact]
        public void Part2ChallengeInput()
        {
            var assembly = typeof(Inputs).GetTypeInfo().Assembly;
            var challengeInput = assembly.GetManifestResourceStream(
                "Tests.Day2.Inputs.ChallengeInput.txt"
            );
            Assert.Equal(1975421260, Problem.Part2(challengeInput));
        }
    }
}
