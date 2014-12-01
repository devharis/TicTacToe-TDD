using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Services;
using TicTacToe.Services.Interfaces;

namespace TicTacToe.Services.Services
{
    [TestClass]
    public class GameWinnerServiceTests
    {
        private IGameWinnerService _gameWinnerService;
        private char[,] _gameBoard;

        [TestInitialize]
        public void SetupUnitTest()
        {
            _gameWinnerService = new GameWinnerService();
            _gameBoard = new char[3, 3] {
                {' ', ' ', ' '},
                {' ', ' ', ' '},
                {' ', ' ', ' '}
            };
        }

        [TestMethod]
        public void NeitherPlayerHasThreeInARow()
        {
            // Arrange
            const char expected = ' ';
            
            // Act
            var actual = _gameWinnerService.Validate(_gameBoard);
            
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PlayerWithAllSpacesInTopRowIsWinner()
        {
            // Arrange
            var expected = 'X';
            for (var rowIndex = 0; rowIndex < 3; rowIndex++)
                _gameBoard[0, rowIndex] = expected;

            // Act
            var actual = _gameWinnerService.Validate(_gameBoard);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PlayerWithAllSpacesInFirstColumnIsWinner()
        {
            // Arrange
            var expected = 'X';
            for (var columnIndex = 0; columnIndex < 3; columnIndex++)
                _gameBoard[columnIndex, 0] = expected;

            // Act
            var actual = _gameWinnerService.Validate(_gameBoard);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PlayerWithThreeInARowDiagonallyDownToRightIsWinner()
        {
            //Arrange
            var expected = 'X';
            for (var cellIndex = 0; cellIndex < 3; cellIndex++)
                _gameBoard[cellIndex, cellIndex] = expected;

            // Act
            var actual = _gameWinnerService.Validate(_gameBoard);
            
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GameWithAllSpacesFilledWithoutWinnerIsTie()
        {
            // Arrange
            var playerOne = 'X';
            var playerTwo = 'O';

            var expected = '-';

            _gameBoard = new char[3, 3] {
                {playerOne, playerTwo, playerOne},
                {playerTwo, playerOne, playerTwo},
                {playerTwo, playerOne, playerTwo}
            };

            // Act
            var actual = _gameWinnerService.Validate(_gameBoard);
            
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GameWithOneSpaceLeftShouldNotBeTie()
        {
            // Arrange
            var playerOne = 'X';
            var playerTwo = 'O';

            var expected = ' ';

            _gameBoard = new char[3, 3] {
                {playerOne, playerTwo, playerOne},
                {playerTwo, playerOne, playerTwo},
                {' ', playerOne, playerTwo}
            };

            // Act
            var actual = _gameWinnerService.Validate(_gameBoard);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
