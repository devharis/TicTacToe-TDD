﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicTacToe.Services;

namespace TicTacToe.Services
{
    public class GameWinnerService : IGameWinnerService
    {
        public char Validate(char[,] gameBoard)
        {
            var currentWinningSymbol = ' ';
            currentWinningSymbol = CheckForThreeInARowHorizontalRow(gameBoard);

            var topLeftRow = gameBoard[0, 0];
            var midLeftRow = gameBoard[1, 0];
            var bottomLeftRow = gameBoard[2, 0];

            if (topLeftRow == midLeftRow && midLeftRow == bottomLeftRow)
                currentWinningSymbol = topLeftRow;

            return currentWinningSymbol;
        }

        private static char CheckForThreeInARowHorizontalRow(char[,] gameBoard)
        {
            var topLeftColumn = gameBoard[0, 0];
            var topMidColumn = gameBoard[0, 1];
            var topRightColumn = gameBoard[0, 2];

            if (topLeftColumn == topMidColumn && topMidColumn == topRightColumn)
                return topLeftColumn;

            return ' ';
        }

    }
}
