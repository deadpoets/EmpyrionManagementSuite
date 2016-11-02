using EMS.Core.Navigation;
using EMS.Core.Updates;
using EMS.Core.Util;
using System;
using System.Threading.Tasks;
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
                        um.PerformUpdates();
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        /// <summary>
        /// Processes that need to happen before the main app is started.
        /// </summary>
        public async void Start()
        {
            try
            {
                // Force the app to wait for a moment to make sure its
                // caught up
                await Task.Delay(TimeSpan.FromSeconds(2.25));

                // if the app is not configured, we need to go to the
                // install screen first.
                if (!IsAppConfigured())
                {
                    navService.NavigateTo("install");
                }
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        private bool IsAppConfigured()
        {
            try
            {
                if (string.IsNullOrEmpty(((dynamic) Application.Current).Settings.GameInstallationPath))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
            return false;
        }
    }
}