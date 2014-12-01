using System;
using TicTacToe.Services.Interfaces;

namespace TicTacToe.Services.Repositories
{
    public class GameRepository : IRepository
    {
        private readonly IContext _context;

        public GameRepository()
            : this(new Context())
        {
            // Blank!
            if(_context == null)
                throw new ArgumentNullException("Context is not initialized correctly");
        }

        public GameRepository(IContext context)
        {
            this._context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
        }
    }
}
