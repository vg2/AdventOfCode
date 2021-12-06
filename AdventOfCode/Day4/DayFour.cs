using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day4
{
    internal class DayFour
    {
        private readonly DayFourInput input;
        public DayFour(DayFourInput input)
        {
            this.input = input;
        }

        public int Answer()
        {
            foreach (var drawnNumber in input.DrawnNumbers)
            {
                CallANumber(drawnNumber);

                var winningBoard = WinningBoard();

                if (winningBoard.Item1 != null)
                {
                    return ScoreTheBoard(winningBoard.Item1, drawnNumber);
                }
            }
            return 0;
        }

        private void CallANumber(int drawnNumber)
        {
            foreach (var board in input.Boards)
            {
                for (var i = 0; i < input.BoardDim; i++)
                {
                    for (var j = 0; j < input.BoardDim; j++)
                    {
                        if (board[i, j].Item1 == drawnNumber)
                        {
                            board[i, j].Item2 = true;
                        }
                    }
                }
            }
        }

        private ((int, bool)[,]?, int?, int?) WinningBoard()
        {
            foreach (var board in input.Boards)
            {
                for (var row = 0; row < input.BoardDim; row++)
                {
                    var winningRow = true;
                    for (var col = 0; col < input.BoardDim; col++)
                    {
                        if (!board[row, col].Item2)
                        {
                            winningRow = false;
                        }
                    }
                    if (winningRow)
                    {
                        return (board, row, null);
                    }
                }

                for (var col = 0; col < input.BoardDim; col++)
                {
                    var winningCol = false;
                    for (var row = 0; row < input.BoardDim; row++)
                    {
                        if (!board[row, col].Item2)
                        {
                            winningCol = false;
                        }
                    }

                    if (winningCol)
                    {
                        return (board, col, null);
                    }
                }
            }

            return (null, null, null);
        }

        private int ScoreTheBoard((int, bool)[,] board, int winningNumber)
        {
            var totalUnmatched = 0;

            for (var i = 0; i < input.BoardDim; i++)
            {
                for (var j = 0; j < input.BoardDim; j++)
                {
                    if (!board[i,j].Item2)
                    {
                        totalUnmatched += board[i, j].Item1;
                    }
                }
            }

            return totalUnmatched * winningNumber;
        }

    }
}
