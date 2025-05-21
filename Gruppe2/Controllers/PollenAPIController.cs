using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gruppe2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Gruppe2.Controllers
{
    public class PollenAPIController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPollenAPIService _service;

        public PollenAPIController(AppDbContext context, IPollenAPIService service)
        {
            _context = context;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            await _service.HentPollenDataAsync();

            var data = await _context.IndexInfos
                                     .Include(i => i.ColorInfo)
                                     .OrderByDescending(i => i.ID)
                                     .Take(5)
                                     .ToListAsync();
            return View(data);
        }
    }
}
