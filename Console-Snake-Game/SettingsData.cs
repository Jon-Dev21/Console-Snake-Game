using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Snake_Game
{
    /// <summary>
    /// Class used to model the .csv data that is being used as the game settings.
    /// </summary>
    class SettingsData
    {
        public string ConsoleBackgroundColor { get; set; }
        public string ConsoleTextColor { get; set; }
        public int FontSize { get; set; }
        public string Difficulty { get; set; }
        public string Language { get; set; } // English and spanish for now.
    }
}
