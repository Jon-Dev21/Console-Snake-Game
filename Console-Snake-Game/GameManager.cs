using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Console_Snake_Game
{
    /// <summary>
    /// This class manages the entire game.
    /// </summary>
    class GameManager
    {
        public static Board snakeBoard;
        public static Player player;
        ScoreManager scoreManager;
        Timer gameTimer = new Timer(400);

        public static int secondsCount = 0;


        public GameManager(Board board, Player _player)
        {
            snakeBoard = board;
            player = _player;
            gameTimer.Elapsed += Timer_Elapsed;
            gameTimer.Enabled = true;
            gameTimer.AutoReset = true;
            snakeBoard.CreateBoard();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            snakeBoard.AddPlayerToBoard(player);
            Console.Clear();
            snakeBoard.PrintBoard();
            //player.MoveRight();

            //secondsCount++;
            //Console.WriteLine(secondsCount + " Seconds");

        }

        /// <summary>
        /// Method used to start the game.
        /// </summary>
        public void StartGame()
        {
            //Console.WriteLine("StartGame called.");
            //// First, create the snake board.
            
            //snakeBoard.AddPlayerToBoard(player);
            //Console.Clear();
            //snakeBoard.PrintBoard();
            //player.MoveDown();
            //if(Console.ReadKey().Key == ConsoleKey.W)
            //{
            //    player.MoveUp();
            //} else if (Console.ReadKey().Key == ConsoleKey.S)
            //{
            //    player.MoveDown();
            //}
        }

        public void MovePlayer()
        {
            //player.MoveLeft();
            snakeBoard.AddPlayerToBoard(player);
            snakeBoard.PrintBoard();
        }

        /// <summary>
        /// Reads settings from the settings .csv and applies them to the game.
        /// If no .csv file is found, the user is prompted to either create a new path 
        /// or start with default settings and lose changes whenever program is started again.
        /// </summary>
        public void LoadSettings()
        {
            // Check if file exists.

            // Read file

            // Creating settings object using data from the text file.
            SettingsData settings;

        }

        /// <summary>
        /// This method shows the main menu.
        /// </summary>
        public void ShowMainMenu()
        {
            Console.WriteLine("=========================================================================================");
            Console.WriteLine("=                                                                                       =");
            Console.WriteLine("=                              WELCOME TO SNAKE GAME                                    =");
            Console.WriteLine("=                                                                                       =");
            Console.WriteLine("=========================================================================================");
        }
    }
}
