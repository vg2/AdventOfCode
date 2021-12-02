using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day2
{
    internal enum Command
    {
        forward = 0,
        down = 1,
        up = 2
    }

    internal class DayTwoInput
    {
        public Command Command { get; }
        public int Units { get; }

        public DayTwoInput(Command command, int units)
        {
            this.Command = command;
            this.Units = units;
        }
    }
}
