﻿using System;
using TicTacToe.Services.Interfaces;

namespace TicTacToe.Services.Services
{
    public class GameWinnerService : IGameWinnerService
    {
        private const char SymbolForNoWinner = ' ';
        private const char SymbolForTie = '-';

        public char Validate(char[,] gameBoard)
        {
            var currentWinningSymbol = SymbolForNoWinner;
            currentWinningSymbol = CheckForThreeInARowHorizontalRow(gameBoard);

            if (currentWinningSymbol != SymbolForNoWinner)
                return currentWinningSymbol;

            currentWinningSymbol = CheckForThreeInARowVerticalColumn(gameBoard);

            if (currentWinningSymbol != SymbolForNoWinner)
                return currentWinningSymbol;

            currentWinningSymbol = CheckForThreeInARowDiagonally(gameBoard);

            if (currentWinningSymbol != SymbolForNoWinner)
                return currentWinningSymbol;

            currentWinningSymbol = CheckForTie(gameBoard);

            return currentWinningSymbol;
        }

        private char CheckForTie(char[,] gameBoard)
        {
            var gameBoardEnumerable = gameBoard.GetEnumerator();
            while (gameBoardEnumerable.MoveNext())
            {
                var current = (char)gameBoardEnumerable.Current;
                if (Char.IsWhiteSpace(current))
                    return SymbolForNoWinner;
            }
            return SymbolForTie;
        }

        private static char CheckForThreeInARowVerticalColumn(char[,] gameBoard)
        {
            var topLeftRow = gameBoard[0, 0];
            var midLeftRow = gameBoard[1, 0];
            var bottomLeftRow = gameBoard[2, 0];

            if (topLeftRow == midLeftRow && midLeftRow == bottomLeftRow)
                return topLeftRow;

            return SymbolForNoWinner;
        }

        private static char CheckForThreeInARowHorizontalRow(char[,] gameBoard)
        {
            var topLeftColumn = gameBoard[0, 0];
            var topMidColumn = gameBoard[0, 1];
            var topRightColumn = gameBoard[0, 2];

            if (topLeftColumn == topMidColumn && topMidColumn == topRightColumn)
                return topLeftColumn;

            return SymbolForNoWinner;
        }

        private static char CheckForThreeInARowDiagonally(char[,] gameBoard)
        {
            var topLeftCell = gameBoard[0, 0];
            var centerCell = gameBoard[1, 1];
            var bottomRightCell = gameBoard[2, 2];

            if (topLeftCell == centerCell && centerCell == bottomRightCell)
                return topLeftCell;

            return SymbolForNoWinner;
        }

    }
}
