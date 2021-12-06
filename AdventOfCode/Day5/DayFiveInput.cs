using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day5
{
    internal class DayFiveInput
    {
        public List<Line> Lines { get; }

        public DayFiveInput(List<Line> lines)
        {
            Lines = lines;
        }

        public List<Coordinate> AllCoverage()
        {
            return Lines.SelectMany(l => l.LineCoverage()).ToList();
        }

        public List<Coordinate> DistinctCoverage()
        {
            return AllCoverage().DistinctBy(c => c.CoordId).ToList();
        }

    }

    internal class Line
    {
        public Coordinate From { get; }
        public Coordinate To { get; }

        public Line(Coordinate from, Coordinate to)
        {
            From = from;
            To = to;
        }

        public List<Coordinate> LineCoverage()
        {
            if (From.X == To.X)
            {
                var start = From.Y > To.Y ? To.Y : From.Y;
                var end = From.Y <= To.Y  ? To.Y : From.Y;
                var coverage = Enumerable.Range(start, end-start+1).Select(y => new Coordinate(From.X, y)).ToList();
                return coverage;
            } 
            else if (From.Y == To.Y)
            {
                var start = From.X > To.X ? To.X : From.X;
                var end = From.X <= To.X ? To.X : From.X;
                var coverage = Enumerable.Range(start, end-start+1).Select(x => new Coordinate(x, From.Y)).ToList();
                return coverage;
            }
            else
            {
                var coverage = new List<Coordinate>();
                var from = From;
                coverage.Add(from);
                while (from.CoordId != To.CoordId)
                {
                    var newFromX = from.X > To.X ? from.X - 1 : from.X + 1;
                    var newFromY = from.Y > To.Y ? from.Y - 1 : from.Y + 1;
                    from = new Coordinate(newFromX, newFromY);
                    coverage.Add(from);
                }
                return coverage;
            }

            return Enumerable.Empty<Coordinate>().ToList();
        }
    }

    internal class Coordinate
    {
        public int X { get; }
        public int Y { get; }
        private string _coordId;
        public string CoordId => _coordId;

        public int Counter { get; private set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
            Counter = 0;
            _coordId = $"X{X}Y{Y}";
        }

        public void Increment(int amount)
        {
            Counter += amount;
        }
    }
}
