using Microsoft.AspNetCore.Mvc;
using Gruppe2.Models;
using System.Linq;

namespace Gruppe2.Controllers;

public class PollenRegistreringController : Controller
{
    public AppDbContext _context; 

    public PollenRegistreringController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var registreringer = _context.PollenRegistreringer.ToList();
        return View(registreringer);
    }

    public IActionResult Edit(int id) => View();
    public IActionResult Details(int id) => View();
    public IActionResult Delete(int id) => View();
}
