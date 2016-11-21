using EMS.Core.Navigation;
using EMS.Core.Util;

namespace EMS.Core.ViewModels
{
    public class PublishViewModel : ViewModelCommon
    {
        private IFrameNavigationService navService;

        public PublishViewModel(IFrameNavigationService NAVSERVICE)
        {
            navService = NAVSERVICE;
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