namespace EMS.DataModels.Models
{
    public class UpdateFile
    {
        public string FileName { get; set; }
        public string FileServerURL { get; set; }
        public bool RequiresUpdate { get; set; }
        public string RelativeInstallPath { get; set; }
    }
}