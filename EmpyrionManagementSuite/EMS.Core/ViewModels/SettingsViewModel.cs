using EMS.Core.Navigation;
using EMS.Core.Util;
using System.Windows;

namespace EMS.Core.ViewModels
{
    public class SettingsViewModel : ViewModelCommon
    {
        private IFrameNavigationService navService;
        public string InstallationPathLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_GAME_INSTALLATION_PATH");
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
        
    }
}