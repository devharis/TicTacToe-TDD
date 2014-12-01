using System.Data.Common;
using System.Data.Entity;
using TicTacToe.Data;

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
        public int SaveChangesCount { get; private set; }

        int IContext.SaveChanges()
        {
            this.SaveChangesCount++;
            return 1;
        } 
    }
}
