using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gruppe2.Models
{
    public interface IPollenAPIService
    {
        Task<List<PollenDisplayDto>> HentDisplayDataAsync();
    }
}
