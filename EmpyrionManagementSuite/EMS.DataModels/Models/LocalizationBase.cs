using System.Collections.Generic;

namespace EMS.DataModels.Models
{
    /// <summary>
    /// Used as a base class for all localization resources.
    /// </summary>
    public class LocalizationBase
    {
        public string LocalizationCode { get; set; }
        public string Name { get; set; }
        public List<string> Authors { get; set; }
        public List<Resource> Resources { get; set; }
    }
}