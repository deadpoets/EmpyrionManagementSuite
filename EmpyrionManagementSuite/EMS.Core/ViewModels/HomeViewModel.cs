using EMS.Core.Navigation;
using EMS.Core.Util;

namespace EMS.Core.ViewModels
{
    public class HomeViewModel : ViewModelCommon
    {
        private IFrameNavigationService navService;

        //public string DashboardURL
        //{
        //    get
        //    {
        //        return Constants.HOME_DASHBOARD_URL;
        //    }
        //}

        public HomeViewModel(IFrameNavigationService NAVSERVICE)
        {
            navService = NAVSERVICE;
        }
    }
}