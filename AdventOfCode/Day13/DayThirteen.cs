using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day13
{
    internal class DayThirteen
    {
        private readonly Input input;

        public DayThirteen(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var line = lines.First();
            var index = 0;
            var input = new Input();
            while (!string.IsNullOrEmpty(line))
            {
                index++;
                var splitLine = line.Split(',');
                var coords = (int.Parse(splitLine[1]), int.Parse(splitLine[0]));
                input.DotPositions.Add(coords);
                line = lines[index];
            }

            for (var row = index + 1; row < lines.Count(); row++)
            {
                var foldInstruction = lines[row].Split("fold along").Last();
                var splitInstruction = foldInstruction.Split("=");
                var instruction = (Enum.Parse<FoldDim>(splitInstruction[0].ToUpper()), int.Parse(splitInstruction[1]));
                input.FoldInstructions.Add(instruction);
            }

            this.input = input;
        }

        public long Answer()
        {
            var dotPositions = input.DotPositions;

            foreach (var foldInstr in input.FoldInstructions)
            {
                if (foldInstr.dim == FoldDim.Y)
                {
                    FoldUp(dotPositions, foldInstr.coord);
                }
                else
                {
                    FoldLeft(dotPositions, foldInstr.coord);
                }
            }

            var uniquePositions = dotPositions.Distinct().ToList();
            var maxRow = uniquePositions.Max(p => p.row);
            var maxCol = uniquePositions.Max(p => p.col);
            for (var i = 0; i <= maxRow; i++)
            {
                for (var j = 0; j <= maxCol; j++)
                {
                    if(uniquePositions.Contains((i,j)))
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
            return uniquePositions.Count;
        }

        public void FoldUp(List<(int row, int col)> dotPositions, int y)
        {
            var count = dotPositions.Count;
            var toRemove = new List<(int row, int col)>();
            var toAdd = new List<(int row, int col)>();
            for (var i = 0; i < count; i++)
            {
                if (dotPositions[i].row > y)
                {
                    var newPosition = ((y * 2) - dotPositions[i].row, dotPositions[i].col);
                    toRemove.Add(dotPositions[i]);
                    toAdd.Add(newPosition);
                }
            }
            dotPositions.RemoveAll(x => toRemove.Contains(x));
            dotPositions.AddRange(toAdd);
        }

        public void FoldLeft(List<(int row, int col)> dotPositions, int x)
        {
            var count = dotPositions.Count;
            var toRemove = new List<(int row, int col)>();
            var toAdd = new List<(int row, int col)>();
            for (var i = 0; i < count; i++)
            {
                if (dotPositions[i].col > x)
                {
                    var newPosition = (dotPositions[i].row, (x * 2) - dotPositions[i].col);
                    toRemove.Add(dotPositions[i]);
                    toAdd.Add(newPosition);
                }
            }

            dotPositions.RemoveAll(x => toRemove.Contains(x));
            dotPositions.AddRange(toAdd);
        }

    }

    internal enum FoldDim
    {
        X = 0,
        Y = 1
    }

    internal class Input
    {
        public List<(int row, int col)> DotPositions { get; }

        public List<(FoldDim dim, int coord)> FoldInstructions { get; }

        public Input()
        {
            DotPositions = new List<(int row, int col)>();
            FoldInstructions = new List<(FoldDim dim, int coord)>();
        }
    }
}
