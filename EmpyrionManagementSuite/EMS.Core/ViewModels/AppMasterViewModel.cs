using EMS.Core.Navigation;
using System.Diagnostics;

namespace EMS.Core.ViewModels
{
    public class AppMasterViewModel : ViewModelCommon
    {
        private IFrameNavigationService navService;
        private string titleBar;
        private string framePageTitle;

        public AppMasterViewModel(IFrameNavigationService NAVSERVICE)
        {
            navService = NAVSERVICE;

            Name = "Empyrion Management Suite";

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;

            titleBar = Name + " [" + version + "]";
        }

        public void Startup()
        {
            navService.NavigateTo("startup");
        }

        public string TitleBar { get { return titleBar; } }

        public string FramePageTitle { get { return framePageTitle; } set { framePageTitle = value; RaisePropertyChanged("FramePageTitle"); } }
    }
}