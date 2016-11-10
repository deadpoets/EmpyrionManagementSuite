using System;
using System.Collections.Generic;

namespace EMS.DataModels.Models
{
    /// <summary>
    /// Contains all information relevant for updating the application.
    /// </summary>
    public class Update
    {
        public string LatestVersion { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Description { get; set; }
        public string UpdateType { get; set; }
        public bool RequiresReinstall { get; set; }
        public string LatestReleaseURL { get; set; }
        public List<string> Changelog { get; set; }
        public List<UpdateFile> UpdateManifest { get; set; }
    }
}