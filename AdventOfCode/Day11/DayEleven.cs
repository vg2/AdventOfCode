using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day11
{
    internal class DayEleven
    {
        private readonly Octopus[][] input;

        public DayEleven(Octopus[][] input)
        {
            this.input = input;
        }

        public long Answer()
        {
            long steps = long.MaxValue;
            var rows = this.input.Length;
            var cols = this.input[0].Length;
            long flashCount = 0;
            long flashStep = -1;

            for (long step = 0; step < steps; step++)
            {
                // increase energy
                for (var row = 0; row < rows; row++)
                {
                    for (var col = 0; col < cols; col++)
                    {
                        this.input[row][col].Increment();
                    }
                }

                // flash and increment neighbours
                while (this.input.Any(i => i.Any(o => o.ShouldFlash())))
                {
                    List<(int row, int col)> flashes = new List<(int row,int col)>();

                    for (var row = 0; row < rows; row++)
                    {
                        for (var col = 0; col < cols; col++)
                        {
                            if (this.input[row][col].ShouldFlash())
                            {
                                this.input[row][col].Flash();
                                flashes.Add((row, col));
                                flashCount++;
                            }
                        }
                    }

                    foreach (var pos in flashes)
                    {
                        List<(int, int)> alreadyIncremented = new List<(int, int)>();
                        // top left
                        var topLeft = (pos.row - 1, pos.col - 1);
                        if (topLeft.Item1 < rows && topLeft.Item2 < cols && topLeft.Item1 >= 0 && topLeft.Item2 >= 0 && !alreadyIncremented.Contains(topLeft))
                        {
                            this.input[topLeft.Item1][topLeft.Item2].Increment();
                            //alreadyIncremented.Add(topLeft);
                        }

                        // top
                        var top = (pos.row - 1, pos.col);
                        if (top.Item1 < rows && top.Item2 < cols && top.Item1 >= 0 && top.Item2 >= 0 && !alreadyIncremented.Contains(top))
                        {
                            this.input[top.Item1][top.Item2].Increment();
                            //alreadyIncremented.Add(top);
                        }

                        // top right
                        var topRight = (pos.row - 1, pos.col + 1);
                        if (topRight.Item1 < rows && topRight.Item2 < cols && topRight.Item1 >= 0 && topRight.Item2 >= 0 && !alreadyIncremented.Contains(topRight))
                        {
                            this.input[topRight.Item1][topRight.Item2].Increment();
                            //alreadyIncremented.Add(topRight);
                        }

                        // left
                        var left = (pos.row, pos.col - 1);
                        if (left.Item1 < rows && left.Item2 < cols && left.Item1 >= 0 && left.Item2 >= 0 && !alreadyIncremented.Contains(left))
                        {
                            this.input[left.Item1][left.Item2].Increment();
                            //alreadyIncremented.Add(left);
                        }

                        // right
                        var right = (pos.row, pos.col + 1);
                        if (right.Item1 < rows && right.Item2 < cols && right.Item1 >= 0 && right.Item2 >= 0 && !alreadyIncremented.Contains(right))
                        {
                            this.input[right.Item1][right.Item2].Increment();
                            //alreadyIncremented.Add(right);
                        }

                        // bottom left
                        var bottomLeft = (pos.row + 1, pos.col - 1);
                        if (bottomLeft.Item1 < rows && bottomLeft.Item2 < cols && bottomLeft.Item1 >= 0 && bottomLeft.Item2 >= 0 && !alreadyIncremented.Contains(bottomLeft))
                        {
                            this.input[bottomLeft.Item1][bottomLeft.Item2].Increment();
                            //alreadyIncremented.Add(bottomLeft);
                        }

                        // bottom 
                        var bottom = (pos.row + 1, pos.col);
                        if (bottom.Item1 < rows && bottom.Item2 < cols && bottom.Item1 >= 0 && bottom.Item2 >= 0 && !alreadyIncremented.Contains(bottom))
                        {
                            this.input[bottom.Item1][bottom.Item2].Increment();
                            //alreadyIncremented.Add(bottom);
                        }

                        // bottom right
                        var bottomRight = (pos.row + 1, pos.col + 1);
                        if (bottomRight.Item1 < rows && bottomRight.Item2 < cols && bottomRight.Item1 >= 0 && bottomRight.Item2 >= 0 && !alreadyIncremented.Contains(bottomRight))
                        {
                            this.input[bottomRight.Item1][bottomRight.Item2].Increment();
                            //alreadyIncremented.Add(bottomRight);
                        }
                    }
                }

                if (this.input.All(i => i.All(o =>o.Flashed)))
                {
                    flashStep = step + 1;
                    break;
                }

                // reset flashed octopi
                foreach (var octopi in this.input)
                {
                    foreach (var octopus in octopi.Where(o => o.Flashed))
                    {
                        octopus.Reset();
                    }
                }
            }


            return flashStep;
        }
    }
}
