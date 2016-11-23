using EMS.Core.Navigation;
using EMS.Core.Util;
using System.Windows;

namespace EMS.Core.ViewModels
{
    public class PublishViewModel : ViewModelCommon
    {
        private IFrameNavigationService navService;
        private Visibility detailsSinglePlayerVisibility;

        public PublishViewModel(IFrameNavigationService NAVSERVICE)
        {
            navService = NAVSERVICE;

            DetailsSinglePlayerVisibility = Visibility.Visible;
        }

        public Visibility DetailsSinglePlayerVisibility
        {
            get
            {
                return detailsSinglePlayerVisibility;
            }
            set
            {
                detailsSinglePlayerVisibility = value;
                RaisePropertyChanged("DetailsSinglePlayerVisibility");
            }
        }

        public string EnvironmentLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_ENVIRONMENT");
            }
        }

        public string EnvironmentHelpText
        {
            get
            {
                return ResourceManager.GetResource("LABEL_ENVIRONMENT_HELP_TEXT");
            }
        }

        public string LocationHelpText
        {
            get
            {
                return ResourceManager.GetResource("LABEL_LOCATION_HELP_TEXT");
            }
        }

        public string NewSaveLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_NEW_SAVE");
            }
        }

        public string ExistingSaveLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_EXISTING_SAVE");
            }
        }

        public string DetailsLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_DETAILS");
            }
        }

        public string SinglePlayerLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_SINGLE_PLAYER");
            }
        }

        public string MPLabel
        {
            get
            {
                return ResourceManager.GetResource("LABEL_MULTI_PLAYER");
            }
        }
    }
}