namespace Gruppe2.Models
{
    public class PlantInfo
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string DisplayName { get; set; }
        public bool InSeason { get; set; }
        public int IndexInfoID { get; set; }
        public IndexInfo IndexInfo { get; set; }
        public ICollection<PollenResponse> PollenResponses { get; set; }
    }
}
