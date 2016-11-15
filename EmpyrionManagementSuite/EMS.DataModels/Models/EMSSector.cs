using System;
using System.Collections.Generic;

namespace EMS.DataModels.Models
{
    /// <summary>
    /// Represents a sector with extra info used only by the EMS tool.
    /// </summary>
    public class EMSSector : Sector
    {
        public Guid ID { get; set; }
        public string FriendlyName { get; set; }
        public string Owner { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<string> Contributors { get; set; }
        public string URL { get; set; }
        public bool AllowModifications { get; set; }
        public bool IsSystemSector { get; set; }
    }
}