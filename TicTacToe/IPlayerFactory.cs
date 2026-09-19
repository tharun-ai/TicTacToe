using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
     public interface IPlayerFactory
    {
        Player CreatePlayer(string name, char symbol);
    }

    public class PlayerFactory : IPlayerFactory
    {
        public Player CreatePlayer(string name, char symbol)
        {
            return new Player(name, symbol);
        }
    }
}
