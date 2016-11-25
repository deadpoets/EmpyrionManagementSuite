using EMS.DataModels.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;

namespace EMS.Core.Util
{
    /// <summary>
    /// Handles reading and writing to the application settings file.
    /// </summary>
    public class SettingsManager
    {
        /// <summary>
        /// returns the active instance of the AppSettings.
        /// </summary>
        /// <returns></returns>
        public static AppSettings Instance()
        {
            try
            {
                return (((dynamic) Application.Current).Settings as AppSettings);
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }

            return null;
        }

        /// <summary>
        /// sets the active instance of the AppSettings.
        /// </summary>
        /// <returns></returns>
        public static void Instance(AppSettings SETTINGS)
        {
            try
            {
                ((dynamic) Application.Current).Settings = SETTINGS;
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

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
                    settings.CheckForUpdates = true;
                    settings.UpdateChannel = "master";

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

        /// <summary>
        /// Reads the current AppSettings file from disk.
        /// </summary>
        /// <returns></returns>
        public static AppSettings SaveSettings(AppSettings SETTINGS)
        {
            var settings = new AppSettings();

            try
            {
                File.WriteAllText(Constants.APPSETTINGS_FILE, JsonConvert.SerializeObject(SETTINGS, Formatting.Indented));

                settings = SETTINGS;

                Instance(settings);
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }

            return settings;
        }
    }
}