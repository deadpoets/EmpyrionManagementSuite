using EMS.Core.Util;
using EMS.DataModels.Models;
using Newtonsoft.Json;
using System;
using System.Net;

namespace EMS.Core.Updates
{
    /// <summary>
    /// Handles checking for updates available, and the actual update process.
    /// </summary>
    public class UpdateManager
    {
        private bool isUpdateAvailable;
        private Update update;

        public UpdateManager()
        {
            isUpdateAvailable = false;

            CheckForUpdates();
        }

        public bool UpdatesAvailable { get { return isUpdateAvailable; } }
        public Update Update { get { return update; } }

        private void CheckForUpdates()
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    update = JsonConvert.DeserializeObject<Update>(wc.DownloadString(Constants.UPDATE_JSON_URL));
                }

                var localVersion = VersionInfo.FileVersion;
                var latestVersion = update.LatestVersion;

                if (localVersion != latestVersion)
                {
                    isUpdateAvailable = true;
                    AppLogger.Info("Version " + latestVersion + " is available. You are running version " + localVersion + ".");
                }
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }
    }
}