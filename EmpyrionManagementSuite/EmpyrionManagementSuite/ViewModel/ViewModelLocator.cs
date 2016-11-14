using EMS.Core.Navigation;
using EMS.Core.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;

namespace EmpyrionManagementSuite.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in
    /// the application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SetupNavigation();

            SimpleIoc.Default.Register<AppMasterViewModel>();
            SimpleIoc.Default.Register<StartupViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
            SimpleIoc.Default.Register<InstallViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<CreditsViewModel>();
            SimpleIoc.Default.Register<SectorsViewModel>();
        }

        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();
            navigationService.Configure("startup", new Uri("../Views/Startup.xaml", UriKind.Relative));
            navigationService.Configure("settings", new Uri("../Views/Settings.xaml", UriKind.Relative));
            navigationService.Configure("install", new Uri("../Views/Install.xaml", UriKind.Relative));
            navigationService.Configure("home", new Uri("../Views/Home.xaml", UriKind.Relative));
            navigationService.Configure("credits", new Uri("../Views/Credits.xaml", UriKind.Relative));
            navigationService.Configure("sectors", new Uri("../Views/Sectors.xaml", UriKind.Relative));

            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
        }

        public AppMasterViewModel AppMaster
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AppMasterViewModel>();
            }
        }

        public StartupViewModel Startup
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StartupViewModel>();
            }
        }

        public SettingsViewModel Settings
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SettingsViewModel>();
            }
        }

        public InstallViewModel Install
        {
            get
            {
                return ServiceLocator.Current.GetInstance<InstallViewModel>();
            }
        }

        public HomeViewModel Home
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomeViewModel>();
            }
        }

        public CreditsViewModel Credits
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CreditsViewModel>();
            }
        }

        public SectorsViewModel Sectors
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SectorsViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}