namespace EMS.DataModels.Models
{
    public class AppSettings
    {
        public string Version { get; set; }
        public string LocalizationCode { get; set; }
        public string GameInstallationPath { get; set; }
        public bool CheckForUpdates { get; set; }
        public string SteamUsername { get; set; }
        public string SteamPassword { get; set; }
        public string UpdateChannel { get; set; }
    }
}