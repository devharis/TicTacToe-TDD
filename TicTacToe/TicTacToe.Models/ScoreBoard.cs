using System;

namespace TicTacToe.Services
{
    public class ScoreBoard : IScoreBoard
    {
        public int Id { get; set; }
        public String Name { get; set; }
    }

    public interface IScoreBoard
    {
        int Id { get; set; }
        String Name { get; set; }
    }
}
