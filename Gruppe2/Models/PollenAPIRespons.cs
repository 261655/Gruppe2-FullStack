using System.Text.Json.Serialization;
using Gruppe2.Models;

namespace Gruppe2.Models
{
    public class PollenAPIRespons
    {
        [JsonPropertyName("dailyInfo")]
        public List<DailyInfoDto> DailyInfo { get; set; } = new();
    }

    public class DailyInfoDto
    {
        [JsonPropertyName("code")]
        public string Code { get; set; } = string.Empty;

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; } = string.Empty;

        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("color")]
        public ColorDto Color { get; set; } = new();

        [JsonPropertyName("pollenTypeInfo")]
        public List<PollenTypeDto> PollenTypeInfo { get; set; } = new();

        [JsonPropertyName("date")]
        public DateDto Date { get; set; }

        [JsonPropertyName("plantInfo")]
        public List<PlantInfoDto> PlantInfo { get; set; } = new();
    }

    public class PollenTypeDto
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("indexInfo")]
        public IndexInfoDto IndexInfo { get; set; }
    }

    public class IndexInfoDto
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("indexDescription")]
        public string IndexDescription { get; set; }

        [JsonPropertyName("color")]
        public ColorDto Color { get; set; }
    }

    public class ColorDto
    {
        public float? Red { get; set; }
        public float? Green { get; set; }
        public float? Blue { get; set; }
    }

    public class PollenDisplayDto
    {
        public string Date { get; set; }         
        public string Code { get; set; }         
        public string DisplayName { get; set; }  
        public int Value { get; set; }
        public string Category { get; set; }
        public string IndexDescription { get; set; }
        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }
    }

    public class DateDto
    {
        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("month")]
        public int Month { get; set; }

        [JsonPropertyName("day")]
        public int Day { get; set; }
    }

    public class PlantInfoDto
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("indexInfo")]
        public IndexInfoDto IndexInfo { get; set; }
    }
}