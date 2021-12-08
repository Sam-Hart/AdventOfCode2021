using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.Day4
{
    public class Problem
    {
        public static int Part1(Stream input)
        {
            var (calls, bingoBoards) = ParseInput(input);
            var boards = bingoBoards.ToList();
            var (winningBoard, winningCall) =
                FindFirstWinningBoard(calls, boards);
            if (winningBoard is null)
            {
                return 0;
            }
            var score = Enumerable
                .Range(0, 25)
                .Aggregate(
                    0,
                    (int sum, int x) =>
                    {
                        if (!(winningBoard.IsMarked(x)))
                        {
                            return sum + winningBoard.Board[x];
                        }
                        return sum;
                    }
                );
            return score * winningCall;
        }

        public static int Part2(Stream input)
        {
            var (calls, bingoBoards) = ParseInput(input);
            var boards = bingoBoards.ToList();
            var (lastWinningBoard, lastWinningCall) =
                FindLastWinningBoard(calls, boards);

            if (lastWinningBoard is null)
            {
                return 0;
            }

            var score = Enumerable
                .Range(0, 25)
                .Aggregate(
                    0,
                    (int sum, int x) =>
                    {
                        if (!(lastWinningBoard.IsMarked(x)))
                        {
                            return sum + lastWinningBoard.Board[x];
                        }
                        return sum;
                    }
                );
            return score * lastWinningCall;
        }

        public static (BingoBoard?, int) FindFirstWinningBoard(
            IEnumerable<int> calls,
            IEnumerable<BingoBoard> bingoBoards
        )
        {
            var l = bingoBoards.ToList();
            foreach (var call in calls)
            {
                foreach (var board in l)
                {
                    if (board.MarkCall(call))
                    {
                        return (board, call);
                    }
                }
            }
            return (null, -1);
        }

        public static (BingoBoard?, int) FindLastWinningBoard(
            IEnumerable<int> calls,
            IEnumerable<BingoBoard> bingoBoards
        )
        {
            var l = bingoBoards.ToList();
            var winningBoards = new List<(BingoBoard, int)>();
            foreach (var call in calls)
            {
                foreach (var board in l)
                {
                    if (winningBoards.Any(
                        x => Object.ReferenceEquals(x.Item1, board)
                    ))
                    {
                        continue;
                    }
                    if (board.MarkCall(call))
                    {
                        winningBoards.Add((board, call));
                    }
                }
            }

            if (winningBoards.Count() == 0)
            {
                return (null, -1);
            }
            return winningBoards.Last();
        }

        public static (IEnumerable<int>, IEnumerable<BingoBoard>) ParseInput(
            Stream input
        )
        {
            var bingoGame = new StreamReader(input)
                .ReadToEnd()
                .Trim()
                .Split('\n');

            var calls = bingoGame[0]
                .Split(',')
                .Select(x => Convert.ToInt32(x));

            var bingoBoards = bingoGame[1..bingoGame.Count()]
                .Where(x => !string.IsNullOrEmpty(x))
                .Chunk(5)
                .Select(x => new BingoBoard(x));

            return (calls, bingoBoards);
        }
    }

    public class BingoBoard
    {
        public List<int> Board = new List<int>();
        public HashSet<int> MarkedIndices = new HashSet<int>();
        IDictionary<int, int> BoardIndexMap = new Dictionary<int, int>();

        public BingoBoard(string[] inputBoard)
        {
            var board = inputBoard
                .SelectMany(x => x
                    .Split(' ')
                    .Where(x => !string.IsNullOrEmpty(x))
                    .Select(x => Convert.ToInt32(x))
                );

            foreach (var row in board.Select((value, i) => (value, i)))
            {
                Board.Add(row.value);
                BoardIndexMap[row.value] = row.i;
            }
        }

        public bool IsMarked(int index)
        {
            return MarkedIndices.Contains(index);
        }

        public bool MarkCall(int call)
        {
            if (!BoardIndexMap.ContainsKey(call))
            {
                return false;
            }
            MarkedIndices.Add(BoardIndexMap[call]);
            return ColumnsWin() || RowsWin();

        }

        public bool HasWon()
        {
            return false;
        }

        private bool ColumnsWin()
        {
            foreach (var index in MarkedIndices)
            {
                var y = index / 5;
                var x = ((index + 1) % 5) + (y * 5);
                if (!MarkedIndices.Contains(x))
                {
                    goto IndexIteration;
                }
                var i = ((x + 1) % 5) + (y * 5);
                for (; i != x; i = ((i + 1) % 5) + (y * 5))
                {
                    if (!MarkedIndices.Contains(i))
                    {
                        goto IndexIteration;
                    }
                }
                if (i == x)
                {
                    return true;
                }
            IndexIteration:
                ;
            }

            return false;
        }

        private bool RowsWin()
        {
            foreach (var index in MarkedIndices)
            {
                if (!MarkedIndices.Contains(index))
                {
                    return false;
                }
                var i = (index + 5) % 25;
                for (; i != index; i = (i + 5) % 25)
                {
                    if (!MarkedIndices.Contains(i))
                    {
                        goto IndexIteration;
                    }
                }
                if (i == index)
                {
                    return true;
                }
            IndexIteration:
                ;
            }
            return false;
        }
    }
}
