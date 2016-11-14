using EMS.Core.Util;
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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();

            NotImplemented();
        }

        private void NotImplemented()
        {
            try
            {
                MessageBox.Show("This part is largely not implemented yet nor completely functional. If you wuld like to change the update check to false, please change it manually in the settings.json file in the EMS Installation Root Directory.");
            }
            catch (Exception ex)
            {
                AppLogger.Exception(ex);
            }
        }
    }
}