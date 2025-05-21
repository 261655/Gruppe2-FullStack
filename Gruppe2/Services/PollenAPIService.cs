using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Gruppe2.Models;

public class PollenAPIService : IPollenAPIService
{
    private readonly HttpClient _http;
    private readonly AppDbContext _context;

    public PollenAPIService(HttpClient http, AppDbContext context)
    {
        _http = http;
        _context = context;
    }

    public async Task HentPollenDataAsync()
    {
        string url = "https://pollen.googleapis.com/v1/forecast:lookup?key=AIzaSyCcJ3vf6FXeMkfgdGuJytfRuh6PQ_tDJ7U&location.longitude=10.40762&location.latitude=59.26754&days=5";

        var response = await _http.GetStreamAsync(url);

        var result = await JsonSerializer.DeserializeAsync<PollenAPIRespons>(
            response,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (result?.DailyInfo != null)
        {
            foreach (DailyInfoDto day in result.DailyInfo)
            {
            var index = new IndexInfo
                {
                    Code = day.Code,
                    DisplayName = day.DisplayName,
                    Value = day.Value,
                    Category = day.Category,
                    IndexDescription = day.Description ?? "Ingen beskrivelse tilgjengelig",
                    ColorInfo = new ColorInfo
                    {
                        Red = day.Color.Red,
                        Green = day.Color.Green,
                        Blue = day.Color.Blue
                    }
                };

                _context.IndexInfos.Add(index);
            }

            await _context.SaveChangesAsync();
        }
    }
}
