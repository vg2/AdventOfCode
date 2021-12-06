using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day5
{
    internal static class DayFiveInputReader
    {
        internal static DayFiveInput ReadInput(string filePath)
        {
            var fileLines = File.ReadAllLines(filePath);
            var lines = new List<Line>();

            foreach (var line in fileLines)
            {
                var coords = line.Split(" -> ");
                var fromCollection = coords.First().Split(',').Select(c => int.Parse(c));
                var from = new Coordinate(fromCollection.First(), fromCollection.Last());

                var toCollection = coords.Last().Split(',').Select(c => int.Parse(c));
                var to = new Coordinate(toCollection.First(), toCollection.Last());

                lines.Add(new Line(from, to));
            }

            return new DayFiveInput(lines);
        }
    }
}
