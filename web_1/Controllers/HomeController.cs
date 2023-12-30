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
            List<kartlarModels> seferData = GetSeferData(Convert.ToInt32(HomeViewModel.selectedKalkisHavalimani), Convert.ToInt32(HomeViewModel.selectedvarisHavalimani), HomeViewModel.selectedTarihi);

            if (seferData.Count==0)
            {
                return View("SeferYok",seferData);

            }
            else
            {
                return View("SeferBilgileri", seferData);

            }

        }
        public List<kartlarModels> GetSeferData(int selectedKalkisHavalimaniId,int selectedVarisHavalimaniId,string tarihi)
        {

            var query =      (from f in _context.Firmas
                         join s in _context.Sefers on f.firma_id equals s.firma_id
                         join h in _context.Havalimanis on s.kalkis_havalimani_id equals h.havalimani_id
                         where s.kalkis_havalimani_id == selectedKalkisHavalimaniId &&
                      s.varis_havalimani_id == selectedVarisHavalimaniId

                      &&
                      s.kalkis_tarihi == tarihi
                              select new kartlarModels
                         {
                             logo=f.logo,
                             SeferId = s.sefer_id,
                             KalkisSaati = s.kalkis_saati,
                             VarisSaati = s.varis_saati,
                             FirmaAdi = f.firma_adi,
                             HavalimaniAdi = h.havalimani_adi,
                             rezervasyons = _context.Rezervasyons.Where(x => x.sefer_id == s.sefer_id).ToList(),

                             KalkisTarihi = s.kalkis_tarihi,
                             VarisTarihi = s.varis_tarihi
                         }).ToList();



            return query;

        }


        public IActionResult SeferBilgileri(List<kartlarModels> kartlarModel)
        {


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        public IActionResult KoltukSec(int id)
        {
            List<Koltuklar> koltuklars = (_context.Koltuklars.Where(e =>e.rezervasyon_id==id)).ToList();


            return View(koltuklars);
        }

        public int SaveSelectedSeat(int seatId)
        {
            return seatId;
        }
    }
}