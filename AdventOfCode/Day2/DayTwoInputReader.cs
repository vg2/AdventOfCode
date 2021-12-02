namespace AdventOfCode.Day2
{
    internal static class DayTwoInputReader
    {
        public static IEnumerable<DayTwoInput> ReadInput(string inputPath)
        {
            var fileLines = File.ReadAllLines(inputPath);

            return fileLines.Select(l =>
            {
                var input = l.Split(' ');

                var command = Enum.Parse<Command>(input[0]);
                var units = int.Parse(input[1]);

                return new DayTwoInput(command, units);
            });
        }
    }
}
