using EMS.Core.Navigation;

namespace EMS.Core.ViewModels
{
    public class StartupViewModel : ViewModelCommon
    {
        private IFrameNavigationService navService;

        public StartupViewModel(IFrameNavigationService NAVSERVICE)
        {
            navService = NAVSERVICE;
            Name = "Startup";
        }
    }
}