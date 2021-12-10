

using AdventOfCode.Day10;

var input = DayTenInputReader.ReadInput(@"Day10\input.txt");
var day = new DayTen(input);
Console.WriteLine(day.Answer().ToString());
Console.Read();