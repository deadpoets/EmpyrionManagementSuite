using System.Collections.Generic;

namespace EMS.DataModels.Models
{
    /// <summary>
    /// Defines a Eleon sector model.
    /// </summary>
    public class Sector
    {
        public List<string> Coordinates { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public List<List<string>> Playfields { get; set; }
    }
}