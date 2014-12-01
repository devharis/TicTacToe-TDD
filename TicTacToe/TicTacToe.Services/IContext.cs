using System.Data.Entity;

namespace TicTacToe.Services
{
    public interface IContext
    {
        DbSet<T> Set<T>() where T : class;
    }
}
