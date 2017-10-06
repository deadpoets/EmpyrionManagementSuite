﻿using EmpyrionManagementSuite.ViewModel;
using EMS.Core.Util;
using EMS.Core.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace EmpyrionManagementSuite.Views
{
    /// <summary>
    /// Interaction logic for Startup.xaml
    /// </summary>
    public partial class Startup : Page
    {
        public StartupViewModel ViewModel
        {
            get { return ((ViewModelLocator)Application.Current.Resources["Locator"]).Startup; }
        }

        public Startup()
        {
            InitializeComponent();

            Loaded += (s, f) =>
            {
                try
                {
                    ViewModel.Start();
                }
                catch (Exception ex)
                {
                    AppLogger.Exception(ex);
                    MessageBox.Show(ex.Message);
                    Application.Current.Shutdown();
                }
            };
        }
    }
}