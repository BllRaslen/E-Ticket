using EfCore2C.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using web_1.Context;
using web_1.Models;
using web_1.ViewModels;

namespace web_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<HomeController> _logger;


        // Constructor to initialize the controller with the database context
        public HomeController(ApplicationDBContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }







        public IActionResult Index()
        {

            List<Sehir> sehirs = _context.Sehirs.ToList();
            HomeModels sfm = new HomeModels()
            {
                sehir = sehirs
            };

            // Pass the labels to the view
            return View(sfm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(HomeModels HomeViewModel)
        {

            return View("SeferBilgileri");




        }


        public IActionResult SeferBilgileri(Sefer sefer)
        {
            return View(sefer);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}