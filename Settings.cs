using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Talent
{
    public class Settings
    {
        [JsonProperty("TalentDivision")]
        public static int TalentDivision { get; set; } = 3;
        [JsonProperty("AssignRandomStats")]
        public static bool AssignRandomStats { get; set; } = false;
        [JsonProperty("LoadSheetsOnJoin")]
        public static bool LoadSheetsOnJoin { get; set; } = false;
        [JsonProperty("DisableCommands")]
        public static bool DisableCommands { get; set; } = false;
        [JsonProperty("DatabaseLocation")]
        public static string DatabaseLocation { get; set; } = @".\bridge\talent";
        [JsonProperty("DatabaseName")]
        public static string DatabaseFile { get; set; } = @"\talent.db";

        public static void Initialze()
        {
            if (!Directory.Exists(DatabaseLocation))
                Directory.CreateDirectory(DatabaseLocation);

            if (!File.Exists(DatabaseLocation + @"\settings.json"))
            {
                SettingsHelper.SaveSettings();
                Console.WriteLine("[Talent] Settings not found. Generating default.");
                Console.WriteLine($"Location: {DatabaseLocation}");
            }

            SettingsHelper.LoadSettings();
            Console.WriteLine("[Talent] Settings found, reading settings.");
        }
    }

    public class SettingsHelper
    {
        public static Settings Settings = new Settings();

        public static void SaveSettings()
        {
            string serialize = JsonConvert.SerializeObject(Settings, Formatting.Indented);
            File.WriteAllText(Settings.DatabaseLocation + @"\settings.json", serialize);
        }

        public static void LoadSettings()
        {
            string deserialize = File.ReadAllText(Settings.DatabaseLocation + @"\settings.json");
            Settings = JsonConvert.DeserializeObject<Settings>(deserialize);
        }
    }
}
