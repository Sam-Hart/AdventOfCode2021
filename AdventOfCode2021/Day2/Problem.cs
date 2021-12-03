using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.Day2
{
    enum Direction
    {
        Forward,
        Down,
        Up,
        Unknown
    }

    struct Position
    {
        public int x;
        public int y;

        public int aim;

        public Position(int pos_x, int pos_y)
        {
            x = pos_x;
            y = pos_y;
            aim = 0;
        }
    }

    struct Move
    {
        public Direction Direction;
        public int Velocity;

        public Move(Direction d, int v)
        {
            Direction = d;
            Velocity = v;
        }
    }

    public class Problem
    {
        static public int Part1(Stream input)
        {
            var instructions = parseInstructions(input);
            var submarinePosition = new Position(0, 0);

            foreach (var instruction in instructions)
            {
                var (x, y) = instruction.Direction switch
                {
                    Direction.Down => (
                        submarinePosition.x,
                        submarinePosition.y + instruction.Velocity
                    ),
                    Direction.Forward => (
                        submarinePosition.x + instruction.Velocity,
                        submarinePosition.y
                    ),
                    Direction.Up => (
                        submarinePosition.x,
                        Math.Max(0, submarinePosition.y - instruction.Velocity)
                    ),
                    _ => (
                        submarinePosition.x,
                        submarinePosition.y
                    )
                };

                submarinePosition.x = x;
                submarinePosition.y = y;
            }
            return submarinePosition.x * submarinePosition.y;
        }

        static public int Part2(Stream input)
        {
            var instructions = parseInstructions(input);
            var submarinePosition = new Position(0, 0);
            foreach (var instruction in instructions)
            {
                (
                    submarinePosition.x,
                    submarinePosition.y,
                    submarinePosition.aim
                ) = instruction.Direction switch
                {
                    Direction.Down => (
                        submarinePosition.x,
                        submarinePosition.y,
                        submarinePosition.aim + instruction.Velocity
                    ),
                    Direction.Forward => (
                        submarinePosition.x + instruction.Velocity,
                        Math.Max(
                            0,
                            submarinePosition.y
                                + (submarinePosition.aim * instruction.Velocity)
                            ),
                        submarinePosition.aim

                    ),
                    Direction.Up => (
                        submarinePosition.x,
                        submarinePosition.y,
                        submarinePosition.aim - instruction.Velocity
                    ),
                    _ => (
                        submarinePosition.x,
                        submarinePosition.y,
                        submarinePosition.aim
                    )
                };
            }
            return submarinePosition.x * submarinePosition.y;
        }

        static private IEnumerable<Move> parseInstructions(Stream input)
        {
            var inputContents = new StreamReader(input).ReadToEnd();


            return inputContents
                .Trim()
                .Split('\n')
                .Aggregate(
                    new List<Move>(),
                    (
                        List<Move> instructions,
                        string instruction
                    ) =>
                    {
                        var ins = instruction.Split(' ');
                        if (ins.Count() != 2)
                        {
                            return instructions;
                        }
                        var dir = ins[0] switch
                        {
                            "forward" => Direction.Forward,
                            "up" => Direction.Up,
                            "down" => Direction.Down,
                            _ => Direction.Unknown
                        };
                        if (dir == Direction.Unknown)
                        {
                            return instructions;
                        }
                        if (!int.TryParse(ins[1], out var vel))
                        {
                            return instructions;
                        }
                        instructions.Add(new Move(dir, vel));
                        return instructions;
                    }
                );
        }
    }
}
