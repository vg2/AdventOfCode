using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day1
{
    internal static class DayOneInputReader
    {
        public static int[] ReadInput(string inputPath)
        {
            var fileLines = System.IO.File.ReadAllLines(inputPath);

            var input = fileLines.Select(f => int.Parse(f)).ToArray();

            return input;
        }
    }
}
