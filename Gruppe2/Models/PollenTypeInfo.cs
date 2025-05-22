using System.Collections.Generic;

namespace Gruppe2.Models
{
    public class PollenTypeInfo
    {
        public string Code { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public bool InSeason { get; set; }
        public IndexInfo IndexInfo { get; set; } = new();
        public List<string> HealthRecommendations { get; set; } = new();
    }
}
