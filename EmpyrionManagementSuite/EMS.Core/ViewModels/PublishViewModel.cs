using EMS.Core.Navigation;
using EMS.Core.Util;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;

namespace EMS.Core.ViewModels
{
    public class PublishViewModel : ViewModelCommon
    {
        private IFrameNavigationService navService;
        private Visibility detailsSinglePlayerVisibility;
        private Visibility detailsExistingSaveVisibility;
        public RelayCommand<object> LocationHandler { get; set; }
        public RelayCommand<object> EnvironmentHandler { get; set; }

        public PublishViewModel(IFrameNavigationService NAVSERVICE)
        {
            navService = NAVSERVICE;

            DetailsSinglePlayerVisibility = Visibility.Visible;
            DetailsExistingSaveVisibility = Visibility.Visible;

            SetupCommands();
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

        public Visibility DetailsExistingSaveVisibility
        {
            get
            {
                return detailsExistingSaveVisibility;
            }
            set
            {
                detailsExistingSaveVisibility = value;
                RaisePropertyChanged("DetailsExistingSaveVisibility");
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

        private void SetupCommands()
        {
            try
            {
                EnvironmentHandler = new RelayCommand<object>(HandleEnvironmentInput);
                LocationHandler = new RelayCommand<object>(HandleLocationInput);
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        private void HandleEnvironmentInput(object TYPE)
        {
            try
            {
                var index = int.Parse(TYPE.ToString());

                switch (index)
                {
                    // Single Player
                    case -1:
                        DetailsSinglePlayerVisibility = Visibility.Visible;
                        break;

                    // Multiplayer
                    case 0:
                        //TODO: unimplemented
                        DetailsSinglePlayerVisibility = Visibility.Collapsed;
                        break;
                }
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        private void HandleLocationInput(object TYPE)
        {
            try
            {
                var index = int.Parse(TYPE.ToString());

                switch (index)
                {
                    // New Save
                    case 0:
                        DetailsExistingSaveVisibility = Visibility.Collapsed;
                        break;

                    // Existing Save
                    case 1:
                        DetailsExistingSaveVisibility = Visibility.Visible;
                        break;
                }
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }
    }
}