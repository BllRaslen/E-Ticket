using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using web_1.Context;
using web_1.Models;

namespace web_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<HomeController> _logger;


        // Constructor to initialize the controller with the database context
        public HomeController(ApplicationDBContext context , ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }




      

    
        public IActionResult Index()
        {
            // Retrieve labels from the database
            var labels = _context.Sehirs.ToList();

            // Pass the labels to the view
            return View(labels);
        }

        public IActionResult SeferBilgileri()
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