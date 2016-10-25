using EmpyrionManagementSuite.ViewModel;
using EMS.Core.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace EmpyrionManagementSuite
{
    /// <summary>
    /// Interaction logic for AppMaster.xaml
    /// </summary>
    public partial class AppMaster : Window
    {
        public AppMasterViewModel ViewModel
        {
            get { return ((ViewModelLocator)Application.Current.Resources["Locator"]).AppMaster; }
        }

        public AppMaster()
        {
            InitializeComponent();

            Loaded += (s, f) =>
            {
                ViewModel.Startup();
            };
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void NavigationFrameContent_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            //TODO: add a page type to friendly name localization file matrix, but for now, this is ok for V1.
            ViewModel.FramePageTitle = e.Content.GetType().Name;
        }
    }
}