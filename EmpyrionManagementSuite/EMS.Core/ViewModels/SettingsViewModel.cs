using EMS.Core.Navigation;
using System.Windows;

namespace EMS.Core.ViewModels
{
    public class SettingsViewModel : ViewModelCommon
    {
        private IFrameNavigationService navService;

        public SettingsViewModel(IFrameNavigationService NAVSERVICE)
        {
            navService = NAVSERVICE;
            Name = ((dynamic) Application.Current).GetLocalizationResourceValue("APP_NAME");
        }
    }
}