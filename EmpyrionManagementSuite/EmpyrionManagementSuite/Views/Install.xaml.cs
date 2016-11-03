using EmpyrionManagementSuite.ViewModel;
using EMS.Core.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace EmpyrionManagementSuite.Views
{
    /// <summary>
    /// Interaction logic for Install.xaml
    /// </summary>
    public partial class Install : Page
    {
        public InstallViewModel ViewModel
        {
            get { return ((ViewModelLocator)Application.Current.Resources["Locator"]).Install; }
        }

        public Install()
        {
            InitializeComponent();
        }
    }
}