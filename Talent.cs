using System;
using GTANetworkAPI;

namespace Talent
{
    public class Talent : Script
    {
        [ServerEvent(Event.PlayerSpawn)]
        public void OnPlayerSpawn(Client client)
        {
            if (client.HasData("TalentScoresheet"))
                return;

            TalentScoresheet tSheet = new TalentScoresheet(client, true);
        }
    }
}