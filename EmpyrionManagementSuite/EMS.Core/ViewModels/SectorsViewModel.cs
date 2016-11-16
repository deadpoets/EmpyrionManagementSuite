using EMS.Core.Libraries;
using EMS.Core.Navigation;
using EMS.DataModels.Models;
using System.Collections.Generic;
using System.Windows;

namespace EMS.Core.ViewModels
{
    public class SectorsViewModel : ViewModelCommon
    {
        private IFrameNavigationService navService;
        private SectorsManager sManager;

        public SectorsViewModel(IFrameNavigationService NAVSERVICE)
        {
            navService = NAVSERVICE;
            sManager = new SectorsManager();
        }

        public string SectorsLabel
        {
            get
            {
                return ((dynamic) Application.Current).GetLocalizationResourceValue("LABEL_SECTORS");
            }
        }

        public List<EMSSector> SectorsList
        {
            get
            {
                return sManager.Sectors;
            }
        }
    }
}