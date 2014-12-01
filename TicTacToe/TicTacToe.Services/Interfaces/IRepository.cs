namespace TicTacToe.Services.Interfaces
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
    }
}
