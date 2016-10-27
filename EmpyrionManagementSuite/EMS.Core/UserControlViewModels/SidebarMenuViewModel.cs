using System.Windows;

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
                return ((dynamic) Application.Current).GetLocalizationResourceValue("CONTROL_BUTTON_SETTINGS");
            }
        }
    }
}