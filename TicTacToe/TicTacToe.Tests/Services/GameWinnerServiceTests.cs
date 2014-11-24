using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Services;

namespace TicTacToe.Tests.Services
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
            IGameWinnerService _gameWinnerService = new GameWinnerService();

            const char expected = ' ';

            var actual = _gameWinnerService.Validate(_gameBoard);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PlayerWithAllSpacesInTopRowIsWinner()
        {
            IGameWinnerService _gameWinnerService = new GameWinnerService();
            
            var expected = 'X';
            _gameBoard = new char[3, 3] {
                {expected, expected, expected},
                {' ', ' ', ' '},
                {' ', ' ', ' '}
            };

            var actual = _gameWinnerService.Validate(_gameBoard);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PlayerWithAllSpacesInFirstColumnIsWinner()
        {
            IGameWinnerService _gameWinnerService = new GameWinnerService();

            var expected = 'X';
            for (var columnIndex = 0; columnIndex < 3; columnIndex++)
                _gameBoard[columnIndex, 0] = expected;

            var actual = _gameWinnerService.Validate(_gameBoard);

            Assert.AreEqual(expected, actual);
        }
    }
}
