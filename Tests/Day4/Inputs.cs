using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using AdventOfCode2021.Day4;
using Xunit;

namespace Tests.Day4
{
    public class Inputs
    {
        [Fact]
        public void WinningWithRows()
        {
            var assembly = typeof(Inputs).GetTypeInfo().Assembly;
            var testInput = assembly.GetManifestResourceStream(
                "Tests.Day4.Inputs.TestInput1.txt"
            );
            var (calls, boards) = Problem.ParseInput(testInput);
            var (winningBoard, winningCall) =
                Problem.FindFirstWinningBoard(calls, boards.ToList());
            var winningRow = new HashSet<int> { 0, 10, 5, 15, 20 };
            Assert.True(winningRow.SetEquals(winningBoard.MarkedIndices));
        }

        [Fact]
        public void WinningWithColumns()
        {
            var assembly = typeof(Inputs).GetTypeInfo().Assembly;
            var testInput = assembly.GetManifestResourceStream(
                "Tests.Day4.Inputs.TestInput2.txt"
            );
            var (calls, boards) = Problem.ParseInput(testInput);
            var (winningBoard, winningCall) =
                Problem.FindFirstWinningBoard(calls, boards);
            var markedRow = new HashSet<int> { 20, 21, 22, 23, 16, 17, 18, 24 };
            Assert.True(markedRow.SetEquals(winningBoard.MarkedIndices));
        }

        [Fact]
        public void Part1TestInput()
        {
            var assembly = typeof(Inputs).GetTypeInfo().Assembly;
            var testInput = assembly.GetManifestResourceStream(
                "Tests.Day4.Inputs.TestInput.txt"
            );
            Assert.Equal(4512, Problem.Part1(testInput));
        }

        [Fact]
        public void Part1ChallengeInput()
        {
            var assembly = typeof(Inputs).GetTypeInfo().Assembly;
            var ChallengeInput = assembly.GetManifestResourceStream(
                "Tests.Day4.Inputs.ChallengeInput.txt"
            );
            Assert.Equal(72770, Problem.Part1(ChallengeInput));
        }

        [Fact]
        public void Part2TestInput()
        {
            var assembly = typeof(Inputs).GetTypeInfo().Assembly;
            var testInput = assembly.GetManifestResourceStream(
                "Tests.Day4.Inputs.TestInput.txt"
            );
            Assert.Equal(1924, Problem.Part2(testInput));
        }

        [Fact]
        public void Part2ChallengeInput()
        {
            var assembly = typeof(Inputs).GetTypeInfo().Assembly;
            var ChallengeInput = assembly.GetManifestResourceStream(
                "Tests.Day4.Inputs.ChallengeInput.txt"
            );
            Assert.Equal(13912, Problem.Part2(ChallengeInput));
        }
    }
}
