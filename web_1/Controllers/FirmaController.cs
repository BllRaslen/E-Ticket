using EfCore2C.Models;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web_1.Context;
using web_1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
namespace web_1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FirmaController : Controller
    {
        private readonly ApplicationDBContext _context;

        // Constructor to initialize the controller with the database context
        public FirmaController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: FirmaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FirmaController/Details/5


        // GET: FirmaController/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: FirmaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Firma firma)
        {
            // Check if the Firma with the given ID already exists
            if (FirmaMevcut(firma.firma_id))
            {
                TempData["basarsiz_create"] = firma.firma_id + " Zaten Mevcuttur!";
                return RedirectToAction("Create");
            }
            else
            {
                // If the ModelState is valid, add the new Firma and save changes
                if (ModelState.IsValid)
                {
                    _context.Firmas.Add(firma);
                    _context.SaveChanges();
                    //  HttpContext.Session.SetString("basarli_Firma_create", $"{firma.firma_adi} adlı firma eklendi");
                    TempData["basarli_Firma_create"] = $"{firma.firma_adi} adlı firma eklendi";

                    return RedirectToAction(nameof(List));
                }

                TempData["basarsiz_create"] = " Ekleme başarısız";
            }

            // Continue with the save operation if the ID is unique
            return View(firma);
        }

        // Helper method to check if a Firma with a specific ID exists
        private bool FirmaMevcut(int id)
        {
            return (_context.Firmas?.Any(e => e.firma_id == id)).GetValueOrDefault();
        }

        // GET: FirmaController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
            // Handle cases where the ID is null or the Firmas collection is null
            if (id == null || _context.Firmas == null)
            {
                return NotFound();
            }

            var firma = await _context.Firmas.FindAsync(id);

            if (firma == null)
            {
                return NotFound();
            }

            // Populate ViewData with a SelectList for display in the view
            ViewData["basarli"] = new SelectList(_context.Firmas, "firma_id", "firma_adi", firma.firma_adi);
            return View(firma);
        }

        // POST: FirmaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("firma_id,firma_adi")] Firma firma)
        {
            if (id != firma.firma_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Update the Firma and save changes
                    _context.Update(firma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Check for concurrency issues
                    if (!FirmaMevcut(firma.firma_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["basarli_Firma_edit"] = $"{firma.firma_adi} adlı firma guncelide";
                return RedirectToAction(nameof(List));
            }

            // Populate ViewData with a SelectList for display in the view
            ViewData["basarli"] = new SelectList(_context.Firmas, "firma_id", "firma_adi", firma.firma_id);
            return View(firma);
        }

        // GET: FirmaController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
          
            // Handle cases where the ID is null or the Firmas collection is null
            if (id == null || _context.Firmas == null)
            {
                return NotFound();
            }

            var firma = await _context.Firmas
                .Include(k => k.Seferler)
                .FirstOrDefaultAsync(m => m.firma_id == id);

            if (firma == null)
            {
                return NotFound();
            }

            return View(firma);
        }

        // GET: FirmaController/List
        public IActionResult List()
        {
          

            if (HttpContext.Session.GetString("basarli_Firma_create") is not null)
            {
                TempData["basarli_Firma_create"] = HttpContext.Session.GetString("basarli_Firma_create");
            }
            // Retrieve the list of Firmas and display it in the view
            var firmas = _context.Firmas.ToList();
            return View(firmas);
        }

        // GET: FirmaController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
           
            // Handle cases where the ID is null
            if (id == null)
            {
                return NotFound();
            }

            var firma = await _context.Firmas
                .Include(f => f.Seferler)
                .FirstOrDefaultAsync(m => m.firma_id == id);

            if (firma == null)
            {
                return NotFound();
            }

            return View(firma);
        }

        // POST: FirmaController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var firma = await _context.Firmas.FindAsync(id);

            if (firma == null)
            {
                return NotFound();
            }

            // Delete related Sefers records
            var sefersToDelete = _context.Sefers.Where(s => s.firma_id == id);
            _context.Sefers.RemoveRange(sefersToDelete);

            // Delete the Firma record
            _context.Firmas.Remove(firma);

            await _context.SaveChangesAsync();
            TempData["basarli_Firma_delete"] = $"{firma.firma_adi} adlı firma silendi";
            return RedirectToAction(nameof(List));
        }
    }
}
