
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Gruppe2.Models;
using System.Linq;


namespace Gruppe2.Controllers 
{
    public class PollenAPIController : Controller
    {
        private readonly AppDbContext _context;


        public PollenAPIController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var data = _context.IndexInfo
                               .OrderByDescending(i => i.ID)
                               .Take(5)
                               .ToList();

            return View(data);
        }
    }
}
