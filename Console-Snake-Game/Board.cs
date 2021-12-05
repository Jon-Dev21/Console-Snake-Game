using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Console_Snake_Game
{
    class Board
    {
        /// <summary>
        /// GameClock Timer
        /// </summary>
        Timer gameTimer = new Timer(400);
        public int Rows { get; set; }
        public int Columns { get; set; }

        public static int secondsCount = 0;

        public static string boardStr = "";

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            gameTimer.Elapsed += Timer_Elapsed;
            gameTimer.Enabled = true;
            gameTimer.AutoReset = true;
        }

        public void CreateBoard(int rows = 12, int columns = 20)
        {

            //gameTimer.Start();
            //Console.ReadKey();
            for (int i = 0; i < 1; i++)
            {
                Console.Clear();
                Console.WriteLine("============================================================================");

                boardStr += "============================================================================\n";
                for (int j = 0; j < columns; j++)
                {
                    Console.WriteLine("=                                                                          =");
                    boardStr += "=                                                                          =\n";
                }
                Console.WriteLine("============================================================================\n\n");
                boardStr += "============================================================================";
            }


        }

        private void CreateRows(int rows = 12)
        {
            string rowSymbol = "=";
            string rowString = "";

            for (int i = 0; i < rows; i++)
            {
                rowString += rowSymbol;
            }
            boardStr += rowString;
        }

        private void CreateColumns(int columns = 12)
        {
            string rowSymbol = " ";
            string colString = "";

            for (int i = 0; i < columns; i++)
            {
                colString += rowSymbol;
            }
            boardStr += colString;
        }

        /// <summary>
        /// Method used to return the board string. Board string is created in the timer elapsed method which executes each time the timer ends.
        /// </summary>
        /// <returns></returns>
        public string GetBoardString()
        {
            return boardStr;
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            secondsCount++;
            //Console.WriteLine(secondsCount + " Seconds");
            
        }
    }
}
