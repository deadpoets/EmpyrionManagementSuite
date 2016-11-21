using EMS.Core.UserControlViewModels;
using EMS.Core.Util;
using GalaSoft.MvvmLight.Views;
using System;
using System.Windows;
using System.Windows.Controls;

namespace EmpyrionManagementSuite.UserControls
{
    /// <summary>
    /// Interaction logic for SidebarMenu.xaml
    /// </summary>
    public partial class SidebarMenu : UserControl
    {
        private INavigationService navService;

        public SidebarMenu()
        {
            InitializeComponent();

            Loaded += (s, f) =>
            {
                this.DataContext = new SidebarMenuViewModel();
                navService = ((dynamic)Application.Current.MainWindow).ViewModel.navService;
                SidebarContainer.Visibility = Visibility.Collapsed;
            };
        }

        /// <summary>
        /// Show/Hide the sidebar menu.
        /// </summary>
        public void ToggleVisiblity()
        {
            try
            {
                if (SidebarContainer.IsVisible)
                {
                    SidebarContainer.Visibility = Visibility.Collapsed;
                }
                else
                {
                    SidebarContainer.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }

        /// <summary>
        /// Handles all menu button clicks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var btn = (sender as Button);

                switch (int.Parse(btn.CommandParameter.ToString()))
                {
                    case 0:
                        navService.NavigateTo("home");
                        ToggleVisiblity();
                        break;

                    case 1:
                        navService.NavigateTo("settings");
                        ToggleVisiblity();
                        break;

                    case 2:
                        navService.NavigateTo("credits");
                        ToggleVisiblity();
                        break;

                    case 3:
                        navService.NavigateTo("sectors");
                        ToggleVisiblity();
                        break;

                    case -1:
                        navService.NavigateTo("publish");
                        ToggleVisiblity();
                        break;

                    default:
                        MessageBox.Show("ERROR");
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