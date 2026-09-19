using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Game
    {

        private  IPlayerFactory _playerFactory ;

        private  List<Player> _players= [];
      

        public void Start()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("Player 1, enter your name:");
            string player1Name = Console.ReadLine();
            Console.WriteLine("Player 2, enter your name:");
            string player2Name = Console.ReadLine();
            _playerFactory = new PlayerFactory();
         
            _players.Add(_playerFactory.CreatePlayer(player1Name, 'X'));
            _players.Add(_playerFactory.CreatePlayer(player2Name, 'O'));
           
        }


        public void Play()
        {
            Board board = new Board();
            board.Play();
            int currentPlayerIndex = 0;
            while (true)
            {
                board.displayBoard();
                Player currentPlayer = _players[currentPlayerIndex];
                GameStrategy strategy = new GameStrategy();
                strategy.nextMove(board, currentPlayer);
                if (board.CheckWin(currentPlayer.Symbol))
                {
                    board.displayBoard();
                    Console.WriteLine($"{currentPlayer.Name} wins!");
                    break;
                }
                if (board.CheckDraw())
                {
                    board.displayBoard();
                    Console.WriteLine("It's a draw!");
                    break;
                }
                currentPlayerIndex = (currentPlayerIndex + 1) % 2;
            }
        }
    }
}
