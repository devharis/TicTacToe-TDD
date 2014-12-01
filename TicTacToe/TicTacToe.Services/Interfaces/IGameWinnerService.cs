namespace TicTacToe.Services.Interfaces
{
    public interface IGameWinnerService
    {
        char Validate(char[,] gameBoard);
    }
}
