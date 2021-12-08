using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day8
{
    internal class DayEight
    {
        private readonly IEnumerable<DayEightInput> input;
        private readonly IReadOnlyCollection<int> uniqueSignalLengths = new List<int> { 2, 4, 3, 7 }.AsReadOnly();

        public DayEight(IEnumerable<DayEightInput> input)
        {
            this.input = input;
        }

        public int Answer()
        {
            var counter = 0;
            foreach (var line in input)
            {
                counter += line.Outputs.Count(o => uniqueSignalLengths.Contains(o.Length));
            }

            return counter;
        }
    }
}
