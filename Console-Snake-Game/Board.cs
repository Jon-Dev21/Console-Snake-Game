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
        public int Rows { get; set; }
        public int Columns { get; set; }

        public static string boardStr = "";

        /// <summary>
        /// Board 2d string array used as the game grid.
        /// </summary>
        public string[,] board;

        public int oldPlayerX;
        public int oldPlayerY;

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
            if (player.playerBody.Length == 1)
            {
                // Delete old space
                board[player.playerBody[0].OldPlayerX, player.playerBody[0].OldPlayerY] = " ";

                // Update OldPlayer X and Y
                player.playerBody[0].OldPlayerX = player.playerBody[0].playerX;
                player.playerBody[0].OldPlayerY = player.playerBody[0].playerY;

                // Add new symbol
                board[player.playerBody[0].playerX, player.playerBody[0].playerY] = player.playerBody[0].playerSymbol.ToString();
                
            }
            
        }

        public bool IsWallHit()
        {
            if (true)
            {

            }
            return false;
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
    }
}
