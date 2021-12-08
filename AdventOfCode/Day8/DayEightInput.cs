using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day8
{
    internal class DayEightInput
    {
        public IEnumerable<string> Signals { get; }
        public IEnumerable<string> Outputs { get; }

        public DayEightInput(IEnumerable<string> signals, IEnumerable<string> outputs)
        {
            Signals = signals;
            Outputs = outputs;
        }
    }
}
