using System;
using System.IO;
using System.Timers;
using System.Threading;

/*
TO-DO LIST:
 
- Create a game over method (Done)
- Figure out how to move snake instead of printing the board all the time. (Thread to move snake?)
- Create method to create a snake body and make it follow each other.
- Add code to avoid going left while going right. (Done).
- Create main menu and all windows and features. (Game manager should have all game windows)
- Create fruit methods 
- Create methods to load settings from a json text file. 
  Settings such as score, keep track of how many wins/ losses / ratio, etc.

1/5/2022

Jael Opinions
- Posible cambiar grid que sea en vez de size del array a size de la ventana.
- Opciones para moverse con arrows
 */


namespace Console_Snake_Game
{
    class Program
    {
        static Board board;
        static Player p;

        static string lastInput = "d";
        static void Main(string[] args)
        {

            board = new Board(20, 36);
            p = new Player("John", 'S', 15, 5);
            GameManager SnakeGame = new GameManager(board, p);
            SnakeGame.ShowMainMenu();
            

            // Create the game board.
            //board.CreateBoard();

            //// Creating a new thread to get the controller input.
            //Thread gameInput = new(() =>
            //{

            //    while (true)
            //    {
            //        ConsoleKeyInfo ConsoleKey = Console.ReadKey();
            //        //Console.Write("Reading Key: ");
            //        if (board.IsWallHit())
            //        {
            //            break;
            //        } else
            //        {
            //            lastInput = ConsoleKey.Key.ToString();
            //        }  
            //    }
            //});

            //gameInput.Start();

            //// Creating fruit for the game.
            //Fruit f = new Fruit("F", 5, 10);

            //// Adding the fruit to the board.
            //board.AddFruitToBoard(f);

            //// Main Thread will print the board 
            //while (true)
            //{
            //    ShowBoard();

            //    Thread.Sleep(10);

            //    // Check game over
            //    if (board.IsWallHit())
            //    {
            //        break;
            //    }
            //    if (board.AteFruit(p, f))
            //    {
            //        board.AddFruitToBoard(f);
            //    }
            //}

            //Console.WriteLine("Game Over.");


            // Testing ScoreManager

            //ScoreManager scoreManager = new ScoreManager(@"scores.csv");
            //p.playerHighScore = 10;
            //scoreManager.SetHighScore(p);
            //scoreManager.WriteRecord();
        }

        /// <summary>
        /// Rename this function later to "PlayerMove"
        /// </summary>
        static void ShowBoard()
        {
            board.AddPlayerToBoard(p);
            
            Console.Clear();
            p.Move(lastInput);


            board.PrintBoard();
            
            //Console.WriteLine("Last Input: "+ lastInput);
        }

    }
}
