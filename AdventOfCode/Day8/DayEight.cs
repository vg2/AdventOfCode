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
        private readonly IReadOnlyCollection<string> signals = new List<string> { "a", "b", "c", "d", "e", "f", "g" }.AsReadOnly();
        private readonly Dictionary<string, string> outputMapping = new Dictionary<string, string>
        {
            { "abcefg", "0" },
            { "cf", "1" },
            {"acdeg", "2" },
            { "acdfg", "3" },
            {"bcdf", "4" },
            {"abdfg", "5" },
            {"abdefg", "6" },
            {"acf", "7" },
            {"abcdefg", "8" },
            {"abcdfg", "9" },
        };

        public DayEight(IEnumerable<DayEightInput> input)
        {
            this.input = input;
        }

        public int Answer()
        {
            List<Dictionary<string, string>> mappings = new List<Dictionary<string, string>>();
            var output = 0;

            foreach (var line in input)
            {
                var mapping = new Dictionary<string, string>();
                mappings.Add(mapping);

                var signalForOne = line.Signals.Single(s => s.Length == 2);

                var mappingForCorF1 = signalForOne.First().ToString();
                var mappingForCorF2 = signalForOne.Last().ToString();

                mapping.Add(mappingForCorF1, "c");
                mapping.Add(mappingForCorF2, "f");

                var signalrForSeven = line.Signals.Single(s => s.Length == 3);
                var mappingForA = signalrForSeven.Where(s => !signalForOne.Contains(s)).First().ToString();
                mapping.Add(mappingForA, "a");

                var signalForFour = line.Signals.Single(s => s.Length == 4);
                var remaining = signalForFour.Where(s => !signalForOne.Contains(s));

                var mappingForBorD1 = remaining.First().ToString();
                var mappingForBorD2 = remaining.Last().ToString();

                var mappingForB = string.Empty;
                var mappingForD = string.Empty;
                var fiveLetterSignals = line.Signals.Where(l => l.Length == 5);

                if (fiveLetterSignals.Count(signal => signal.Any(s => s.ToString() == mappingForBorD1)) == 1)
                {
                    mappingForB = mappingForBorD1;
                    mappingForD = mappingForBorD2;
                }
                else
                {
                    mappingForB = mappingForBorD2;
                    mappingForD = mappingForBorD1;
                }

                if (fiveLetterSignals.Any(signal => signal.Contains(mappingForCorF1) && signal.Contains(mappingForB)))
                {
                    mapping[mappingForCorF1] = "f";
                    mapping[mappingForCorF2] = "c";
                }

                mapping.Add(mappingForB, "b");
                mapping.Add(mappingForD, "d");

                var currentMappedLetters = mapping.Select(m => m.Key);
                var signalrForNine = line.Signals.Where(s => s.Length == 6).Single(s =>
                {
                    var remainingForSignal = s.Where(c => !currentMappedLetters.Contains(c.ToString()));

                    return remainingForSignal.Count() == 1;
                });
                var mappingForG = signalrForNine.Where(c => !currentMappedLetters.Contains(c.ToString())).First().ToString();
                mapping.Add(mappingForG, "g");

                currentMappedLetters = mapping.Select(m => m.Key);

                var mappingForE = line.Signals.Single(s => s.Length == 7).Where(c => !currentMappedLetters.Contains(c.ToString())).First().ToString();
                mapping.Add(mappingForE, "e");



                output += SignalToNumber(mapping, line.Outputs);
            }

            return output;
        }

        private int SignalToNumber(Dictionary<string, string> mapping, IEnumerable<string> signals)
        {
            var digits = string.Empty;
            foreach (var signal in signals)
            {
                var mapped = string.Concat(signal.Select(s => mapping[s.ToString()]));
                var outputKey = outputMapping.Select(m => m.Key).Single(m => mapped.Length == m.Length && mapped.All(mc => m.Any(om => om == mc)));
                digits += outputMapping[outputKey];
            }

            return int.Parse(digits);
        }
    }
}
