using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day9
{
    internal class DayNine
    {
        private readonly int[][] input;

        public DayNine(int[][] input)
        {
            this.input = input;
        }

        public int Answer()
        {
            var rows = input.Length;
            var cols = input[0].Length;
            var lowPoints = new List<int>();
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    var currentVal = input[row][col];

                    var adjacentPositions = new (int row, int col)[] { (row + 1, col), (row, col + 1), (row - 1, col), (row, col - 1) };
                    var isLowest = true;
                    foreach (var adjacent in adjacentPositions)
                    {
                        if (adjacent.row < 0 || adjacent.row >= rows || adjacent.col < 0 || adjacent.col >= cols) continue;

                        if (currentVal >= input[adjacent.row][adjacent.col])
                        {
                            isLowest = false;
                            break;
                        }
                    }

                    if (isLowest)
                    {
                        lowPoints.Add(currentVal);
                    }
                }
            }
            return lowPoints.Select(lp => lp + 1).Sum();
        }
    }
}
