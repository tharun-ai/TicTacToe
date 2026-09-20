using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TicTacToe
{
    public class Board
    {
        private char[,] board;
        private int rows, cols;

        private int currentRow, currentCol;
        public Player player1, player2;
        public Player CurrentPlayer;

        public GameContext currentContext;

        public void StartGame(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            board = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    board[i, j] = ' ';
                }
            }

            player1 = new Player('X');
            player2 = new Player('O');
            CurrentPlayer = player1;
            // initialize game context and start with X's turn
            currentContext = new GameContext();
            currentContext.setCurrentState(new PlayerXTurnState());

            // Main game loop
            while (!currentContext.isGameOver())
            {
                DisplayBoard();

                // Ask current player to make a move
                CurrentPlayer.MakeMove(this);

                // Evaluate board after the move
                checkGameState();

                // If game ended after the move, break out
                if (currentContext.isGameOver())
                    break;

                // Check for draw (board full)
                if (IsBoardFull())
                {
                    currentContext.setCurrentState(new PlayerDrawState());
                    break;
                }

                // Switch turn
                SwitchPlayer();
            }

            DisplayBoard();
        }

        private bool IsBoardFull()
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (board[r, c] == ' ')
                        return false;
                }
            }
            return true;
        }

        public bool IsValidMove(int row, int col)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols && board[row, col] == ' ';
        }

        public void checkGameState()
        {
            for (int row = 0; row < rows; row++)
            {
                char[] rowValues = new char[cols];

                for (int col = 0; col < cols; col++)
                {
                    rowValues[col] = board[row, col];
                }

                if (isWinningLine(rowValues))
                {
                    currentContext.moveNext(
                        true,
                        CurrentPlayer);

                    return;
                }
            }
            for (int col = 0; col < cols; col++)
            {
                char[] columnValues = new char[rows];

                for (int row = 0; row < rows; row++)
                {
                    columnValues[row] = board[row, col];
                }

                if (isWinningLine(columnValues))
                {
                    currentContext.moveNext(
                        true,
                        CurrentPlayer);

                    return;
                }
            }

            if (rows == cols)
            {
                char[] primaryDiagonal = new char[rows];
                char[] secondaryDiagonal = new char[rows];

                for (int index = 0; index < rows; index++)
                {
                    primaryDiagonal[index] =
                        board[index, index];

                    secondaryDiagonal[index] =
                        board[index, cols - index - 1];
                }

                if (isWinningLine(primaryDiagonal) ||
                    isWinningLine(secondaryDiagonal))
                {
                    currentContext.moveNext(
                        true,
                        CurrentPlayer);

                    return;
                }
            }

            currentContext.moveNext(
                false,
                CurrentPlayer);


        }
        private bool isWinningLine(char[] line)
        {
            if (line == null ||
                 line.Length == 0 ||
                 line[0] == ' ')
            {
                return false;
            }

            char first = line[0];

            foreach (char symbol in line)
            {
                if (symbol != first)
                {
                    return false;
                }
            }

            return true;
        }
        public void setCurrentRowCol(int row, int col)
        {

            board[row, col] = CurrentPlayer.GetSymbol();
            currentRow = row;
            currentCol = col;

        }

        public void SwitchPlayer()
        {
            CurrentPlayer = CurrentPlayer == player1 ? player2 : player1;
        }

        public void DisplayBoard()
        {
            Console.WriteLine();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($" {board[i, j]} ");
                    if (j < cols - 1)
                        Console.Write("|");
                }
                Console.WriteLine();
                if (i < rows - 1)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write("---");
                        if (j < cols - 1)
                            Console.Write("+");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }

    }
}
