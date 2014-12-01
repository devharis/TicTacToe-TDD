using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TicTacToe.Data;
using TicTacToe.Data.Interfaces;
using TicTacToe.Data.Repositories;
using TestContext = TicTacToe.Services.Fakes.TestContext;

namespace TicTacToe.Services.Repositories
{
    [TestClass]
    public class GameRepositoryTests
    {
        Mock<IContext> _databaseContext;
        IRepository _gameRepository;
        Mock<DbSet<ScoreBoard>> _mockSet;

        [TestInitialize]
        public void Initialize()
        {
            _mockSet = new Mock<DbSet<ScoreBoard>>();
            _databaseContext = new Mock<IContext>();        
            var list = new List<ScoreBoard>();
            list.Add(new ScoreBoard()
            {
                Id = 1, Name = "Haris"
            });
            
            // Convert the IEnumerable list to an IQueryable list
            IQueryable<ScoreBoard> queryableList = list.AsQueryable();

            // Force DbSet to return the IQueryable members of our converted list object as its data source
            var mockSet = new Mock<DbSet<ScoreBoard>>();
            mockSet.As<IQueryable<ScoreBoard>>().Setup(m => m.Provider).Returns(queryableList.Provider);
            mockSet.As<IQueryable<ScoreBoard>>().Setup(m => m.Expression).Returns(queryableList.Expression);
            mockSet.As<IQueryable<ScoreBoard>>().Setup(m => m.ElementType).Returns(queryableList.ElementType);
            mockSet.As<IQueryable<ScoreBoard>>().Setup(m => m.GetEnumerator()).Returns(queryableList.GetEnumerator());
            _databaseContext.Setup(o => o.Set<ScoreBoard>()).Returns(_mockSet.Object);  

            _gameRepository = new GameRepository(_databaseContext.Object);

        }

        [TestMethod]
        public void ContextIsInitializedCorrectly()
        {
            // Arrange

            // Act
            var context = new Context();

            // Assert
            Assert.IsNotNull(context.Database);
        }

        [TestMethod]
        public void DefaultConstructorInitializedCorrectly()
        {
            // Act
            var gameRepository = new GameRepository();

            // Assert
            Assert.IsNotNull(gameRepository);
        }

        [TestMethod]
        public void ConstructorShouldThrowErrorIfNotContextIsInitialized()
        {
            // Arrange
            Fakes.TestContext context = null;
            Exception expectedExcetpion = null;

            // Act
            try
            {
                var gameRepository = new GameRepository(context);
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }

            // Assert
            Assert.IsNotNull(expectedExcetpion);
        }

        [TestMethod]
        public void RepositoryMustHaveAdd()
        {
            // Arrange
            var scoreBoard = new ScoreBoard()
            {
                Id = 0,
                Name = "Haris"
            };

            // Act
            _gameRepository.Add(scoreBoard);

            // Assert
            _mockSet.Verify(m => m.Add(It.IsAny<ScoreBoard>()), Times.Once());
           
        }

        [TestMethod]
        public void RepositoryMustHaveDelete()
        {
            // Arrange
            var scoreBoard = new ScoreBoard()
            {
                Id = 0,
                Name = "Haris"
            };

            // Act
            _gameRepository.Remove(scoreBoard);

            // Assert
            _mockSet.Verify(m => m.Remove(It.IsAny<ScoreBoard>()), Times.Once());
        }

        [TestMethod]
        public void RepositoryMustHaveSave()
        {
            // Arrange
            const int expected = 1;

            IContext testContext = new TestContext();
            var gameRepository = new GameRepository(testContext);

            // Act
            var actual = gameRepository.SaveChanges();    

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RepositoryMustHaveGet()
        {
            // Arrange
            const int expected = 5;
            
            
            // Act
            var scoreBoardList = _gameRepository.Query<ScoreBoard>();

            // Assert
            Assert.AreEqual(expected, scoreBoardList.AsEnumerable().Count());
        }
    }
}
