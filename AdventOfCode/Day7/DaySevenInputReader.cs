using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day7
{
    internal static class DaySevenInputReader
    {
        internal static int[] ReadInput(string filePath)
        {
            return File.ReadAllText(filePath).Split(',').Select(i => int.Parse(i)).ToArray();
        }
    }
}
