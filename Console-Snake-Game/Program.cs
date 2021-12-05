using System;
using System.Timers;

namespace Console_Snake_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            SnakeBoard board = new SnakeBoard(12, 12);

            board.CreateBoard();

            Console.WriteLine(board.GetBoardString());
        }
    }
}
