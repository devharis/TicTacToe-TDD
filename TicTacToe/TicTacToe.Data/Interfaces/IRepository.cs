using System.Collections.Generic;
using System.Linq;
using TicTacToe.Services;

namespace TicTacToe.Data.Interfaces
{
    public interface IRepository
    {
        IQueryable<T> Query<T>() where T : class;
        void Add<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        int SaveChanges();      
    }
}
