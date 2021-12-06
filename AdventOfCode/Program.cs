

using AdventOfCode.Day4;

var input = DayFourInputReader.ReadInput(@"Day4\input.txt");
var day = new DayFour(input);
Console.WriteLine(day.Answer().ToString());
Console.Read();