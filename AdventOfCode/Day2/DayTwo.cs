using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day2
{
    internal class DayTwo
    {
        private readonly IEnumerable<DayTwoInput> input;

        public DayTwo(IEnumerable<DayTwoInput> input)
        {
            this.input = input;
        }

        public int Answer()
        {
            var horizontalPos = 0;
            var depth = 0;
            var aim = 0;

            foreach (var line in this.input)
            {
                switch (line.Command)
                {
                    case Command.forward: 
                        horizontalPos += line.Units;
                        depth += aim * line.Units;
                        break;
                    case Command.up:
                        aim -= line.Units;
                        break;
                    case Command.down: 
                        aim += line.Units; 
                        break;
                    default: break;
                }
            }

            return depth * horizontalPos;
        }

    }
}
