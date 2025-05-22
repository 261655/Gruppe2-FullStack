using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Gruppe2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class PollenAPIService : IPollenAPIService
{
    private readonly HttpClient _http;

    private static readonly Dictionary<string, string> NorskNavn = new()
    {
        { "Tree", "Tre" },
        { "Grass", "Gress" },
        { "Weed", "Ugress" },
        { "Ash", "Ask" },
        { "Oak", "Eik" },
        { "Pine", "Furu" },
        { "Birch", "Bjørk" },
        { "Olive", "Oliven" },
        { "Grasses", "Gressarter" },
        { "Alder", "Or" },
        { "Ragweed", "Burot" },
        { "Mugwort", "Burot" },
        { "Hazel", "Hassel" },
        { "Cottonwood", "Poppel" },
        { "Graminales", "Gressfamilien" }
    };
    public PollenAPIService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<PollenDisplayDto>> HentDisplayDataAsync()
    {
        string url = "https://pollen.googleapis.com/v1/forecast:lookup?key=AIzaSyCcJ3vf6FXeMkfgdGuJytfRuh6PQ_tDJ7U&location.longitude=10.40762&location.latitude=59.26754&days=5";

        var response = await _http.GetStreamAsync(url);

        var result = await JsonSerializer.DeserializeAsync<PollenAPIRespons>(
            response,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        var liste = new List<PollenDisplayDto>();

        if (result?.DailyInfo != null)
        {
            foreach (var day in result.DailyInfo)
            {
                string datoStr = $"{day.Date.Day}.{day.Date.Month}.";
                
                

                foreach (var type in day.PollenTypeInfo)
                {
                    var index = type.IndexInfo;
                    var color = index?.Color;

                    if (index == null || color == null) continue;

                    liste.Add(new PollenDisplayDto
                    {
                        Date = datoStr,
                        Code = type.Code ?? "-",
                        DisplayName = NorskNavn.TryGetValue(type.DisplayName ?? "", out var norskNavn) ? norskNavn : type.DisplayName,
                        Value = index.Value,
                        Category = index.Category ?? "-",
                        IndexDescription = index.IndexDescription ?? "-",
                        Red = color.Red ?? 0,
                        Green = color.Green ?? 0,
                        Blue = color.Blue ?? 0
                    });
                }

                foreach (var plant in day.PlantInfo)
                {
                    var index = plant.IndexInfo;
                    var color = index?.Color;

                    if (index == null || color == null) continue;

                    liste.Add(new PollenDisplayDto
                    {
                        Date = datoStr,
                        Code = plant.Code ?? "-",
                        DisplayName = NorskNavn.TryGetValue(plant.DisplayName ?? "", out var norskNavn)? norskNavn : plant.DisplayName,
                        Value = index.Value,
                        Category = index.Category ?? "-",
                        IndexDescription = index.IndexDescription ?? "-",
                        Red = color.Red ?? 0,
                        Green = color.Green ?? 0,
                        Blue = color.Blue ?? 0
                    });
                }
            }
        }
        return liste;
    }
}
