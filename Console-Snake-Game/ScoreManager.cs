using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Console_Snake_Game
{
    /// <summary>
    /// This class is used to access the game score. (SAVE, LOAD)
    /// Score is held in a .csv file. Each record contains a player, 
    /// it's symbol and high score.
    /// </summary>
    class ScoreManager
    {
        string URL;
        private ScoreData scoreData;
        /// <summary>
        /// Array of records
        /// </summary>
        public string[] scoreDataRecord;

        public ScoreManager(string url)
        {
            URL = url;
            scoreData = new ScoreData();
            scoreDataRecord = new string[1];
        }

        /// <summary>
        /// Writes the score record into the score csv file.
        /// </summary>
        public void WriteRecord()
        {
            File.AppendAllLines(URL, scoreDataRecord);
        }

        /// <summary>
        /// Sets the record of the passed player.
        /// </summary>
        /// <param name="p"></param>
        public void SetHighScore(Player p)
        {
            scoreData.PlayerName = p.playerName;
            scoreData.PlayerChar = p.playerBody[0].playerSymbol;
            scoreData.Score = p.playerHighScore;
            scoreDataRecord[0] = $"{scoreData.PlayerName}, {scoreData.PlayerChar}, {scoreData.Score}";
        }
    }
}
