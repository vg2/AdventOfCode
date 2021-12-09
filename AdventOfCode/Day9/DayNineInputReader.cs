using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day9
{
    internal static class DayNineInputReader
    {
        public static int[][] ReadInput(string filePath)
        {
            var inputLines = File.ReadAllLines(filePath);
            return inputLines.Select(i => i.Select(x => int.Parse(x.ToString())).ToArray()).ToArray();
        }
    }
}
