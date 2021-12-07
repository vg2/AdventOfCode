using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day6
{
    internal static class DaySixInputReader
    {
        public static DaySixInput ReadInput(string filePath)
        {
            var inputLine = File.ReadAllText(filePath);
            var fish = inputLine.Split(',').Select(i => new LanternFish(int.Parse(i))).ToList();

            return new DaySixInput(fish);
        }

    }
}
