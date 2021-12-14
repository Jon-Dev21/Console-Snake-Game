using System;
using System.IO;
using System.Timers;

namespace Console_Snake_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(20, 40);
            Player p = new Player("John", 'S', 5, 5);
            //GameManager SnakeGame = new GameManager(board, p);

            //board.MovePlayer();
            board.CreateBoard();
            

            board.AddPlayerToBoard(p);
            board.SaveBoard();
            Console.WriteLine(board.GetBoardString());
            //if (Console.ReadKey().Key == ConsoleKey.A)
            //{
            //    Console.WriteLine("Key pressed is A");
            //}
            //else
            //{
            //    Console.WriteLine("I don't know what the kell you pressed.");
            //}
            //SnakeGame.StartGame();
            //Console.WriteLine();


            // Testing ScoreManager

            //ScoreManager scoreManager = new ScoreManager(@"scores.csv");
            //p.playerHighScore = 10;
            //scoreManager.SetHighScore(p);
            //scoreManager.WriteRecord();
        }
    }
}
