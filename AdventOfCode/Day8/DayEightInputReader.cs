using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day8
{
    internal static class DayEightInputReader
    {
        public static IEnumerable<DayEightInput> ReadInput(string filePath)
        {
            return File.ReadAllLines(filePath).Select(line =>
            {
                var splitLine = line.Split(" | ");
                return new DayEightInput(
                    splitLine.First().Split(" "),
                    splitLine.Last().Split(" "));
            }
            );
        }
    }
}
