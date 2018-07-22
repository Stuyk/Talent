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
            new TalentScoresheet(client, false);
        }
    }
}