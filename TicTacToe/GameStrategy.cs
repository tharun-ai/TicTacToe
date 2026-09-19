using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
     public  class GameStrategy
    {

        public void nextMove(Board board, Player player)
        {
            Console.WriteLine($"{player.Name}'s turn ({player.Symbol}). Enter row and column (0-2):");
            int row = Convert.ToInt32(Console.ReadLine());
            int col = Convert.ToInt32(Console.ReadLine());
            if (board.CheckValidPosition(row, col))
            {
                if (!board.MakeMove(row, col, player.Symbol))
                {
                    Console.WriteLine("Invalid move! Position already taken.");
                    nextMove(board, player);
                }
            }
            else
            {
                Console.WriteLine("Invalid position! Please enter a valid row and column (0-2).");
                nextMove(board, player);
            }
        }
    }
}
