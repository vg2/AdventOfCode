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
        private int rows => input.Length;
        private int cols => input[0].Length;

        public DayNine(int[][] input)
        {
            this.input = input;
        }

        public int Answer()
        {
            var lowPoints = new List<(int, int)>();

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
                        lowPoints.Add((row, col));
                    }
                }
            }
            var basinSizes = new List<int>();

            foreach (var lowPoint in lowPoints)
            {
                basinSizes.Add(GetBasinSize(new List<(int row, int col)> { lowPoint }));
            }

            return basinSizes.OrderByDescending(b => b).Take(3).Aggregate((a, b) => a * b);
        }

        private int GetBasinSize(List<(int row, int col)> lowPoints)
        {
            var countedPositions = lowPoints;
            var currentCount = lowPoints.Count;
            var surroundingPositions = lowPoints.SelectMany(lp => GetSurroundingBasinPositions(lp)).ToList();
            countedPositions.AddRange(surroundingPositions);
            countedPositions = countedPositions.Distinct().ToList(); ;
            if(currentCount == countedPositions.Count) {
                return currentCount;
            }
            else
            {
                return GetBasinSize(countedPositions);
            }
        }
        

        private IEnumerable<(int row, int col)> GetSurroundingBasinPositions((int row, int col) pos)
        {
            var adjacentPositions = new (int row, int col)[] { (pos.row + 1, pos.col), (pos.row, pos.col + 1), (pos.row - 1, pos.col), (pos.row, pos.col - 1) };
            foreach (var adjacent in adjacentPositions)
            {
                if (adjacent.row < 0 || adjacent.row >= rows || adjacent.col < 0 || adjacent.col >= cols) continue;

                if (input[adjacent.row][adjacent.col] < 9)
                {
                    yield return (adjacent.row, adjacent.col);
                }
            }
        }
    }
}
