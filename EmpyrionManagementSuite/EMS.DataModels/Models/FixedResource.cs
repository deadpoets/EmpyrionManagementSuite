using System.Collections.Generic;

namespace EMS.DataModels.Models
{
    public class FixedResource
    {
        public string Name { get; set; }
        public List<int> Pos { get; set; }
        public int Radius { get; set; }
    }
}