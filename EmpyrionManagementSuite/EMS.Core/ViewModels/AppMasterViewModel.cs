using System.Diagnostics;

namespace EMS.Core.ViewModels
{
    public class AppMasterViewModel : ViewModelCommon
    {
        public string titleBar;

        public AppMasterViewModel()
        {
            Name = "Empyrion Management Suite";

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;

            titleBar = Name + " [" + version + "]";
        }

        public string TitleBar { get { return titleBar; } }
    }
}