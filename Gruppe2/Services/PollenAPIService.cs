using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Gruppe2.Models;
using Microsoft.EntityFrameworkCore;


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
            foreach (var day in result.DailyInfo)
            {
                foreach (var type in day.PollenTypeInfo)
                {
                    var index = type.IndexInfo;
                    if (index == null || index.Color == null) continue;

                    var existingColor = await _context.Colorinfos.FirstOrDefaultAsync(c =>
                        c.Red == index.Color.Red.GetValueOrDefault(0) &&
                        c.Green == index.Color.Green.GetValueOrDefault(0) &&
                        c.Blue == index.Color.Blue.GetValueOrDefault(0));

                    if (existingColor == null)
                    {
                        existingColor = new ColorInfo
                        {
                            Red = index.Color.Red.GetValueOrDefault(0),
                            Green = index.Color.Green.GetValueOrDefault(0),
                            Blue = index.Color.Blue.GetValueOrDefault(0)
                        };
                        _context.Colorinfos.Add(existingColor);
                        await _context.SaveChangesAsync();
                    }

                    var pollenIndex = new IndexInfo
                    {
                        Code = index.Code,
                        DisplayName = index.DisplayName,
                        Value = index.Value,
                        Category = index.Category,
                        IndexDescription = index.IndexDescription ?? "Ingen beskrivelse tilgjengelig",
                        ColorInfoID = existingColor.ID,
                        ColorInfo = existingColor
                    };

                    _context.IndexInfos.Add(pollenIndex);
                }
            }
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task RyddGamleDataAsync()
    {
        _context.IndexInfos.RemoveRange(_context.IndexInfos);
        _context.Colorinfos.RemoveRange(_context.Colorinfos);
        await _context.SaveChangesAsync();
    }

}
