using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day5
{
    internal class DayFive
    {
        private readonly DayFiveInput input;

        public DayFive(DayFiveInput input)
        {
            this.input = input;
        }

        public int Answer()
        {
            var distinctCoverage = this.input.DistinctCoverage();
            var allCoverage = this.input.AllCoverage();
            var total = allCoverage.Count;
            var index = 0;
            //foreach (var item in allCoverage)
            Parallel.ForEach(allCoverage, new ParallelOptions { MaxDegreeOfParallelism = 8 },item =>
            {
                Console.WriteLine($"{++index}/{total}");
                var distinctItem = distinctCoverage.First(d => d.CoordId == item.CoordId);
                distinctItem.Increment(1);
            });
            //}

            return distinctCoverage.Count(d => d.Counter > 1);
        }
    }
}
