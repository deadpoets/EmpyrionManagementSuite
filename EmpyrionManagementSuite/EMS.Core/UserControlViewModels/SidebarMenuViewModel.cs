using EMS.Core.Util;

namespace EMS.Core.UserControlViewModels
{
    /// <summary>
    /// Used to bind simple text data (with localizations) to User Controls.
    /// </summary>
    public class SidebarMenuViewModel
    {
        public string SettingsButton
        {
            get
            {
                return ResourceManager.GetResource("CONTROL_BUTTON_SETTINGS");
            }
        }

        public string HomeButton
        {
            get
            {
                return ResourceManager.GetResource("CONTROL_BUTTON_HOME");
            }
        }

        public string CreditsButton
        {
            get
            {
                return ResourceManager.GetResource("CONTROL_BUTTON_CREDITS");
            }
        }

        public string SectorsButton
        {
            get
            {
                return ResourceManager.GetResource("CONTROL_BUTTON_SECTORS");
            }
        }

        public string PublishButton
        {
            get
            {
                return ResourceManager.GetResource("CONTROL_BUTTON_PUBLISH");
            }
        }
    }
}