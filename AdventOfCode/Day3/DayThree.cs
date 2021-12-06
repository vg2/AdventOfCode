using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day3
{
    internal class DayThree
    {
        private readonly int[][] _input;

        public DayThree(int[][] input)
        {
            _input = input;
        }

        public int Answer()
        {
            var gamma = string.Empty;
            var epsilon = string.Empty;
            var column = 0;
            var total = _input.Length;
            var oneCounter = 0;
            var oxygen = string.Empty;
            var oxygenDone = false;
            var oxygenSearch = new List<int[]>(_input);
            var co2 = string.Empty;
            var co2Done = false;
            var co2Search = new List<int[]>(_input);

            for (var col = 0; col < _input[0].Length; col++)
            {
                if (!oxygenDone)
                {

                    total = oxygenSearch.Count;
                    foreach (var oxygenEntry in oxygenSearch)
                    {
                        if (oxygenEntry[col] == 1)
                        {
                            oneCounter++;
                        }
                    }
                    var zeroCount = total - oneCounter;
                    if (oneCounter >= zeroCount)
                    {
                        oxygenSearch = oxygenSearch.Where(i => i[col] == 1).ToList();
                    }
                    else
                    {
                        oxygenSearch = oxygenSearch.Where(i => i[col] == 0).ToList();
                    }

                    if (oxygenSearch.Count == 1)
                    {
                        oxygen = string.Concat(oxygenSearch.First().Select(o => o.ToString()));
                        oxygenDone = true;
                    }
                }

                oneCounter = 0;

                if (!co2Done)
                {
                    total = co2Search.Count;
                    foreach (var co2Entry in co2Search)
                    {
                        if (co2Entry[col] == 1)
                        {
                            oneCounter++;
                        }
                    }
                    var zeroCount = total - oneCounter;
                    if (oneCounter < zeroCount)
                    {
                        co2Search = co2Search.Where(i => i[col] == 1).ToList();
                    }
                    else
                    {
                        co2Search = co2Search.Where(i => i[col] == 0).ToList();
                    }
                    if (co2Search.Count == 1)
                    {
                        co2 = string.Concat(co2Search.First().Select(o => o.ToString()));
                        co2Done = true;
                    }
                }
                oneCounter = 0;

                if (oxygenDone && co2Done)
                {
                    break;
                }
            }

            var oxyVal = Convert.ToInt32(oxygen, 2);
            var co2Val = Convert.ToInt32(co2, 2);



            return oxyVal * co2Val;
        }
    }
}
