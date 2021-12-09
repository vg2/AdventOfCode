

using AdventOfCode.Day9;

var input = DayNineInputReader.ReadInput(@"Day9\input.txt");
var day = new DayNine(input);
Console.WriteLine(day.Answer().ToString());
Console.Read();