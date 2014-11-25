using System.Data.Common;
using System.Data.Entity;
using Effort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToe.Services.Repositories
{
    [TestClass]
    public class GameRepositoryTests
    {
        DbConnection _connection;
        DbContext _databaseContext;
        IRepository _gameRepository;

        [TestInitialize]
        public void Initialize()
        {
            _connection = DbConnectionFactory.CreateTransient();
            _databaseContext = new Context(_connection);
            _gameRepository = new GameRepository(_databaseContext);

        }

        [TestMethod]
        public void RepositoryMustChangeStateOnAdd()
        {
            // Arrange
            const EntityState expected = EntityState.Added;

            var scoreBoard = new ScoreBoard()
            {
                Id = 0,
                Name = "Haris"
            };

            // Act
            _gameRepository.Add(scoreBoard);

            // Assert
            Assert.AreEqual(expected, _databaseContext.Entry(scoreBoard).State);
        }

        [TestMethod]
        public void StateMustChange()
        {
            // Arrange
            const EntityState expected = EntityState.Added;

            var scoreBoard = new ScoreBoard()
            {
                Id = 0,
                Name = "Haris"
            };

            // Act
            _gameRepository.Add(scoreBoard);

            // Assert
            Assert.AreEqual(expected, _databaseContext.Entry(scoreBoard).State);
        }
    }
}
