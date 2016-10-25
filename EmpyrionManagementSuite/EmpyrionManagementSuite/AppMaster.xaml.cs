using EMS.Core.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace EmpyrionManagementSuite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AppMaster : Window
    {
        public AppMasterViewModel ViewModel { get; set; }

        public AppMaster()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}