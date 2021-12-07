

using AdventOfCode.Day7;

var input = DaySevenInputReader.ReadInput(@"Day7\input.txt");
var day = new DaySeven(input);
Console.WriteLine(day.Answer().ToString());
Console.Read();