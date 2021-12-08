

using AdventOfCode.Day8;

var input = DayEightInputReader.ReadInput(@"Day8\input.txt");
var day = new DayEight(input);
Console.WriteLine(day.Answer().ToString());
Console.Read();