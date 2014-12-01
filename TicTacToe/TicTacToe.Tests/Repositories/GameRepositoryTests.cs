using System.Data.Common;
using System.Data.Entity;
using Effort;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TicTacToe.Models;
using TicTacToe.Services.Interfaces;
using TestContext = TicTacToe.Services.Fakes.TestContext;

namespace TicTacToe.Services.Repositories
{
    [TestClass]
    public class GameRepositoryTests
    {
        DbConnection _connection;
        Mock<IContext> _databaseContext;
        IRepository _gameRepository;
        Mock<DbSet<ScoreBoard>> _mockSet;

        [TestInitialize]
        public void Initialize()
        {
            _mockSet = new Mock<DbSet<ScoreBoard>>();
            _connection = DbConnectionFactory.CreateTransient();
            _databaseContext = new Mock<IContext>();
            _databaseContext.Setup(o => o.Set<ScoreBoard>()).Returns(_mockSet.Object);
            _gameRepository = new GameRepository(_databaseContext.Object);

        }

        [TestMethod]
        public void ContextIsInitializedCorrectly()
        {
            // Arrange
            const string expected = "ThisIsAFakeConnection";

            // Act
            var context = new Context();

            // Assert
            Assert.AreEqual(context.Database.Connection.ConnectionString, expected);
        }

        [TestMethod]
        public void RepositoryMustChangeStateOnAdd()
        {
            // Arrange


            var scoreBoard = new ScoreBoard()
            {
                Id = 0,
                Name = "Haris"
            };

            // Act
            _gameRepository.Add(scoreBoard);

            _mockSet.Verify(m => m.Add(It.IsAny<ScoreBoard>()), Times.Once());
           
        }

        //[TestMethod]
        //public void StateMustChange()
        //{
        //    // Arrange
        //    const EntityState expected = EntityState.Added;
        //    var scoreBoard = new ScoreBoard()
        //    {
        //        Id = 0,
        //        Name = "Haris"
        //    };

        //    // Act
        //    _gameRepository.Add(scoreBoard);

        //    // Assert
        //    Assert.AreEqual(expected, _databaseContext.Entry(scoreBoard).State);
        //}
    }
}
