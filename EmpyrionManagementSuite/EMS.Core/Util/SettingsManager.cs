using EMS.DataModels.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace EMS.Core.Util
{
    /// <summary>
    /// Handles reading and writing to the application settings file.
    /// </summary>
    public class SettingsManager
    {
        /// <summary>
        /// Reads the current AppSettings file from disk.
        /// </summary>
        /// <returns></returns>
        public static AppSettings Init()
        {
            var settings = new AppSettings();

            try
            {
                // if the settings file doesnt exist, create a default one.
                if (!File.Exists(Constants.APPSETTINGS_FILE))
                {
                    settings.Version = VersionInfo.FileVersion;
                    settings.LocalizationCode = "en-us";

                    File.WriteAllText(Constants.APPSETTINGS_FILE, JsonConvert.SerializeObject(settings, Formatting.Indented));
                }

                settings = JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(Constants.APPSETTINGS_FILE));
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }

            return settings;
        }
    }
}