using EfCore2C.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using web_1.Context;
using web_1.Models;
using web_1.ViewModels;

namespace web_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly ILogger<HomeController> _logger;


        // Constructor to initialize the controller with the database context
        public HomeController(ApplicationDBContext context, ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _context = context;
            _localizer = localizer;
        }



        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

            return LocalRedirect(returnUrl);
        }



        public IActionResult Index()
        {
            
            List<Havalimani> havalimane = _context.Havalimanis.ToList();
            HomeModels sfm = new HomeModels()
            {
                HavalimaniModel = havalimane
            };

      
            return View(sfm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(HomeModels HomeViewModel)
        {
            List<Sefer> sefers = _context.Sefers
                .Where(u => u.kalkis_havalimani_id == Convert.ToInt32(HomeViewModel.selectedKalkisHavalimani) && u.varis_havalimani_id == Convert.ToInt32(HomeViewModel.selectedvarisHavalimani))
                .ToList();

            return View("SeferBilgileri", sefers);
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