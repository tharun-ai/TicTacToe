using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public  class Board
    {
        char[,] _board;



        public void Play()
        {
            _board = new char[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _board[i, j] = ' ';
                }
            }

            


        }

        public void displayBoard()
        {
            Console.WriteLine("  0 1 2");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(_board[i, j]);
                    if (j < 2)
                        Console.Write("|");
                }
                Console.WriteLine();
                if (i < 2)
                    Console.WriteLine("  -----");
            }
        }

        public bool MakeMove(int row, int col, char symbol)
        {
            if (_board[row, col] == ' ')
            {
                _board[row, col] = symbol;
                return true;
            }
            return false;
        }


        public bool CheckValidPosition(int row, int col)
        {
            if (row < 0 || row > 2 || col < 0 || col > 2)
            {
                return false;
            }
            return true;
        }

        public bool CheckDraw()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_board[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public bool CheckWin(char symbol)
        {
            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if (_board[i, 0] == symbol && _board[i, 1] == symbol && _board[i, 2] == symbol)
                {
                    return true;
                }
            }
            // Check columns
            for (int j = 0; j < 3; j++)
            {
                if (_board[0, j] == symbol && _board[1, j] == symbol && _board[2, j] == symbol)
                {
                    return true;
                }
            }
            // Check diagonals
            if (_board[0, 0] == symbol && _board[1, 1] == symbol && _board[2, 2] == symbol)
            {
                return true;
            }
            if (_board[0, 2] == symbol && _board[1, 1] == symbol && _board[2, 0] == symbol)
            {
                return true;
            }
            return false;
        }
        
    }
}
