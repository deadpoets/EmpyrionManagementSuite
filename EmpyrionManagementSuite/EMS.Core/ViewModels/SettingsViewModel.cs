using EMS.Core.Navigation;
using EMS.Core.Util;
using System.Windows;

namespace EMS.Core.ViewModels
{
    public class SettingsViewModel : ViewModelCommon
    {
        private IFrameNavigationService navService;

        private bool shouldCheckForUpdates;

        public string InstallationPathLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_GAME_INSTALLATION_PATH");
            }
        }

        public string UpdateLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_UPDATE_CHECK");
            }
        }

        public string LanguageLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_LANGUAGE");
            }
        }

        public string UsernameLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_USERNAME");
            }
        }

        public string PasswordLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_PASSWORD");
            }
        }

        public string UpdateChannelLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_UPDATE_CHANNEL");
            }
        }

        public string InstallationPath
        {
            get
            {
                return ((dynamic)Application.Current).Settings.GameInstallationPath;
            }

            set
            {
                InstallationPath = value;
            }
        }

        public bool ShouldCheckForUpdates
        {
            get
            {
                return shouldCheckForUpdates;
            }

            set
            {
                shouldCheckForUpdates = value;
            }
        }

        public SettingsViewModel(IFrameNavigationService NAVSERVICE)
        {
            navService = NAVSERVICE;
            Name = ResourceManager.GetResource("APP_NAME");
            shouldCheckForUpdates = ((dynamic)Application.Current).Settings.CheckForUpdates;
        }
    }
}