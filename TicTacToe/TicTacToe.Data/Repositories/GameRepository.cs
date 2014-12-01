using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Data.Interfaces;
using TicTacToe.Services;

namespace TicTacToe.Data.Repositories
{
    public class GameRepository : IRepository
    {
        private readonly IContext _context;

        public GameRepository()
            : this(new Context())
        {
            // Blank!
        }

        public GameRepository(IContext context)
        {
            this._context = context;

            if (_context == null)
                throw new ArgumentNullException("Context is not initialized correctly");
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return _context.Set<T>().AsQueryable<T>();
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
        }

        public void Remove<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
