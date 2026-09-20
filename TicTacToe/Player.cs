using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Player
    {
        char symbol;
        int row, Column;
        private string Name { get; set; }

        public Player(char symbol)
        {
            this.symbol = symbol;
            Console.WriteLine($"Enter name for player {symbol}: ");
            Name = Console.ReadLine();
        }

        public void MakeMove(Board board)
        {
            while(true)
            {
                Console.WriteLine($"{Name} ({symbol}), enter your move (row and column): ");
                row = int.Parse(Console.ReadLine());
                Column = int.Parse(Console.ReadLine());
                if (board.IsValidMove(row, Column))
                {
                    board.setCurrentRowCol(row, Column);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid move. Please try again.");
                }
            }
        }

        public char GetSymbol()
        {
            return symbol;
        }
    }
}
