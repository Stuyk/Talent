using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Talent
{
    public static class CharacterGen
    {
        /// <summary>
        /// Returns a new modifier number that is correctly calculated.
        /// </summary>
        /// <returns></returns>
        public static int GenerateModifier()
        {
            int modifier = 0;

            for (var i = 0; i < 3; i++)
            {
                modifier += Dice.RollDice(6);
            }

            return modifier;
        }

        /// <summary>
        /// Setup a new sheet for the player. If you want to randomize it set the last parameter to true and the others to 0s.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="strength"></param>
        /// <param name="intelligence"></param>
        /// <param name="endurance"></param>
        /// <param name="charisma"></param>
        /// <param name="randomize"></param>
        /// <returns></returns>
        public static TalentScoresheet SetupNewSheet(Client client, int strength, int intelligence, int endurance, int charisma, bool randomize = false)
        {
            TalentScoresheet sheet = new TalentScoresheet(client);

            if (randomize)
                return sheet;

            sheet.Strength = strength;
            sheet.Intelligence = intelligence;
            sheet.Endurance = endurance;
            sheet.Charisma = charisma;

            return sheet;
        }

        /// <summary>
        /// Load the TalentSheet from the database.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static TalentScoresheet LoadTalentSheet(Client client)
        {
            TalentScoresheet talentScoresheet = Database.Get(client.Name);
            talentScoresheet.AddSheetToPlayer(client);
            return talentScoresheet;
        }
    }
}
