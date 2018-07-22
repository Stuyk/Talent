using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Talent
{
    public class Settings
    {
        [JsonProperty("TalentDivision")]
        public static int TalentDivision { get; set; } = 3;
        [JsonProperty("AssignRandomStats")]
        public static bool AssignRandomStats { get; set; } = false;
        [JsonProperty("DisableCommands")]
        public static bool DisableCommands { get; set; } = false;
    }
}
