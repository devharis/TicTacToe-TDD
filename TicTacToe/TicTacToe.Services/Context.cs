using System.Data.Common;
using System.Data.Entity;

namespace TicTacToe.Services
{
    public class Context : DbContext, IContext
    {
        public Context()
            : base("name=DefaultConnection")
        {

        }

        public Context(DbConnection connection)
            : base(connection, true)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public virtual DbSet<ScoreBoard> ScoreBoards { get; set; }
    }
}
