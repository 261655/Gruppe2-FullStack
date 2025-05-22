using System.Collections.Generic;

namespace Gruppe2.Models
{
    public class PollenData
    {
        public string RegionCode { get; set; } = string.Empty;
        public List<DailyInfo> DailyInfo { get; set; } = new();
    }
}
