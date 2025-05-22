namespace Gruppe2.Models
{
    public class PollenResponse
    {
        public int ID { get; set; }
        public int DateInfoID { get; set; }
        public int PlantInfoID { get; set; }
        public DateInfo DateInfo { get; set; }
        public PlantInfo PlantInfo { get; set; }
    }
}
