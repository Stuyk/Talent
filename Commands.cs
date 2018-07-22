using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Talent
{
    public class Commands : Script
    {
        [Command("checksheet")]
        public void SkillCheck(Client client)
        {
            if (Settings.DisableCommands)
                return;

            if (!client.HasData("TalentScoresheet"))
                return;

            TalentScoresheet sheet = client.GetData("TalentScoresheet") as TalentScoresheet;
            client.SendChatMessage($"=== ~b~SHEET ~w~===");
            client.SendChatMessage($"~g~END: ~w~{sheet.Endurance} > +{sheet.GetEndScore()} Modifier");
            client.SendChatMessage($"~r~STR: ~w~{sheet.Strength} > +{sheet.GetStrScore()} Modifier");
            client.SendChatMessage($"~b~INT: ~w~{sheet.Intelligence} > +{sheet.GetIntScore()} Modifier");
            client.SendChatMessage($"~o~CHA: ~w~{sheet.Charisma} > +{sheet.GetChaScore()} Modifier");
        }

        [Command("loadsheet")]
        public void GetTalentSheet(Client client)
        {
            if (Settings.DisableCommands)
                return;

            CharacterGen.LoadTalentSheet(client);
            client.SendChatMessage("[Talent] Loaded. Use /checksheet");
        }

        [Command("savesheet")]
        public void SaveTalentSheet(Client client)
        {
            if (Settings.DisableCommands)
                return;

            if (!client.HasData("TalentScoresheet"))
                return;

            TalentScoresheet sheet = client.GetData("TalentScoresheet") as TalentScoresheet;
            sheet.SaveScoresheet();
            client.SendChatMessage("[Talent] Saved. Use /checksheet");
        }

        [Command("newsheet")]
        public void GetNewTalentSheet(Client client)
        {
            if (Settings.DisableCommands)
                return;

            CharacterGen.SetupNewSheet(client, 0, 0, 0, 0, true, true);
            client.SendChatMessage("[Talent] Created and Saved Talent Sheet. Use /checksheet");
        }
    }
}
