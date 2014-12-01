using System.Data.Common;
using System.Data.Entity;
using TicTacToe.Models;

namespace TicTacToe.Services.Fakes
{
    public class TestContext : DbContext, IContext
    {
        public TestContext()
            : base("name=DefaultConnection")
        {

        }

        public TestContext(DbConnection connection)
            : base(connection, true)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.ScoreBoards = new FakeDbSet<ScoreBoard>();
        }
        public virtual DbSet<ScoreBoard> ScoreBoards { get; private set; }
    }
}
