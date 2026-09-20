using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public interface IGameState
    {
        public void moveNext(GameContext context,bool hasWon,Player player);

        public bool isGameOver();


    }
}
