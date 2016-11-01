using EMS.Core.Util;
using EMS.DataModels.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;

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
                // where temporary downloads are placed.
                if (!Directory.Exists(Constants.TEMP_DIR))
                {
                    Directory.CreateDirectory(Constants.TEMP_DIR);
                }

                foreach (var f in update.UpdateManifest.Where(x => x.RequiresUpdate).ToList())
                {
                    DownloadFile(f);
                    MoveFiles(f);
                }

                // restart app
                MessageBox.Show("The app needs to be restarted for the update to take effect!", "Shutting Down...", MessageBoxButton.OK, MessageBoxImage.Information);
                Application.Current.Shutdown();
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

                var bytes = client.DownloadData(new Uri(F.FileServerURL));

                File.WriteAllBytes(Constants.TEMP_DIR + "\\" + F.FileName, bytes);
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        private void MoveFiles(UpdateFile F)
        {
            try
            {
                var installationFilePath = Constants.BASE_DIRECTORY + (F.RelativeInstallPath == "#" ? "" : F.RelativeInstallPath.Replace("#", "\\")) + F.FileName;
                var updateFilePath = Constants.TEMP_DIR + "\\" + F.FileName;

                // CHeck for existance of .bak file
                if (File.Exists(installationFilePath + ".bak"))
                {
                    // Delete the older backup
                    File.Delete(installationFilePath + ".bak");
                }

                // CHeck for existence of old file, and rename it if it exists...
                if (File.Exists(installationFilePath))
                {
                    // Rename the old file.
                    File.Move(installationFilePath, installationFilePath + ".bak");
                }

                // Move the new file into root directory
                File.Move(updateFilePath, installationFilePath);
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }
    }
}