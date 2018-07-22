using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Talent
{
    public class TalentScoresheet
    {
        public int Endurance { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }
        public int Strength { get; set; }
        public Client Client { get; set; }

        public TalentScoresheet(Client client, bool randomizeSheet = false)
        {
            Client = client;
            Client.SetData("TalentScoresheet", this);

            if (randomizeSheet)
                RandomizeSheet();
        }

        private void RandomizeSheet()
        {
            int diceroll = 0;

            for (var i = 0; i < 4; i++)
            {
                for (var d = 0; d < 3; d++)
                {
                    diceroll += Dice.RollDice(6);
                }

                switch(i)
                {
                    case 0:
                        Endurance = diceroll;
                        break;
                    case 1:
                        Intelligence = diceroll;
                        break;
                    case 2:
                        Charisma = diceroll;
                        break;
                    case 3:
                        Strength = diceroll;
                        break;
                }

                diceroll = 0;
            }
        }

        public void RetrieveScoresheet()
        {
            // database stuff...
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
