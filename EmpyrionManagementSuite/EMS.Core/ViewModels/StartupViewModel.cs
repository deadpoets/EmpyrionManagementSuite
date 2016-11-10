using EMS.Core.Navigation;
using EMS.Core.Updates;
using EMS.Core.Util;
using System;
using System.Windows;

namespace EMS.Core.ViewModels
{
    public class StartupViewModel : ViewModelCommon
    {
        private IFrameNavigationService navService;

        public StartupViewModel(IFrameNavigationService NAVSERVICE)
        {
            navService = NAVSERVICE;
            Name = ((dynamic)Application.Current).GetLocalizationResourceValue("STARTUP_LOADING");
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

                    if (um.Update.RequiresReinstall)
                    {
                        template += "This version requires a fresh reinstall of the product. Your custom content should stay intact; however, please make a backup of your installation directory. Press [YES] to be directed to the full download site." + Environment.NewLine;
                    }
                    else
                    {
                        template += "Would you like to auto-update now?";
                    }

                    var result = MessageBox.Show(template, "Updates are available!", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        if (um.Update.RequiresReinstall)
                        {
                            System.Diagnostics.Process.Start(um.Update.LatestReleaseURL);
                            Application.Current.Shutdown();
                        }
                        else
                        {
                            um.PerformUpdates();
                        }
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
        public void Start()
        {
            try
            {
                // if the app is not configured, we need to go to the
                // install screen first.
                if (!IsAppConfigured())
                {
                    navService.NavigateTo("install");
                }
                else
                {
                    navService.NavigateTo("home");
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
                if (string.IsNullOrEmpty(((dynamic)Application.Current).Settings.GameInstallationPath))
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