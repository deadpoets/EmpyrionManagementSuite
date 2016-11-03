using EmpyrionManagementSuite.ViewModel;
using EMS.Core.Util;
using EMS.Core.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace EmpyrionManagementSuite.Views
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public HomeViewModel ViewModel
        {
            get { return ((ViewModelLocator)Application.Current.Resources["Locator"]).Home; }
        }

        public Home()
        {
            InitializeComponent();

            Loaded += (s, f) =>
            {
                browser.Navigate(Constants.HOME_DASHBOARD_URL);
            };
        }
    }
}