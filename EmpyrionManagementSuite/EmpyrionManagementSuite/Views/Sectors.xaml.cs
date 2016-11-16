using EmpyrionManagementSuite.ViewModel;
using EMS.Core.Util;
using EMS.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EmpyrionManagementSuite.Views
{
    /// <summary>
    /// Interaction logic for Sectors.xaml
    /// </summary>
    public partial class Sectors : Page
    {
        public SectorsViewModel ViewModel
        {
            get { return ((ViewModelLocator)Application.Current.Resources["Locator"]).Sectors; }
        }

        public Sectors()
        {
            InitializeComponent();

            Loaded += (s, f) =>
              {
                  try
                  {
                      ViewModel.SectorsListBox = lstSectors;
                      ViewModel.SectorsListBox.SelectionChanged += ViewModel.SectorsListBox_SelectionChanged;

                      ViewModel.RebindSectors();
                  }
                  catch (Exception ex)
                  {
                      AppLogger.Exception(ex);
                  }
              };
        }
    }
}