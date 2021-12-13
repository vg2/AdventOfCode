

using AdventOfCode.Day11;

var input = DayElevenInputReader.ReadInput(@"Day11\input.txt");
var day = new DayEleven(input);
Console.WriteLine(day.Answer().ToString());
Console.Read();