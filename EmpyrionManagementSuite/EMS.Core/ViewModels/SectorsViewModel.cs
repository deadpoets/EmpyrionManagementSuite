using EMS.Core.Navigation;
using System.Windows;

namespace EMS.Core.ViewModels
{
    public class SectorsViewModel : ViewModelCommon
    {
        private IFrameNavigationService navService;

        public SectorsViewModel(IFrameNavigationService NAVSERVICE)
        {
            navService = NAVSERVICE;
        }

        public string SectorsLabel
        {
            get
            {
                return ((dynamic)Application.Current).GetLocalizationResourceValue("LABEL_SECTORS");
            }
        }
    }
}