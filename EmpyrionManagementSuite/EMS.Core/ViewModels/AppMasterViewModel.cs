using EMS.Core.Navigation;
using EMS.Core.Util;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;

namespace EMS.Core.ViewModels
{
    public class AppMasterViewModel : ViewModelCommon
    {
        public IFrameNavigationService navService;
        private string titleBar;
        private string framePageTitle;
        public RelayCommand MinimizeCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }
        public RelayCommand ShowMenuCommand { get; set; }

        public AppMasterViewModel(IFrameNavigationService NAVSERVICE)
        {
            // Hide the menu toggle on first load
            HideMenuToggle();

            navService = NAVSERVICE;

            Name = ((dynamic)Application.Current).GetLocalizationResourceValue("APP_NAME");

            try
            {
                titleBar = Name + " [" + VersionInfo.FileVersion + "]";
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
                ShowMenuCommand = new RelayCommand(ShowMenu);
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
                if (MessageBox.Show(((dynamic)Application.Current).GetLocalizationResourceValue("APP_CONFIRM_SHUTDOWN"), ((dynamic)Application.Current).GetLocalizationResourceValue("APP_QUIT"), MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                }
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        private void ShowMenu()
        {
            try
            {
                ((dynamic)Application.Current.MainWindow).SidebarMenu.ToggleVisiblity();
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        public void NavigationBehaviour()
        {
            try
            {
                ResetAll();

                switch (FramePageTitle)
                {
                    case "Startup":
                        HideMenuToggle();
                        break;

                    case "Install":
                        HideMenuToggle();
                        break;

                    case "Home":
                        ((dynamic)Application.Current.MainWindow).SidebarMenu.ToggleVisiblity();
                        break;
                }
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        private void HideMenuToggle()
        {
            try
            {
                ((dynamic)Application.Current.MainWindow).MenuToggle.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        private void ResetAll()
        {
            try
            {
                ((dynamic)Application.Current.MainWindow).MenuToggle.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }
    }
}