using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day4
{
    internal static class DayFourInputReader
    {
        public static DayFourInput ReadInput(string filePath)
        {
            var fileLines = File.ReadAllLines(filePath);
            var drawnNumbers = fileLines.First().Split(',').Select(i => int.Parse(i)).ToArray();
            var boards = new List<(int, bool)[,]>();
            var boardDim = 5;

            var currentBoard = new (int, bool)[boardDim, boardDim];
            var currentLine = 0;
            foreach (var line in fileLines.Skip(2))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    boards.Add(currentBoard);
                    currentBoard = new (int, bool)[boardDim, boardDim];
                    currentLine = 0;
                }
                else
                {
                    var lineNumbers = new List<string>();
                    for (int i = 0; i < line.Length; i += 3)
                    {
                        lineNumbers.Add(line.Substring(i, Math.Min(3, line.Length - i)));
                    }
                    var boardLine = lineNumbers.Select(l => (int.Parse(l.Trim()), false)).ToArray();
                    for (var j = 0; j < boardLine.Length; j++)
                    {
                        currentBoard[currentLine,j] = boardLine[j];
                    }
                    currentLine++;
                }

            }

            return new DayFourInput(drawnNumbers, boards, boardDim);

        }

    }
}

