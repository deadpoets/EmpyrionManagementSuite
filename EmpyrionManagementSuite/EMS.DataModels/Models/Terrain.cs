namespace EMS.DataModels.Models
{
    public class Terrain
    {
        public string Name { get; set; }
        public int PoleLevel { get; set; }
        public double NoiseStrength { get; set; }
        public ColorChange ColorChange { get; set; }
    }
}