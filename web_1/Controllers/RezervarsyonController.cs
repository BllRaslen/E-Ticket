using EfCore2C.Models;
using EfCore2C.Models.airline.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using web_1.Context;
using web_1.ViewModels;

namespace web_1.Controllers
{
    public class RezervarsyonController : Controller
    {
        private readonly ApplicationDBContext _context;
        // Constructor to initialize the controller with the database context
        public RezervarsyonController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View();
        }
        public ActionResult Create()
        {
           
                RezervarsyonAndSeferModels rezer = new RezervarsyonAndSeferModels() { sefer_id = Convert.ToInt32(HttpContext.Session.GetString("SessionSefer")) };
            
          
            if (HttpContext.Session.GetString("SessionUser") is null)
            {
                return NotFound();
            }
            return View(rezer);
        }

        // POST: FirmaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RezervarsyonAndSeferModels rezervasyon)
        {
            
           
           
                    _context.Rezervasyons.Add( rezervasyon.rezervasyons);
                    _context.SaveChanges();
                 //   TempData["basarli_sehir_create"] = $"{rezervasyon.sehir_adi} adlı Sehir eklendi";
                    return RedirectToAction(nameof(Create));
                

                TempData["basarsiz_create"] = " Ekleme başarısız";
            

            // Continue with the save operation if the ID is unique
            return View("List");
        }
        public IActionResult List()
        {

            
            // Retrieve the list of Firmas and display it in the view
            var rezervasyons = _context.Rezervasyons.ToList();
            return View(rezervasyons);
        }
    }
}
