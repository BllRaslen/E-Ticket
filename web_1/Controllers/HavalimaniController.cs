using EfCore2C.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using web_1.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
namespace web_1.Controllers
{
    [Authorize(Roles = "Admin")]

    public class HavalimaniController : Controller
    {
        private readonly ApplicationDBContext _context;

        // Constructor to initialize the controller with the database context
        public HavalimaniController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: HavalimaniController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HavalimaniController/Details/5


        // GET: HavalimaniController/Create
        public ActionResult Create()
        {
          
            return View();
        }

        // POST: HavalimaniController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Havalimani havalimani)
        {
            if (HavalimaniMevcut(havalimani.havalimani_id))
            {
                TempData["basarsiz_create"] = havalimani.havalimani_id + " Zaten Mevcuttur!";
                return RedirectToAction("List");
            }
            else
            {
                if (SehirMevcut(havalimani.sehir_id))
                {
                    _context.Havalimanis.Add(havalimani);
                    _context.SaveChanges();
                    TempData["basarli_Havalimanis_create"] = $"{havalimani.havalimani_adi} adlı firma eklendi";

                    return RedirectToAction("List");
                }

                TempData["Sehiryok"] = " Girdiğiniz şehir İdisi Mevcut değildir!!";

            }
            // Continue with the save operation if the ID is unique
            return View("Create");
        }

        private bool SehirMevcut(int id)
        {
            return (_context.Sehirs?.Any(e => e.sehir_id == id)).GetValueOrDefault();
        }


        private bool HavalimaniMevcut(int havalimani_id)
        {
            return (_context.Havalimanis?.Any(e => e.havalimani_id == havalimani_id)).GetValueOrDefault();
        }
        public IActionResult List()
        {
            // Retrieve the list of Firmas and display it in the view
            var havalimani = _context.Havalimanis.ToList();
            return View(havalimani);
        }
        // GET: HavalimaniController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
          
            // Handle cases where the ID is null or the Firmas collection is null
            if (id == null || _context.Havalimanis == null)
            {
                return NotFound();
            }

            var havalimani = await _context.Havalimanis.FindAsync(id);

            if (havalimani == null)
            {
                return NotFound();
            }

            // Populate ViewData with a SelectList for display in the view
            return View(havalimani);
        }

        // POST: FirmaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("havalimani_id,havalimani_adi,sehir_id")] Havalimani havalimani)
        {
            if (id != havalimani.havalimani_id)
            {
                return NotFound();
            }



            // Update the Firma and save changes
            _context.Update(havalimani);
            await _context.SaveChangesAsync();
            TempData["basarli_Havalimanis_edit"] = $"{havalimani.havalimani_adi} adlı havalimani guncelide";
            return RedirectToAction(nameof(List));







        }
        public async Task<IActionResult> Delete(int? id)
        {
            
            // Handle cases where the ID is null
            if (id == null)
            {
                return NotFound();
            }

            var havalimanis = await _context.Havalimanis
                .Include(f => f.Sehir)
                .FirstOrDefaultAsync(m => m.havalimani_id == id);

            if (havalimanis == null)
            {
                return NotFound();
            }

            return View(havalimanis);
        }

        // POST: FirmaController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var havalimanis = await _context.Havalimanis.FindAsync(id);

            if (havalimanis == null)
            {
                return NotFound();
            }

            // Delete related Sefers records
            var sefersToDelete = _context.Sehirs.Where(s => s.sehir_id == id);
            _context.Sehirs.RemoveRange(sefersToDelete);

            // Delete the Firma record
            _context.Havalimanis.Remove(havalimanis);

            await _context.SaveChangesAsync();
            TempData["basarli_Havalimanis_delete"] = $"{havalimanis.havalimani_adi} adlı havalimanis silendi";
            return RedirectToAction(nameof(List));
        }


        public async Task<IActionResult> Details(int? id)
        {
            // Handle cases where the ID is null or the Firmas collection is null
            if (id == null || _context.Havalimanis == null)
            {
                return NotFound();
            }

            var havalimanis = await _context.Havalimanis
                .Include(k => k.Sehir)
                .FirstOrDefaultAsync(m => m.sehir_id == id);

            if (havalimanis == null)
            {
                return NotFound();
            }

            return View(havalimanis);
        }

    }
}
