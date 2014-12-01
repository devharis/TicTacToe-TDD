using System.Data.Entity;
using TicTacToe.Services;

namespace TicTacToe.Data
{
    public class Context : DbContext, IContext
    {
        public Context()
            : base("name=DefaultConnection")
        {

        }

        public virtual DbSet<ScoreBoard> ScoreBoards { get; set; }
    }
}
