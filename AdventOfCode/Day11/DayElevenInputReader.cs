using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day11
{
    internal static class DayElevenInputReader
    {
        public static Octopus[][] ReadInput(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var rows = lines.Length;
            var cols = lines[0].Length;
            var octopi = new Octopus[rows][];

            for(var row = 0; row < rows; row++)
            {
                var line = lines[row];
                octopi[row] = new Octopus[cols];
                for (var col = 0; col < cols; col++)
                {
                    octopi[row][col] = new Octopus(int.Parse(line.Substring(col, 1)));
                }
            }

            return octopi;
        }
    }
}
