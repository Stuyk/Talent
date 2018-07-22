using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Talent
{
    public class TalentScoresheet
    {
        public int ID { get; set; }
        public string PlayerName { get; set; }
        public int Endurance { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }
        public int Strength { get; set; }

        public TalentScoresheet() { }

        public TalentScoresheet(Client client)
        {
            PlayerName = client.Name;
            client.SetData("TalentScoresheet", this);
        }

        public void AddSheetToPlayer(Client client)
        {
            client.SetData("TalentScoresheet", this);
        }

        public void SaveScoresheet()
        {
            if (Database.Get(PlayerName) != null)
                ID = Database.Get(PlayerName).ID;

            Database.Add(this);
        }

        /// <summary>
        /// Return the player's true endurance talent score.
        /// </summary>
        /// <returns></returns>
        public int GetEndScore()
        {
            return Endurance / Settings.TalentDivision;
        }

        /// <summary>
        /// Return the player's true intelligence talent score.
        /// </summary>
        /// <returns></returns>
        public int GetIntScore()
        {
            return Intelligence / Settings.TalentDivision;
        }

        /// <summary>
        /// Return the player's true charisma talent score.
        /// </summary>
        /// <returns></returns>
        public int GetChaScore()
        {
            return Charisma / Settings.TalentDivision;
        }

        /// <summary>
        /// Return the player's true strength talent score.
        /// </summary>
        /// <returns></returns>
        public int GetStrScore()
        {
            return Strength / Settings.TalentDivision;
        }
    }
}
