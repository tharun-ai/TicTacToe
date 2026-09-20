

using System;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("-- Main Menu --");
                Console.WriteLine("1. Play Tic Tac Toe");
                Console.WriteLine("2. Exit");
                Console.Write("Select an option: ");

                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    IBoardGames game = new TicTacToeGames();
                    game.Play();
                }
                else if (choice == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid selection. Try again.");
                }

                Console.WriteLine();
            }
        }
    }
}
