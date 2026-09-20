using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class PlayerXTurnState : IGameState
    {
        public void moveNext(GameContext context, bool hasWon, Player player)
        {
            if(hasWon)
            {
               context.setCurrentState(player.GetSymbol() == 'X' ? new PlayerXWonState() : new PlayerOWonState());
            }
            else
            {
                context.setCurrentState(new PlayerOTurnState());
                // Transition to Player O's turn
                Console.WriteLine("Transitioning to Player O's turn.");
                // This would typically involve changing the state in the GameContext
            }
          
            // After Player X makes a move, transition to Player O's turn
            // This would typically involve changing the state in the GameContext
        }
        public bool isGameOver()
        {
            // X's turn state is not a terminal state
            return false;
        }

       
    }

    public class PlayerOTurnState : IGameState
    {
        public void moveNext(GameContext context, bool hasWon, Player player)
        {
            if (hasWon)
            {
                context.setCurrentState(player.GetSymbol() == 'O' ? new PlayerOWonState() : new PlayerXWonState());
            }
            else
            {
                context.setCurrentState(new PlayerXTurnState());
                // Transition to Player X's turn
                Console.WriteLine("Transitioning to Player X's turn.");
                // This would typically involve changing the state in the GameContext
            }

            // After Player O makes a move, transition to Player X's turn
            // This would typically involve changing the state in the GameContext
        }
        public bool isGameOver()
        {
            // O's turn state is not a terminal state
            return false;
        }
    }

    public class PlayerXWonState : IGameState
    {
        public void moveNext(GameContext context, bool hasWon, Player player)
        {
            // Game is already won by Player X, no further moves allowed
            Console.WriteLine("Game Over. Player X has already won!");
        }
        public bool isGameOver()
        {
            // Logic for handling game over state
            Console.WriteLine("Game Over. Player X has won!");
            return true;
        }
    }

    public class PlayerOWonState : IGameState
    {
        public void moveNext(GameContext context, bool hasWon, Player player)
        {
            // Game is already won by Player O, no further moves allowed
            Console.WriteLine("Game Over. Player O has already won!");
        }
        public bool isGameOver()
        {
            // Logic for handling game over state
            Console.WriteLine("Game Over. Player O has won!");
            return true;
        }
    }

    public class PlayerDrawState : IGameState
    {
        public void moveNext(GameContext context, bool hasWon, Player player)
        {
            Console.WriteLine("Game Over. The game is a draw.");
        }

        public bool isGameOver()
        {
            Console.WriteLine("Game Over. The game is a draw.");
            return true;
        }
    }
}
