using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day3
{
    internal static class DayThreeInputReader
    {
        internal static int[][] ReadInput(string inputPath)
        {
            var fileLines = System.IO.File.ReadAllLines(inputPath);

            var input = fileLines.Select(f => f.ToCharArray().Select(s => int.Parse(s.ToString())).ToArray()).ToArray();

            return input;
        }

    }
}
