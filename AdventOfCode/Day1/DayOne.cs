using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day1
{
    internal class DayOne
    {
        private readonly int[] _input;

        public DayOne(int[] input)
        {
            _input = input;
        }

        public int Answer()
        {
            var slidingSums = new List<int>();


            for (var i = 0; i < _input.Length; i++)
            {
                var slidingSum = 0;
                for (var j = i; j < i+3 && j < _input.Length; j++)
                {
                    slidingSum += _input[j];
                };
                slidingSums.Add(slidingSum);
            }

            int counter = 0;
            for (var i = 1; i < slidingSums.Count; i++)
            {
                if (slidingSums[i] > slidingSums[i - 1])
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
