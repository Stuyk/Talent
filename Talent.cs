using System;
using GTANetworkAPI;

namespace Talent
{
    public class Talent : Script
    {
        public Talent()
        {
            Settings.Initialze();
        }

        [ServerEvent(Event.PlayerSpawn)]
        public void OnPlayerSpawn(Client client)
        {
            // Load player sheets.
            if (!Settings.LoadSheetsOnJoin)
                return;

            // Create a new sheet for the client.
            TalentScoresheet sheet = new TalentScoresheet(client);

            if (!Settings.AssignRandomStats)
                return;

            // Setup randomized stats for the player and save it to the database.
            sheet.Charisma = CharacterGen.GenerateModifier();
            sheet.Strength = CharacterGen.GenerateModifier();
            sheet.Intelligence = CharacterGen.GenerateModifier();
            sheet.Endurance = CharacterGen.GenerateModifier();
            sheet.SaveScoresheet();
        }
    }
}