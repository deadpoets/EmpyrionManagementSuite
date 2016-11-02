using EMS.Core.Navigation;
using System.Windows;

namespace EMS.Core.ViewModels
{
    public class InstallViewModel : ViewModelCommon
    {
        private IFrameNavigationService navService;

        public string WelcomeMessage
        {
            get
            {
                return ((dynamic) Application.Current).GetLocalizationResourceValue("WELCOME_MESSAGE");
            }
        }

        public InstallViewModel(IFrameNavigationService NAVSERVICE)
        {
            navService = NAVSERVICE;
        }
    }
}