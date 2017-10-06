using EMS.Core.Navigation;
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
            Name = ResourceManager.GetResource("STARTUP_LOADING");
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