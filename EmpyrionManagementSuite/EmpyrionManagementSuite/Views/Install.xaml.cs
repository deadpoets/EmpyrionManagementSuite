using EmpyrionManagementSuite.ViewModel;
using EMS.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmpyrionManagementSuite.Views
{
    /// <summary>
    /// Interaction logic for Install.xaml
    /// </summary>
    public partial class Install : Page
    {
        public InstallViewModel ViewModel
        {
            get { return ((ViewModelLocator) Application.Current.Resources["Locator"]).Install; }
        }

        public Install()
        {
            InitializeComponent();
        }
    }
}