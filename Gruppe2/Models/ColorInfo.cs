namespace Gruppe2.Models
{
    public class ColorInfo
    {
        public int ID { get; set; }
        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }
        public ICollection<IndexInfo> IndexInfos { get; set; }
    }
}
