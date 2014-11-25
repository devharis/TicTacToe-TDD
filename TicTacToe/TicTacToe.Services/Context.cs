using System.Data.Common;
using System.Data.Entity;

namespace TicTacToe.Services
{
    public class Context : DbContext
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

        public DbSet<ScoreBoard> ScoreBoard { get; set; }
    }
}
