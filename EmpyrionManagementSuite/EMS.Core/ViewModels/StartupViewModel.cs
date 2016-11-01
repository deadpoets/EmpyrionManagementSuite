using EMS.Core.Navigation;
using EMS.Core.Updates;
using EMS.Core.Util;
using EMS.DataModels.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;

namespace EMS.Core.ViewModels
{
    public class StartupViewModel : ViewModelCommon
    {
        private IFrameNavigationService navService;

        public StartupViewModel(IFrameNavigationService NAVSERVICE)
        {
            navService = NAVSERVICE;
            Name = ((dynamic) Application.Current).GetLocalizationResourceValue("STARTUP_LOADING");
        }

        public void CheckForUpdates()
        {
            try
            {
                var um = new UpdateManager();

                if (um.UpdatesAvailable)
                {
                    string template = "Updates are available for EMS." + Environment.NewLine + Environment.NewLine;
                    template += "Current: " + VersionInfo.FileVersion + Environment.NewLine;
                    template += "Latest: " + um.Update.LatestVersion + " [" + um.Update.UpdateType + "]" + Environment.NewLine + Environment.NewLine;
                    template += um.Update.Description + Environment.NewLine + Environment.NewLine;

                    foreach (var str in um.Update.Changelog)
                    {
                        template += str + Environment.NewLine;
                    }

                    template += Environment.NewLine;
                    template += "Would you like to update now?";

                    var result = MessageBox.Show(template, "Updates are available!", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        PerformUpdates(um.Update);
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        private void PerformUpdates(Update UPDATES)
        {
            try
            {
                var success = false;

                if (!Directory.Exists(Constants.TEMP_DIR))
                {
                    Directory.CreateDirectory(Constants.TEMP_DIR);
                }

                foreach (var f in UPDATES.UpdateManifest.ToList())
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