using EMS.Core.Navigation;
using EMS.Core.Util;
using GalaSoft.MvvmLight.Command;
using System;
using System.Diagnostics;
using System.Windows;

namespace EMS.Core.ViewModels
{
    public class AppMasterViewModel : ViewModelCommon
    {
        private IFrameNavigationService navService;
        private string titleBar;
        private string framePageTitle;
        public RelayCommand MinimizeCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }

        public AppMasterViewModel(IFrameNavigationService NAVSERVICE)
        {
            navService = NAVSERVICE;

            Name = "Empyrion Management Suite";

            try
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                string version = fvi.FileVersion;

                titleBar = Name + " [" + version + "]";
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }

            // Setup Commands
            try
            {
                MinimizeCommand = new RelayCommand(MinimizeWindow);
                CloseCommand = new RelayCommand(CloseApplication);
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        public string TitleBar { get { return titleBar; } }

        public string FramePageTitle { get { return framePageTitle; } set { framePageTitle = value; RaisePropertyChanged("FramePageTitle"); } }

        public void Startup()
        {
            try
            {
                navService.NavigateTo("startup");
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        private void MinimizeWindow()
        {
            try
            {
                var win = Application.Current.MainWindow;
                win.WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        private void CloseApplication()
        {
            try
            {
                //TODO: localization
                if (MessageBox.Show("This will shutdown the application without saving any changes or gracefully terminating any running servers. Are you sure?", "Quit?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                }
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }
    }
}