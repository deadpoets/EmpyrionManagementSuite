using EMS.Core.Navigation;
using EMS.Core.Util;
using EMS.DataModels.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;

namespace EMS.Core.ViewModels
{
    public class InstallViewModel : ViewModelCommon
    {
        private IFrameNavigationService navService;
        private string gamePathSource;
        public RelayCommand OpenFolderDialogCommand { get; set; }
        public RelayCommand ConfirmSetupCommand { get; set; }

        public string WelcomeMessage
        {
            get
            {
                return ResourceManager.GetResource("WELCOME_MESSAGE");
            }
        }

        public string ConfirmSetupButton
        {
            get
            {
                return ResourceManager.GetResource("CONTROL_BUTTON_CONFIRM_SETUP");
            }
        }

        public string GameInstallationPath
        {
            get
            {
                return ResourceManager.GetResource("LABEL_GAME_INSTALLATION_PATH");
            }
        }

        public InstallViewModel(IFrameNavigationService NAVSERVICE)
        {
            navService = NAVSERVICE;

            // Setup Commands
            try
            {
                OpenFolderDialogCommand = new RelayCommand(OpenFolderDialog);
                ConfirmSetupCommand = new RelayCommand(ConfirmSetup);
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        public string GamePathSource { get { return gamePathSource; } set { gamePathSource = value; RaisePropertyChanged("GamePathSource"); } }

        private void OpenFolderDialog()
        {
            try
            {
                var dialog = new System.Windows.Forms.FolderBrowserDialog();
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    GamePathSource = dialog.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        private void ConfirmSetup()
        {
            try
            {
                if (string.IsNullOrEmpty(gamePathSource))
                {
                    MessageBox.Show(ResourceManager.GetResource("SETUP_REQUIRES_INSTALL_PATH"));
                    return;
                }
                else
                {
                    var settings = (((dynamic)Application.Current).Settings as AppSettings);
                    settings.GameInstallationPath = gamePathSource;

                    ((dynamic)Application.Current).Settings = SettingsManager.SaveSettings(settings);

                    navService.NavigateTo("home");
                }
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }
    }
}