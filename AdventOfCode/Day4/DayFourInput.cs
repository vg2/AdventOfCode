using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day4
{
    internal class DayFourInput
    {
        public int[] DrawnNumbers { get; }
        public int BoardDim { get; }
        public List<(int, bool)[,]> Boards { get; }

        public DayFourInput(int[] drawnNumbers, List<(int, bool)[,]> boards, int boardDim)
        {
            DrawnNumbers = drawnNumbers;
            Boards = boards;
            BoardDim = boardDim;
        }


    }

}
