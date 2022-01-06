using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Console_Snake_Game
{
    class Board
    {
        /// <summary>
        /// Number of rows for the game grid.
        /// </summary>
        public int Rows { get; set; }

        /// <summary>
        /// Number of columns for the game grid.
        /// </summary>
        public int Columns { get; set; }

        /// <summary>
        /// Boolian variable to indicate if the player hit the wall.
        /// </summary>
        private bool WallHit = false;

        /// <summary>
        /// A string to hold in the saveState of the game.
        /// </summary>
        public static string boardStr = "";

        /// <summary>
        /// Board 2d string array used as the game grid.
        /// </summary>
        public string[,] board;

        /// <summary>
        /// Board Constructor.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public Board(int rows, int columns)
        {
            board = new string[rows, columns];
            Rows = rows;
            Columns = columns;
        }

        /// <summary>
        /// This method creates the snake game board.
        /// </summary>
        public void CreateBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    // If the row is the first or the last row
                    if (i == 0 || i + 1 == board.GetLength(0))
                    {
                        board[i, j] = "=";
                        boardStr += "= ";
                        if (j + 1 == board.GetLength(1))
                        {
                            boardStr += "\n";
                        }
                    }
                    else if (j == 0 || j + 1 == board.GetLength(1))
                    {
                        // if the column is the first or last one, set the symbol to =.
                        board[i, j] = "=";

                        // If it's the last column, add a new line.
                        if (j + 1 == board.GetLength(1))
                        {
                            boardStr += "=\n";
                        }
                        else
                        {
                            boardStr += "= ";
                        }
                    }
                    else
                    {
                        board[i, j] = " ";
                        boardStr += "  ";
                    }

                }
            }
        }

        /// <summary>
        /// This method prints the board in the screen.
        /// </summary>
        public void PrintBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void Test_PrintPlayerOnly(Player p)
        {
            if (p.playerBody.Length == 1)
            {
                // Delete old space
                board[p.playerBody[0].OldX, p.playerBody[0].OldY] = " ";

                // Update OldPlayer X and Y
                p.playerBody[0].OldX = p.playerBody[0].X;
                p.playerBody[0].OldY = p.playerBody[0].Y;

                // Add new symbol
                board[p.playerBody[0].X, p.playerBody[0].Y] = p.playerBody[0].playerSymbol.ToString();

            }
        }

        /// <summary>
        /// Saves the current board state into the boardStr.
        /// </summary>
        public void SaveBoard()
        {
            boardStr = "";
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    // If the row is the first or the last row
                    if (i == 0 || i + 1 == board.GetLength(0))
                    {
                        boardStr += "= ";
                        if (j + 1 == board.GetLength(1))
                        {
                            boardStr += "\n";
                        }
                    }
                    else if (j == 0 || j + 1 == board.GetLength(1))
                    {
                        // If it's the last column, add a new line.
                        if (j + 1 == board.GetLength(1))
                        {
                            boardStr += "=\n";
                        }
                        else
                        {
                            // If it's the first column, just add a border.
                            boardStr += "= ";
                        }
                    }
                    else
                    {
                        boardStr += board[i, j] + " ";
                    }

                }
            }

            string[] lines = boardStr.Split("\n");
            File.WriteAllLines(@"", lines);

        }

        /// <summary>
        /// Adds a player to the current coordinate that the player is at.
        /// </summary>
        /// <param name="player"></param>
        public void AddPlayerToBoard(Player player)
        {
            // Handling player with only snake head.
            if (player.playerBody.Length == 1)
            {
                Console.WriteLine("PLAYER X: {0}\nPLAYER Y: {1}", player.playerBody[0].X, player.playerBody[0].Y);
                Console.WriteLine("\nROWS: {0}\nCOLUMNS: {1}", Rows, Columns);


                CheckIsWallHit(player);
            }
            
        }

        /// <summary>
        /// Adds a fruit at a random spot in the board.
        /// </summary>
        /// <param name="fruit"></param>
        public void AddFruitToBoard(Fruit fruit)
        {
            Random rand = new Random();
            fruit.FruitX = rand.Next(2, Rows-1);
            fruit.FruitY = rand.Next(2, Columns-1);
            board[fruit.FruitX, fruit.FruitY] = fruit.FruitSymbol;
        }

        public bool AteFruit(Player p, Fruit f)
        {
            return p.playerBody[0].X == f.FruitX && p.playerBody[0].Y == f.FruitY;
        }

        ///// <summary>
        ///// Creates the board's rows.
        ///// </summary>
        ///// <param name="rows"></param>
        //private void CreateRows(int rows = 12)
        //{
        //    string rowSymbol = "=";
        //    string rowString = "";

        //    for (int i = 0; i < rows; i++)
        //    {
        //        rowString += rowSymbol;
        //        board[0, i] = rowSymbol;
        //    }
        //    boardStr += rowString+"\n";
        //}

        ///// <summary>
        ///// Method creates the board's column.
        ///// </summary>
        ///// <param name="columns"></param>
        //private void CreateColumns(int columns = 12)
        //{
        //    string colEdge = "=";
        //    string colSymbol = " ";
        //    string colString = "";

        //    for (int i = 0; i < columns; i++)
        //    {
        //        if(i == 0 || i+1==columns)
        //        {
        //            colString += colEdge;
        //        } else
        //        {
        //            colString += colSymbol;
        //        }
        //    }
        //    boardStr += colString;
        //}

        /// <summary>
        /// Method used to return the board string. Board string is created in the timer elapsed method which executes each time the timer ends.
        /// </summary>
        /// <returns></returns>
        public string GetBoardString()
        {
            return boardStr;
        }

        public bool IsWallHit()
        {
            return WallHit;
        }

        public bool ResetWallHit()
        {
            return WallHit = false;
        }

        /// <summary>
        /// Checks if the player hit the wall.
        /// Constantly updates the WallHit variable.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        private bool CheckIsWallHit(Player player)
        {
            // If the player hasn't crashed with a wall
            if (player.playerBody[0].X < Rows - 1 && player.playerBody[0].Y < Columns - 1 && player.playerBody[0].X > 0 && player.playerBody[0].Y > 0)
            {
                // Delete old space
                board[player.playerBody[0].OldX, player.playerBody[0].OldY] = " ";

                // Update OldPlayer X and Y
                player.playerBody[0].OldX = player.playerBody[0].X;
                player.playerBody[0].OldY = player.playerBody[0].Y;

                // Add new symbol
                board[player.playerBody[0].X, player.playerBody[0].Y] = player.playerBody[0].playerSymbol.ToString();
            }
            else
            {
                WallHit = true;
            }

            return WallHit;
        }
    }
}
