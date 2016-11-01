using EMS.Core.Util;
using EMS.DataModels.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
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

        public void PerformUpdates()
        {
            try
            {
                if (!Directory.Exists(Constants.TEMP_DIR))
                {
                    Directory.CreateDirectory(Constants.TEMP_DIR);
                }

                foreach (var f in update.UpdateManifest.ToList())
                {
                    DownloadFile(f);
                }
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        private void DownloadFile(UpdateFile F)
        {
            try
            {
                // Download File to temp directory
                WebClient client = new WebClient();

                client.DownloadDataCompleted += (s, f) =>
                {
                    try
                    {
                        File.WriteAllBytes(Constants.TEMP_DIR + "\\" + F.FileName, f.Result);
                    }
                    catch (Exception ex)
                    {
                        AppLogger.Exception(ex);
                    }
                };

                client.DownloadDataAsync(new Uri(F.FileServerURL));
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }
    }
}