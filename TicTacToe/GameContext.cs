using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public  class GameContext
    {
        public IGameState currentState;


        public void setCurrentState(IGameState state)
        {
            currentState = state;
        }

        public void moveNext(bool hasWon, Player player)
        {
            currentState.moveNext(this, hasWon, player);
        }

        public bool isGameOver()
        {
            return currentState.isGameOver();
        }

        public IGameState getCurrentState()
        {
            return currentState;
        }
    }
}
