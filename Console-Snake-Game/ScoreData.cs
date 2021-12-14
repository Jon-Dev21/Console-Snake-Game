using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Snake_Game
{
    /// <summary>
    /// Class used to model the score data stored in the .csv file.
    /// </summary>
    class ScoreData
    {
        public string PlayerName { get; set; }
        public char PlayerChar { get; set; }
        public int Score { get; set; }
    }
}
