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
            TalentScoresheet sheet = new TalentScoresheet(client);

            if (!Settings.AssignRandomStats)
                return;

            sheet.Charisma = CharacterGen.GenerateModifier();
            sheet.Strength = CharacterGen.GenerateModifier();
            sheet.Intelligence = CharacterGen.GenerateModifier();
            sheet.Endurance = CharacterGen.GenerateModifier();
            sheet.SaveScoresheet();
        }
    }
}