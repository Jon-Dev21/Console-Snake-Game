using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Snake_Game
{
    class Player
    {
        public PlayerBody[] playerBody;
        public string playerName;
        public bool isAlive;
        public int playerHighScore;
        
        /// <summary>
        /// Player takes in a player name, a player snake symbol, an x coordinate and a y coordinate
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pSymbol"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Player(string pName, char pSymbol, int x, int y)
        {
            playerName = pName;
            playerBody = new PlayerBody[] { new PlayerBody(pSymbol, x,y) };
        }

        /// <summary>
        /// This method moves the player randomly.
        /// </summary>
        public void MovePlayer()
        {
            if (Console.ReadKey().Key == ConsoleKey.W)
            {
                // Moving Up
                MoveUp();
            } 
            else if (Console.ReadKey().Key == ConsoleKey.S)
            {
                // Moving Down
                MoveDown();
            }
             else if (Console.ReadKey().Key == ConsoleKey.A)
            {
                // Moving Left
                MoveLeft();
            }
            else if (Console.ReadKey().Key == ConsoleKey.D)
            {
                // Moving Right
                MoveRight();
            }
            else
            {
                Console.WriteLine("I don't know what the kell you pressed.");
            }
        }


        /// <summary>
        /// y,  x
        /// 0, -1
        /// 
        /// To move left, subtract 1 from the x value in the array
        /// </summary>
        private void MoveLeft()
        {
            foreach (var bodyPart in playerBody)
            {
                bodyPart.playerY--;
            }
        }

        /// <summary>
        /// y,  x
        /// 0, +1
        /// 
        /// To move right, add 1 to the y value in the array
        /// </summary>
        private void MoveRight()
        {
            foreach (var bodyPart in playerBody)
            {
                bodyPart.playerY++;
            }
        }

        /// <summary>
        ///  y,  x
        /// -1,  0
        /// 
        /// To move up, subtract 1 from the x value in the array
        /// </summary>
        private void MoveUp()
        {
            foreach (var bodyPart in playerBody)
            {
                bodyPart.playerX--;
            }
        }

        /// <summary>
        ///  y,  x
        /// +1,  0
        /// 
        /// To move down, add 1 to the x value in the array
        /// </summary>
        private void MoveDown()
        {
            foreach (var bodyPart in playerBody)
            {
                bodyPart.playerX++;
            }
        }


    }
    
    /// <summary>
    /// PlayerBody represents a body part of the snake.
    /// It has a symbol as well as an x and y coordinate representing where that body part is.
    /// </summary>
    class PlayerBody
    {
        public char playerSymbol;
        public int playerX;
        public int playerY;
        public int OldPlayerX;
        public int OldPlayerY;


        public PlayerBody(char pSymbol, int x, int y)
        {
            playerSymbol = pSymbol;
            playerX = x;
            playerY = y;
            OldPlayerX = playerX;
            OldPlayerY = playerY;
        }
    }
}
