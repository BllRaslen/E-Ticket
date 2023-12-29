using web_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using web_1.Context;
using web_1.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using web_1.Models.airline.Models;

namespace EfCore2C.Controllers
{
    [Authorize(Roles = "Admin")]

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
            List<Sefer> sefers = _context.Sefers.ToList();

            RezervarsyonAndSeferModels rezer = new RezervarsyonAndSeferModels() { 
                sefer_id = Convert.ToInt32(HttpContext.Session.GetString("SessionSefer")),
                sefers=sefers
            };


         
            return View(rezer);
        }

        public  void CreateKoltuklarObjects(int numberOfSeats)
        {

            for (int i = 1; i <= numberOfSeats; i++)
            {
                Koltuklar koltuk = new Koltuklar
                {
                    Id = i,
                    Kod = $"Seat{i}", // توليد رمز الكرسي بشكل تلقائي، يمكنك تعديله حسب الحاجة
                    durum = false, // افتراضياً يمكنك تعيين حالة الكرسي
                    rezervasyon_id = 0, // يمكنك تعيين قيمة افتراضية حسب الحاجة
                };
                
             
            }
        }
        // POST: FirmaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RezervarsyonAndSeferModels rezervasyon)
        {
          int a=  rezervasyon.rezervasyons.koltuk_sayisi;

            int result = 0;
            if (_context.Koltuklars?.Any() == true)
            {

                result= _context.Koltuklars.Max(k => k.Id);
                ;
            }




            _context.Rezervasyons.Add(rezervasyon.rezervasyons);
        
            _context.SaveChanges();

            for (int i =1+ result; i <= a+result; i++)
            {
                Koltuklar koltuk = new Koltuklar
                {
                    Id = i,
                    Kod = i.ToString(), // توليد رمز الكرسي بشكل تلقائي، يمكنك تعديله حسب الحاجة
                    durum = false, // افتراضياً يمكنك تعيين حالة الكرسي
                    rezervasyon_id = rezervasyon.rezervasyons.rezervasyon_id, // يمكنك تعيين قيمة افتراضية حسب الحاجة
                };

                _context.Koltuklars.Add(koltuk);
                _context.SaveChanges();
            }
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
        public async Task<IActionResult> Details(int? id)
        {
        
            // Handle cases where the ID is null or the Firmas collection is null
            if (id == null || _context.Firmas == null)
            {
                return NotFound();
            }

            var Rezervasyon = await _context.Rezervasyons
                .FirstOrDefaultAsync(m => m.rezervasyon_id == id);

            if (Rezervasyon == null)
            {
                return NotFound();
            }

            return View(Rezervasyon);
        }
        public async Task<IActionResult> Edit(int? id)
        {
           
            // Handle cases where the ID is null or the Firmas collection is null
            if (id == null || _context.Rezervasyons == null)
            {
                return NotFound();
            }

            var rezervasyon = await _context.Rezervasyons.FindAsync(id);

            if (rezervasyon == null)
            {
                return NotFound();
            }

            // Populate ViewData with a SelectList for display in the view
            // ViewData["basarli"] = new SelectList(_context.Firmas, "firma_id", "firma_adi", firma.firma_adi);
            return View(rezervasyon);
        }

        // POST: FirmaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Rezervasyon rezervasyon)
        {
            if (id != rezervasyon.rezervasyon_id)
            {
                return NotFound();
            }



            // Update the Firma and save changes
            _context.Update(rezervasyon);
            await _context.SaveChangesAsync();


            TempData["basarli_rezervasyon_edit"] = $"{rezervasyon.rezervasyonTipi} tipi firma guncelide";
            return RedirectToAction(nameof(List));


            // Populate ViewData with a SelectList for display in the view
            //  ViewData["basarli"] = new SelectList(_context.Firmas, "firma_id", "firma_adi", firma.firma_id);

        }
        public async Task<IActionResult> Delete(int? id)
        {
           
            // Handle cases where the ID is null
            if (id == null)
            {
                return NotFound();
            }

            var rezervasyon = await _context.Rezervasyons

                .FirstOrDefaultAsync(m => m.rezervasyon_id == id);

            if (rezervasyon == null)
            {
                return NotFound();
            }

            return View(rezervasyon);
        }

        // POST: FirmaController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezervasyon = await _context.Rezervasyons.FindAsync(id);

            if (rezervasyon == null)
            {
                return NotFound();
            }



            // Delete the Firma record
            _context.Rezervasyons.Remove(rezervasyon);

            await _context.SaveChangesAsync();
            TempData["basarli_rezervasyon_delete"] = $"{rezervasyon.rezervasyonTipi} tipile rezervasyon silendi";
            return RedirectToAction(nameof(List));
        }

        public int CountNonActiveKoltuklars()
        {
            
            var result = _context.Koltuklars.Count(k => k.durum == false);

            return result;
        }

    }
}
