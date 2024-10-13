using ContactApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ContactApp.Controllers
{
    public class HomeController : Controller
    {
        ContactContext _ctx;
        public HomeController(ContactContext ctx) 
        {
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            var contacts = _ctx.Contacts
                .Include(c => c.Category) // Corrected typo
                .OrderBy(c => c.LastName)
                .ToList();
            return View(contacts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
