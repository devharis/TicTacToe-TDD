using System.Data.Entity;

namespace TicTacToe.Data
{
    public interface IContext
    {
        DbSet<T> Set<T>() where T : class;
        int SaveChanges(); 
    }
}
