using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Talent
{
    public class Commands : Script
    {
        [Command("talentsheet")]
        public void SkillCheck(Client client)
        {
            if (!client.HasData("TalentScoresheet"))
                return;

            TalentScoresheet sheet = client.GetData("TalentScoresheet") as TalentScoresheet;
            client.SendChatMessage($"=== ~b~SHEET ~w~===");
            client.SendChatMessage($"~g~END: ~w~{sheet.Endurance} > +{sheet.GetEndScore()} Modifier");
            client.SendChatMessage($"~r~STR: ~w~{sheet.Strength} > +{sheet.GetStrScore()} Modifier");
            client.SendChatMessage($"~b~INT: ~w~{sheet.Intelligence} > +{sheet.GetIntScore()} Modifier");
            client.SendChatMessage($"~o~CHA: ~w~{sheet.Charisma} > +{sheet.GetChaScore()} Modifier");
        }
    }
}
