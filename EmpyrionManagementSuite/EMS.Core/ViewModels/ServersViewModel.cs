using EMS.Core.Navigation;

namespace EMS.Core.ViewModels
{
    public class ServersViewModel : ViewModelCommon
    {
        private IFrameNavigationService navService;

        public ServersViewModel(IFrameNavigationService NAVSERVICE)
        {
            navService = NAVSERVICE;
        }
    }
}
