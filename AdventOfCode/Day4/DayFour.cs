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
            var fullWinningBoards = new List<((int, bool)[,]?, int)>();
            foreach (var drawnNumber in input.DrawnNumbers)
            {
                CallANumber(drawnNumber, fullWinningBoards);

                var winningBoards = WinningBoards(fullWinningBoards);

                if (winningBoards != null && winningBoards.Any())
                {
                    foreach (var winningBoard in winningBoards)
                    {
                        fullWinningBoards.Add((winningBoard, ScoreTheBoard(winningBoard, drawnNumber)));
                    }
                }
            }
            var lastWinner = fullWinningBoards.Last();
            return lastWinner.Item2;
        }

        private void CallANumber(int drawnNumber, List<((int, bool)[,]?, int)> alreadyWinningBoards)
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

        private List<(int, bool)[,]?> WinningBoards(List<((int, bool)[,]?, int)> alreadyWinningBoards)
        {
            var remainingBoards = input.Boards.Where(b => alreadyWinningBoards.All(awb => awb.Item1 != b)).ToList();
            var newWinningBoards = new List<(int, bool)[,]?>();
            foreach (var board in remainingBoards)
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
                        newWinningBoards.Add(board);
                        continue;
                    }
                }

                for (var col = 0; col < input.BoardDim; col++)
                {
                    var winningCol = true;
                    for (var row = 0; row < input.BoardDim; row++)
                    {
                        if (!board[row, col].Item2)
                        {
                            winningCol = false;
                        }
                    }

                    if (winningCol)
                    {
                        newWinningBoards.Add(board);
                        continue;
                    }
                }
            }

            return newWinningBoards;
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
