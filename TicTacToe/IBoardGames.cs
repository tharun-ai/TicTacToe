using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public  interface IBoardGames
    {
        void Play();
    }

    public class TicTacToeGames : IBoardGames
    {
        Board board = new Board();
        int numberOfRows, numberOfColumns;
        public void Play()
        {
           Console.WriteLine("Enter the number of rows for the Tic Tac Toe board: ");
           numberOfRows = int.Parse(Console.ReadLine());
           Console.WriteLine("Enter the number of columns for the Tic Tac Toe board: ");
           numberOfColumns = int.Parse(Console.ReadLine());
           board.StartGame(numberOfRows, numberOfColumns);
        }

    }
}
