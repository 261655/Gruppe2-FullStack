using System.Collections.Generic;

namespace Gruppe2.Models
{
    public class DailyInfo
    {
        public DateInfo Date { get; set; } = new();
        public List<PollenTypeInfo> PollenTypeInfo { get; set; } = new();
        public List<PlantInfo> PlantInfo { get; set; } = new();
    }
}
