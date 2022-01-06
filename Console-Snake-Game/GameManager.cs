using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Console_Snake_Game
{
    /// <summary>
    /// This class manages the entire game. 
    /// It contains a game board, a player and a score manager.
    /// It also contains methods to start the game, customize settings,
    /// saveState, etc.
    /// </summary>
    class GameManager
    {
        /// <summary>
        /// Snake Game Board.
        /// </summary>
        private static Board snakeBoard;
        
        /// <summary>
        /// Snake game Player
        /// </summary>
        private Player player;

        /// <summary>
        /// Variable to indicate if the game is over.
        /// </summary>
        private bool GameOver;

        /// <summary>
        /// Score manager used to manage saving and loading highscores.
        /// </summary>
        private static ScoreManager scoreManager;

        /// <summary>
        /// Color used to Highlight Game
        /// </summary>
        ConsoleColor OptionsColor = ConsoleColor.Yellow;

        /// <summary>
        /// Console Background Color
        /// </summary>
        ConsoleColor BackgroundColor = ConsoleColor.Black;

        /// <summary>
        /// Console Foreground Color.
        /// </summary>
        ConsoleColor ForegroundColor = ConsoleColor.White;

        /// <summary>
        /// Holds the game's current score.
        /// </summary>
        private int CurrentScore = 0;

        /// <summary>
        /// Holds the game's high score.
        /// </summary>
        private int HighScore = 1000;

        /// <summary>
        /// Variable used to store user input during game.
        /// </summary>
        string input = "";


        // Easy: 100
        // Normal: 50
        // Hard: 10
        // Brutal: 1
        public static int gameTimer = 100;

        /// <summary>
        /// Last Keystroke Input.
        /// Snake will start moving depending on this input.
        /// Left: A,
        /// Right: D,
        /// Up: W,
        /// Down: S
        /// </summary>
        static string lastInput = "d";

        // Creating a new thread to get the controller input.
        //Thread gameInput = new(() =>
        //{
        //    while (true)
        //    {
        //        ConsoleKeyInfo ConsoleKey = Console.ReadKey();
        //        //Console.Write("Reading Key: ");
        //        if (snakeBoard.IsWallHit())
        //        {
        //            break;
        //        }
        //        else
        //        {
        //            lastInput = ConsoleKey.Key.ToString();
        //        }
        //    }
        //});

        public GameManager(Board board, Player _player)
        {
            Console.Title = "Snake Game by Calculus";
            snakeBoard = board;
            player = _player;
            snakeBoard.CreateBoard();
            GameOver = snakeBoard.IsWallHit();
        }

        /// <summary>
        /// Method used to start the game.
        /// </summary>
        public void StartGame()
        {
            // Creating a new thread to get the controller input.
            new Thread (() =>
            {
                while (true)
                {
                    ConsoleKeyInfo ConsoleKey = Console.ReadKey();
                    //Console.Write("Reading Key: ");
                    if (snakeBoard.IsWallHit())
                    {
                        break;
                    }
                    else
                    {
                        lastInput = ConsoleKey.Key.ToString();
                    }
                }
            }).Start();

            // Creating fruit for the game.
            Fruit f = new Fruit("F", 5, 10);

            // Adding the fruit to the board.
            snakeBoard.AddFruitToBoard(f);

            // Reset player position.
            ResetPlayer();

            snakeBoard.ResetWallHit();

            // Main Thread will print the board 
            while (true)
            {
                // Execute a game tick.
                GameTick();
                
                // Put the main thread to sleep.
                Thread.Sleep(gameTimer);

                // Check game over
                if (snakeBoard.IsWallHit())
                {
                    Console.WriteLine("Game Over.");
                    GameOver = true;
                    break;
                }
                // Check if snake ate a fruit.
                if (snakeBoard.AteFruit(player, f))
                {
                    // Add another fruit.
                    snakeBoard.AddFruitToBoard(f);
                }
            }

            if (GameOver)
            {
                
                ShowGameOver(1);
            }
        }

        /// <summary>
        /// Resets player position.
        /// </summary>
        public void ResetPlayer()
        {
            Random rand = new Random();
            player.playerBody[0].X = rand.Next(2, snakeBoard.Rows - 5);
            player.playerBody[0].Y = rand.Next(2, snakeBoard.Columns - 5);
        }

        /// <summary>
        /// This method executes each game tick. It moves the player and prints the board
        /// </summary>
        private void GameTick()
        {
            snakeBoard.AddPlayerToBoard(player);
            Console.Clear();
            player.Move(lastInput);
            snakeBoard.PrintBoard();
        }

        /// <summary>
        /// Returns the GameOver variable. 
        /// </summary>
        /// <returns></returns>
        public bool IsGameOver()
        {
            return GameOver;
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
        public void ShowMainMenu(int option = 1)
        {
            // Switch case to display menu with highlighted option.
            switch (option)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("=========================================================================================");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                              WELCOME TO SNAKE GAME                                    =");
                    Console.WriteLine("=                                       by                                              =");
                    Console.WriteLine("=                                    Calculus                                           =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                      Use the arrow keys to select an option.                          =");
                    Console.WriteLine("=                                                                                       =");
                    Console.Write("=                                  ");
                    Console.ForegroundColor = OptionsColor;
                    Console.Write("1. Play Game");
                    Console.ForegroundColor = ForegroundColor;
                    Console.Write("                                         =\n");
                    Console.WriteLine("=                                  2. Load Game /                                       =");
                    Console.WriteLine("=                                  3. Settings                                          =");
                    Console.WriteLine("=                                  4. Exit                                              =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=========================================================================================");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("=========================================================================================");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                              WELCOME TO SNAKE GAME                                    =");
                    Console.WriteLine("=                                       by                                              =");
                    Console.WriteLine("=                                    Calculus                                           =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                      Use the arrow keys to select an option.                          =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                  1. Play Game                                         =");
                    Console.Write("=                                  ");
                    Console.ForegroundColor = OptionsColor;
                    Console.Write("2. Load Game /");
                    Console.ForegroundColor = ForegroundColor;
                    Console.Write("                                       =\n");    
                    Console.WriteLine("=                                  3. Settings                                          =");
                    Console.WriteLine("=                                  4. Exit                                              =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=========================================================================================");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("=========================================================================================");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                              WELCOME TO SNAKE GAME                                    =");
                    Console.WriteLine("=                                       by                                              =");
                    Console.WriteLine("=                                    Calculus                                           =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                      Use the arrow keys to select an option.                          =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                  1. Play Game                                         =");
                    Console.WriteLine("=                                  2. Load Game /                                       =");
                    Console.Write("=                                  ");
                    Console.ForegroundColor = OptionsColor;
                    Console.Write("3. Settings");
                    Console.ForegroundColor = ForegroundColor;
                    Console.Write("                                          =\n");
                    Console.WriteLine("=                                  4. Exit                                              =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=========================================================================================");
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("=========================================================================================");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                              WELCOME TO SNAKE GAME                                    =");
                    Console.WriteLine("=                                       by                                              =");
                    Console.WriteLine("=                                    Calculus                                           =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                      Use the arrow keys to select an option.                          =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                  1. Play Game                                         =");
                    Console.WriteLine("=                                  2. Load Game /                                       =");
                    Console.WriteLine("=                                  3. Settings                                          =");
                    Console.Write("=                                  ");
                    Console.ForegroundColor = OptionsColor;
                    Console.Write("4. Exit");
                    Console.ForegroundColor = ForegroundColor;
                    Console.Write("                                              =\n");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=========================================================================================");
                    break;
                default:
                    break;
            }

            ResetInput();
            // Getting User Input (Up and down arrow).
            while (input.ToLower() != "enter")
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                string keyStr = keyInfo.Key.ToString();

                switch (keyStr.ToLower())
                {
                    case "uparrow":
                        if (option == 1)
                            option = 4;
                        else
                            option--;
                        ShowMainMenu(option);
                        break;
                    case "downarrow":
                        if (option == 4)
                            option = 1;
                        else
                            option++;
                        ShowMainMenu(option);
                        break;
                    case "enter":
                        input = "enter";
                        Console.Clear();
                        switch (option)
                        {
                            case 1:
                                StartGame();
                                break;
                            case 2:

                                break;
                            case 3:
                                ShowSettings(1);
                                break;
                            case 4:
                                Console.WriteLine("Bye Bye");
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        // ShowMainMenu(option);
                        // Console.WriteLine("\nPlease use the arrow keys to go though the options\nand press enter to select an option.");
                        break;
                }
            }
        }

        /// <summary>
        /// This method shows the Settings Screen.
        /// </summary>
        public void ShowSettings(int option = 1)
        {
            // Switch statement to show highlighted option
            switch (option)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("=========================================================================================");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                    SETTINGS                                           =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=              Please select an option using the arrow keys and press enter             =");
                    Console.WriteLine("=                                                                                       =");
                    Console.Write("=                             ");
                    Console.ForegroundColor = OptionsColor;
                    Console.Write("1. Change Difficulty /");
                    Console.ForegroundColor = ForegroundColor;
                    Console.Write("                                    =\n");
                    Console.WriteLine("=                             2. Change Foreground Color /                              =");
                    Console.WriteLine("=                             3. Change Background Color /                              =");
                    Console.WriteLine("=                             4. Change Player Character /                              =");
                    Console.WriteLine("=                             5. Change Fruit Character /                               =");
                    Console.WriteLine("=                             6. Change Player Name /                                   =");
                    Console.WriteLine("=                             7. Import Settings /                                      =");
                    Console.WriteLine("=                             8. Resize Window /                                        =");
                    Console.WriteLine("=                             9. Resize Board /                                         =");
                    Console.WriteLine("=                             10. Back to Main Menu                                     =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=========================================================================================");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("=========================================================================================");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                    SETTINGS                                           =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=              Please select an option using the arrow keys and press enter             =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                             1. Change Difficulty /                                    =");
                    Console.Write("=                             ");
                    Console.ForegroundColor = OptionsColor;
                    Console.Write("2. Change Foreground Color /");
                    Console.ForegroundColor = ForegroundColor;
                    Console.Write("                              =\n");
                    Console.WriteLine("=                             3. Change Background Color /                              =");
                    Console.WriteLine("=                             4. Change Player Character /                              =");
                    Console.WriteLine("=                             5. Change Fruit Character /                               =");
                    Console.WriteLine("=                             6. Change Player Name /                                   =");
                    Console.WriteLine("=                             7. Import Settings /                                      =");
                    Console.WriteLine("=                             8. Resize Window /                                        =");
                    Console.WriteLine("=                             9. Resize Board /                                         =");
                    Console.WriteLine("=                             10. Back to Main Menu                                     =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=========================================================================================");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("=========================================================================================");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                    SETTINGS                                           =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=              Please select an option using the arrow keys and press enter             =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                             1. Change Difficulty /                                    =");
                    Console.WriteLine("=                             2. Change Foreground Color /                              =");
                    Console.Write("=                             ");
                    Console.ForegroundColor = OptionsColor;
                    Console.Write("3. Change Background Color /");
                    Console.ForegroundColor = ForegroundColor;
                    Console.Write("                              =\n");
                    Console.WriteLine("=                             4. Change Player Character /                              =");
                    Console.WriteLine("=                             5. Change Fruit Character /                               =");
                    Console.WriteLine("=                             6. Change Player Name /                                   =");
                    Console.WriteLine("=                             7. Import Settings /                                      =");
                    Console.WriteLine("=                             8. Resize Window /                                        =");
                    Console.WriteLine("=                             9. Resize Board /                                         =");
                    Console.WriteLine("=                             10. Back to Main Menu                                     =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=========================================================================================");
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("=========================================================================================");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                    SETTINGS                                           =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=              Please select an option using the arrow keys and press enter             =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                             1. Change Difficulty /                                    =");
                    Console.WriteLine("=                             2. Change Foreground Color /                              =");
                    Console.WriteLine("=                             3. Change Background Color /                              =");
                    Console.Write("=                             ");
                    Console.ForegroundColor = OptionsColor;
                    Console.Write("4. Change Player Character /");
                    Console.ForegroundColor = ForegroundColor;
                    Console.Write("                              =\n");
                    Console.WriteLine("=                             5. Change Fruit Character /                               =");
                    Console.WriteLine("=                             6. Change Player Name /                                   =");
                    Console.WriteLine("=                             7. Import Settings /                                      =");
                    Console.WriteLine("=                             8. Resize Window /                                        =");
                    Console.WriteLine("=                             9. Resize Board /                                         =");
                    Console.WriteLine("=                             10. Back to Main Menu                                     =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=========================================================================================");
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("=========================================================================================");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                    SETTINGS                                           =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=              Please select an option using the arrow keys and press enter             =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                             1. Change Difficulty /                                    =");
                    Console.WriteLine("=                             2. Change Foreground Color /                              =");
                    Console.WriteLine("=                             3. Change Background Color /                              =");
                    Console.WriteLine("=                             4. Change Player Character /                              =");
                    Console.Write("=                             ");
                    Console.ForegroundColor = OptionsColor;
                    Console.Write("5. Change Fruit Character /");
                    Console.ForegroundColor = ForegroundColor;
                    Console.Write("                               =\n");
                    Console.WriteLine("=                             6. Change Player Name /                                   =");
                    Console.WriteLine("=                             7. Import Settings /                                      =");
                    Console.WriteLine("=                             8. Resize Window /                                        =");
                    Console.WriteLine("=                             9. Resize Board /                                         =");
                    Console.WriteLine("=                             10. Back to Main Menu                                     =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=========================================================================================");
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("=========================================================================================");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                    SETTINGS                                           =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=              Please select an option using the arrow keys and press enter             =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                             1. Change Difficulty /                                    =");
                    Console.WriteLine("=                             2. Change Foreground Color /                              =");
                    Console.WriteLine("=                             3. Change Background Color /                              =");
                    Console.WriteLine("=                             4. Change Player Character /                              =");
                    Console.WriteLine("=                             5. Change Fruit Character /                               =");
                    Console.Write("=                             ");
                    Console.ForegroundColor = OptionsColor;
                    Console.Write("6. Change Player Name /");
                    Console.ForegroundColor = ForegroundColor;
                    Console.Write("                                   =\n");
                    Console.WriteLine("=                             7. Import Settings /                                      =");
                    Console.WriteLine("=                             8. Resize Window /                                        =");
                    Console.WriteLine("=                             9. Resize Board /                                         =");
                    Console.WriteLine("=                             10. Back to Main Menu                                     =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=========================================================================================");
                    break;
                case 7:
                    Console.Clear();
                    Console.WriteLine("=========================================================================================");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                    SETTINGS                                           =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=              Please select an option using the arrow keys and press enter             =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                             1. Change Difficulty /                                    =");
                    Console.WriteLine("=                             2. Change Foreground Color /                              =");
                    Console.WriteLine("=                             3. Change Background Color /                              =");
                    Console.WriteLine("=                             4. Change Player Character /                              =");
                    Console.WriteLine("=                             5. Change Fruit Character /                               =");
                    Console.WriteLine("=                             6. Change Player Name /                                   =");
                    Console.Write("=                             ");
                    Console.ForegroundColor = OptionsColor;
                    Console.Write("7. Import Settings /");
                    Console.ForegroundColor = ForegroundColor;
                    Console.Write("                                      =\n");
                    Console.WriteLine("=                             8. Resize Window /                                        =");
                    Console.WriteLine("=                             9. Resize Board /                                         =");
                    Console.WriteLine("=                             10. Back to Main Menu                                     =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=========================================================================================");
                    break;
                case 8:
                    Console.Clear();
                    Console.WriteLine("=========================================================================================");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                    SETTINGS                                           =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=              Please select an option using the arrow keys and press enter             =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                             1. Change Difficulty /                                    =");
                    Console.WriteLine("=                             2. Change Foreground Color /                              =");
                    Console.WriteLine("=                             3. Change Background Color /                              =");
                    Console.WriteLine("=                             4. Change Player Character /                              =");
                    Console.WriteLine("=                             5. Change Fruit Character /                               =");
                    Console.WriteLine("=                             6. Change Player Name /                                   =");
                    Console.WriteLine("=                             7. Import Settings /                                      =");
                    Console.Write("=                             ");
                    Console.ForegroundColor = OptionsColor;
                    Console.Write("8. Resize Window /");
                    Console.ForegroundColor = ForegroundColor;
                    Console.Write("                                        =\n");
                    Console.WriteLine("=                             9. Resize Board /                                         =");
                    Console.WriteLine("=                             10. Back to Main Menu                                     =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=========================================================================================");
                    break;
                case 9:
                    Console.Clear();
                    Console.WriteLine("=========================================================================================");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                    SETTINGS                                           =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=              Please select an option using the arrow keys and press enter             =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                             1. Change Difficulty /                                    =");
                    Console.WriteLine("=                             2. Change Foreground Color /                              =");
                    Console.WriteLine("=                             3. Change Background Color /                              =");
                    Console.WriteLine("=                             4. Change Player Character /                              =");
                    Console.WriteLine("=                             5. Change Fruit Character /                               =");
                    Console.WriteLine("=                             6. Change Player Name /                                   =");
                    Console.WriteLine("=                             7. Import Settings /                                      =");
                    Console.WriteLine("=                             8. Resize Window /                                        =");
                    Console.Write("=                             ");
                    Console.ForegroundColor = OptionsColor;
                    Console.Write("9. Resize Board /");
                    Console.ForegroundColor = ForegroundColor;
                    Console.Write("                                         =\n");
                    Console.WriteLine("=                             10. Back to Main Menu                                     =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=========================================================================================");
                    break;
                case 10:
                    Console.Clear();
                    Console.WriteLine("=========================================================================================");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                    SETTINGS                                           =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=              Please select an option using the arrow keys and press enter             =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                             1. Change Difficulty /                                    =");
                    Console.WriteLine("=                             2. Change Foreground Color /                              =");
                    Console.WriteLine("=                             3. Change Background Color /                              =");
                    Console.WriteLine("=                             4. Change Player Character /                              =");
                    Console.WriteLine("=                             5. Change Fruit Character /                               =");
                    Console.WriteLine("=                             6. Change Player Name /                                   =");
                    Console.WriteLine("=                             7. Import Settings /                                      =");
                    Console.WriteLine("=                             8. Resize Window /                                        =");
                    Console.WriteLine("=                             9. Resize Board /                                         =");
                    Console.Write("=                             ");
                    Console.ForegroundColor = OptionsColor;
                    Console.Write("10. Back to Main Menu");
                    Console.ForegroundColor = ForegroundColor;
                    Console.Write("                                     =\n");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=========================================================================================");
                    break;
                default:
                    break;


            }

            ResetInput();
            // Getting User Input (Up and down arrow).
            while (input.ToLower() != "enter")
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                string keyStr = keyInfo.Key.ToString();

                // Check if up or down arrow was clicked.
                switch (keyStr.ToLower())
                {
                    case "uparrow":
                        if (option == 1)
                            option = 10;
                        else
                            option--;
                        ShowSettings(option);
                        break;
                    case "downarrow":
                        if (option == 10)
                            option = 1;
                        else
                            option++;
                        ShowSettings(option);
                        break;
                    case "enter":
                        input = "enter";
                        Console.Clear();

                        // Switch statement to check which option was entered and run it.
                        switch (option)
                        {
                            case 1:
                                
                                break;
                            case 2:

                                break;
                            case 3:
                                
                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                            case 6:
                                break;
                            case 7:
                                
                                break;
                            case 8:
                                
                                break;
                            case 9:
                                
                                break;
                            case 10:
                                ShowMainMenu(3);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        // ShowMainMenu(option);
                        // Console.WriteLine("\nPlease use the arrow keys to go though the options\nand press enter to select an option.");
                        break;
                }
            }
        }

        public void ShowGameOver(int option = 1)
        {
            // Switch statement to show highlighted option.
            switch (option)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("=========================================================================================");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                   GAME OVER                                           =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                        {0}, you ate {1} fruits. HighScore is {2}                      =", player.playerName, CurrentScore, HighScore);
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                             Please select an option:                                  =");
                    Console.WriteLine("=                                                                                       =");
                    Console.Write("=                                  ");
                    Console.ForegroundColor = OptionsColor;
                    Console.Write("1. Play Again");
                    Console.ForegroundColor = ForegroundColor;
                    Console.Write("                                        =\n");
                    Console.WriteLine("=                                  2. Load Game /                                       =");
                    Console.WriteLine("=                                  3. Settings                                          =");
                    Console.WriteLine("=                                  4. Exit                                              =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=========================================================================================");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("=========================================================================================");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                   GAME OVER                                           =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                        {0}, you ate {1} fruits. HighScore is {2}                      =", player.playerName, CurrentScore, HighScore);
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                             Please select an option:                                  =");
                    Console.WriteLine("=                                                                                       =");                    
                    Console.WriteLine("=                                  1. Play Again                                        =");
                    Console.Write("=                                  ");
                    Console.ForegroundColor = OptionsColor;
                    Console.Write("2. Load Game /");
                    Console.ForegroundColor = ForegroundColor;
                    Console.Write("                                       =\n");
                    Console.WriteLine("=                                  3. Settings                                          =");
                    Console.WriteLine("=                                  4. Exit                                              =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=========================================================================================");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("=========================================================================================");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                   GAME OVER                                           =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                        {0}, you ate {1} fruits. HighScore is {2}                      =", player.playerName, CurrentScore, HighScore);
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                             Please select an option:                                  =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                  1. Play Again                                        =");
                    Console.WriteLine("=                                  2. Load Game /                                       =");
                    Console.Write("=                                  ");
                    Console.ForegroundColor = OptionsColor;
                    Console.Write("3. Settings");
                    Console.ForegroundColor = ForegroundColor;
                    Console.Write("                                          =\n");
                    Console.WriteLine("=                                  4. Exit                                              =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=========================================================================================");
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("=========================================================================================");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                   GAME OVER                                           =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                        {0}, you ate {1} fruits. HighScore is {2}                      =", player.playerName, CurrentScore, HighScore);
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                             Please select an option:                                  =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                  1. Play Again                                        =");
                    Console.WriteLine("=                                  2. Load Game /                                       =");
                    Console.WriteLine("=                                  3. Settings                                          =");
                    Console.Write("=                                  ");
                    Console.ForegroundColor = OptionsColor;
                    Console.Write("4. Exit");
                    Console.ForegroundColor = ForegroundColor;
                    Console.Write("                                              =\n");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=                                                                                       =");
                    Console.WriteLine("=========================================================================================");
                    break;
                default:
                    break;
            }


            ResetInput();
            // Getting User Input (Up and down arrow).
            while (input.ToLower() != "enter")
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                string keyStr = keyInfo.Key.ToString();

                switch (keyStr.ToLower())
                {
                    case "uparrow":
                        if (option == 1)
                            option = 4;
                        else
                            option--;
                        ShowGameOver(option);
                        break;
                    case "downarrow":
                        if (option == 4)
                            option = 1;
                        else
                            option++;
                        ShowGameOver(option);
                        break;
                    case "enter":
                        input = "enter";
                        Console.Clear();
                        switch (option)
                        {
                            case 1:
                                StartGame();
                                break;
                            case 2:

                                break;
                            case 3:
                                ShowSettings();
                                break;
                            case 4:
                                Console.WriteLine("Bye Bye");
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        // ShowMainMenu(option);
                        // Console.WriteLine("\nPlease use the arrow keys to go though the options\nand press enter to select an option.");
                        break;
                }
            }

        }

        /// <summary>
        /// Method used to get user input and validate that it's an integer.
        /// (Old way to get user input)
        /// </summary>
        private int GetUserInput()
        {
            int input = 0;
            string message = "Option: ";
            while(true)
            {
                Console.Write(message);
                string strInput = Console.ReadLine();
                if(Int32.TryParse(strInput, out int numInput))
                {
                    input = numInput;
                    break;
                } else
                {
                    message = "Please enter the correct option: ";
                }
            }

            return input;
        }


        /// <summary>
        /// Resets the game's input.
        /// </summary>
        private void ResetInput()
        {
            input = "";
        }
    }
}
