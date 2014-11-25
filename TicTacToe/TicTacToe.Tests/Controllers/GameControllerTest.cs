using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Services.Controllers
{
    [TestClass]
    public class GameControllerTest
    {
        [TestMethod]
        public void IsAGameControllerInstance()
        {
            var game = new GameController();

            Assert.IsInstanceOfType(game, new GameController().GetType());
        }

    }
}
