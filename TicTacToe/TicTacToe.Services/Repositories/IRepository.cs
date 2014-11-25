using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe.Services.Repositories
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
    }
}
