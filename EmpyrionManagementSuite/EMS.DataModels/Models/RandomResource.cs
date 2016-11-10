using System.Collections.Generic;

namespace EMS.DataModels.Models
{
    public class RandomResource
    {
        public string Name { get; set; }
        public List<int> CountMinMax { get; set; }
        public List<int> SizeMinMax { get; set; }
        public List<int> DepthMinMax { get; set; }
        public double DroneProb { get; set; }
        public int MaxDroneCount { get; set; }
    }
}