using web_1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web_1.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
namespace web_1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SehirController : Controller
    {
        private readonly ApplicationDBContext _context;
        // Constructor to initialize the controller with the database context
        public SehirController(ApplicationDBContext context)
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
        public IActionResult Create(Sehir sehir)
        {
            // Check if the Sehir with the given ID already exists
            if (SehirMevcut(sehir.sehir_id))
            {
                TempData["basarsiz_create"] = sehir.sehir_id + " Zaten Mevcuttur!";
                return RedirectToAction("Create");
            }
            else
            {
                // If the ModelState is valid, add the new Sehir and save changes
                if (ModelState.IsValid)
                {
                    _context.Sehirs.Add(sehir);
                    _context.SaveChanges();
                    TempData["basarli_sehir_create"] = $"{sehir.sehir_adi} adlı Sehir eklendi";
                    return RedirectToAction(nameof(List));
                }

                TempData["basarsiz_create"] = " Ekleme başarısız";
            }

            // Continue with the save operation if the ID is unique
            return View(sehir);
        }

        // Helper method to check if a Sehir with a specific ID exists
        private bool SehirMevcut(int id)
        {
            return (_context.Sehirs?.Any(e => e.sehir_id == id)).GetValueOrDefault();
        }

        // GET: SehirController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            // Handle cases where the ID is null or the Sehirs collection is null
            if (id == null || _context.Sehirs == null)
            {
                return NotFound();
            }

            var sehir = await _context.Sehirs.FindAsync(id);

            if (sehir == null)
            {
                return NotFound();
            }

            // Populate ViewData with a SelectList for display in the view
            ViewData["basarli"] = new SelectList(_context.Sehirs, "sehir_id", "sehir_adi", sehir.sehir_adi);
            return View(sehir);
        }

        // POST: SehirController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("sehir_id,sehir_adi")] Sehir sehir)
        {
            if (id != sehir.sehir_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Update the Sehir and save changes
                    _context.Update(sehir);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Check for concurrency issues
                    if (!SehirMevcut(sehir.sehir_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["basarli_sehir_edit"] = $"{sehir.sehir_adi} adlı Sehir guncelide";
                return RedirectToAction(nameof(List));
            }

            // Populate ViewData with a SelectList for display in the view
            ViewData["basarli"] = new SelectList(_context.Sehirs, "sehir_id", "sehir_adi", sehir.sehir_id);
            return View(sehir);
        }

        // GET: SehirController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
           
            // Handle cases where the ID is null or the Sehirs collection is null
            if (id == null || _context.Sehirs == null)
            {
                return NotFound();
            }

            var Sehir = await _context.Sehirs
                .Include(k => k.Havalimanis)
                .FirstOrDefaultAsync(m => m.sehir_id == id);

            if (Sehir == null)
            {
                return NotFound();
            }

            return View(Sehir);
        }
        // GET: SehirController/List
        public IActionResult List()
        {
           
            // Retrieve the list of Sehirs and display it in the view
            var sehirs = _context.Sehirs.ToList();
            return View(sehirs);
        }


        // GET: SehirController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
           
            // Handle cases where the ID is null
            if (id == null)
            {
                return NotFound();
            }
            var Sehir = await _context.Sehirs
                .Include(f => f.Havalimanis)
                .FirstOrDefaultAsync(m => m.sehir_id == id);

            if (Sehir == null)
            {
                return NotFound();
            }

            return View(Sehir);
        }

        // POST: SehirController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Sehir = await _context.Sehirs.FindAsync(id);

            if (Sehir == null)
            {
                return NotFound();
            }

            // Delete related Sefers records
            var sefersToDelete = _context.Havalimanis.Where(s => s.sehir_id == id);
            _context.Havalimanis.RemoveRange(sefersToDelete);

            // Delete the Sehir record
            _context.Sehirs.Remove(Sehir);

            await _context.SaveChangesAsync();
            TempData["basarli_sehir_delete"] = $"{Sehir.sehir_adi} adlı Sehir selindi";

            return RedirectToAction(nameof(List));
        }
    }
}
