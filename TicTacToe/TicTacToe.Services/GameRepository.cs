﻿using System;
using System.Collections.Generic;
﻿using System.Data.Entity;
using System.Linq;
using TicTacToe.Services.Repositories;

namespace TicTacToe.Services
{
    public class GameRepository : IRepository
    {
        private readonly DbContext _context;

        public GameRepository()
            : this(new Context())
        {
            // Blank!
        }

        public GameRepository(DbContext context)
        {
            this._context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            
            _context.Set<T>().Add(entity);
        }
    }
}
