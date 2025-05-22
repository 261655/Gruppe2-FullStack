using Gruppe2.Models;

public interface IPollenAPIService
{
    Task HentPollenDataAsync();
    Task RyddGamleDataAsync();

}
