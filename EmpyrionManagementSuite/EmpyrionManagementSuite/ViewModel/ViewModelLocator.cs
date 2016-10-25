using EMS.Core.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace EmpyrionManagementSuite.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
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
        }

        private static void SetupNavigation()
        {
            //var navigationService = new FrameNavigationService();
            //navigationService.Configure("Timeline", new Uri("../Modules/Timeline.xaml", UriKind.Relative));

            //SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
        }

        public AppMasterViewModel AppMasterViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AppMasterViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}