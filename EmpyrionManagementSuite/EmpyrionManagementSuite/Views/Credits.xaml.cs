using EmpyrionManagementSuite.UserControls;
using EmpyrionManagementSuite.ViewModel;
using EMS.Core.Util;
using EMS.Core.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EmpyrionManagementSuite.Views
{
    /// <summary>
    /// Interaction logic for Credits.xaml
    /// </summary>
    public partial class Credits : Page
    {
        public CreditsViewModel ViewModel
        {
            get { return ((ViewModelLocator)Application.Current.Resources["Locator"]).Credits; }
        }

        public Credits()
        {
            InitializeComponent();

            Loaded += (s, f) =>
            {
                try
                {
                    var credits = ViewModel.GetCreditsCollection();

                    var panel = new StackPanel();
                    panel.Margin = new Thickness(15);

                    foreach (var credit in credits.ToList())
                    {
                        var control = new UCCredit(credit);
                        panel.Children.Add(control);
                    }

                    creditsContainer.Children.Add(panel);
                }
                catch (Exception ex)
                {
                    AppLogger.Exception(ex);
                }
            };
        }
    }
}