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
        private string lastMove;
        
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
        /// This method moves the player depending on the input.
        /// </summary>
        //public void MovePlayer()
        //{

        //    if (Console.ReadKey().Key == ConsoleKey.W)
        //    {
        //        // Moving Up
        //        MoveUp();
        //    } 
        //    else if (Console.ReadKey().Key == ConsoleKey.S)
        //    {
        //        // Moving Down
        //        MoveDown();
        //    }
        //     else if (Console.ReadKey().Key == ConsoleKey.A)
        //    {
        //        // Console.ReadKey().Key == ConsoleKey.A
        //        // Moving Left
        //        MoveLeft();
        //    }
        //    else if (Console.ReadKey().Key == ConsoleKey.D)
        //    {
        //        // Moving Right
        //        MoveRight();
        //    }
        //    //else
        //    //{
        //    //    Console.WriteLine("I don't know what the kell you pressed.");
        //    //}
        //}

        /// <summary>
        /// Method used to change player coordinates based on keyboard input.
        /// </summary>
        /// <param name="input"></param>
        public void Move(string input)
        {
            if (input.ToLower() == "w" && lastMove != "DOWN")
            {
                // Moving Up
                MoveUp();
                lastMove = "UP";
            }
            else if (input.ToLower() == "s" && lastMove != "UP")
            {
                // Moving Down
                MoveDown();
                lastMove = "DOWN";
            }
            else if (input.ToLower() == "a" && lastMove != "RIGHT")
            {
                // Console.ReadKey().Key == ConsoleKey.A
                // Moving Left
                MoveLeft();
                lastMove = "LEFT";
            }
            else if (input.ToLower() == "d" && lastMove != "LEFT")
            {
                // Moving Right
                MoveRight();
                lastMove = "RIGHT";
            }
            else
            {
                // Make the last move
                switch (lastMove)
                {
                    case "UP":
                        MoveUp();
                        break;
                    case "DOWN":
                        MoveDown();
                        break;
                    case "LEFT":
                        MoveLeft();
                        break;
                    case "RIGHT":
                        MoveRight();
                        break;
                    default:
                        break;
                }
            }
        }

        public void MovePlayerBody()
        {
            //for (int  i= 0; i < playerBody.Length; i++)
            //{
            //    bodyPart.OldX = bodyPart.X;
            //    bodyPart.OldY = bodyPart.Y;
            //    bodyPart.X =
            //}
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
                bodyPart.Y--;
            }
        }

        /// <summary>
        /// y,  x
        /// 0, +1
        /// 
        /// To move right, add 1 to the y value in the array
        /// </summary>
        public void MoveRight()
        {
            foreach (var bodyPart in playerBody)
            {
                bodyPart.Y++;
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
                bodyPart.X--;
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
                bodyPart.X++;
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
        public int X;
        public int Y;
        public int OldX;
        public int OldY;
        public string LastMove;

        public PlayerBody(char pSymbol, int x, int y)
        {
            playerSymbol = pSymbol;
            X = x;
            Y = y;
            OldX = X;
            OldY = Y;
        }
    }
}
