using System;
using GTANetworkAPI;

namespace talent
{
    public class Main : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void ResourceStart()
        {
            NAPI.Util.ConsoleOutput("Hello World!");
        }
    }
}