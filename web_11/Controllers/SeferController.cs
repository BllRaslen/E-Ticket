using EfCore2C.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web_1.Context;
using web_1.Models;
using web_1.ViewModels;

namespace web_1.Controllers
{
    public class SeferController : Controller
    {
        private readonly ApplicationDBContext _context;

        public SeferController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            List<Havalimani> havalimani = _context.Havalimanis.ToList();
            SeferModels sfm = new SeferModels() {
                HavalimaniModels = havalimani
            };
            return View(sfm);
        }

        // POST: HavalimaniController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SeferModels seferViewModel)
        {
            
                 _context.Sefers.Add(seferViewModel.SeferModel);
                _context.SaveChanges();
            HttpContext.Session.SetString("SessionSefer", seferViewModel.SeferModel.sefer_id.ToString());

            return RedirectToAction("Create", "Rezervarsyon");
        }


        private bool SeferMevcut(int id)
        {
            return (_context.Sefers?.Any(e => e.sefer_id == id)).GetValueOrDefault();
        }


        private bool HavalimaniMevcut(int havalimani_id)
        {
            return (_context.Havalimanis?.Any(e => e.havalimani_id == havalimani_id)).GetValueOrDefault();
        }
        public IActionResult List()
        {
            var sefers = _context.Sefers.ToList();
            return View(sefers);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("SessionUser") is null)
            {

                return NotFound();
            }
            // Handle cases where the ID is null or the Firmas collection is null
            if (id == null || _context.Sefers == null)
            {
                return NotFound();
            }

            var sefers = await _context.Sefers.FindAsync(id);

            if (sefers == null)
            {
                return NotFound();
            }

            // Populate ViewData with a SelectList for display in the view
            return View(sefers);
        }

        // POST: FirmaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Sefer sefer)
        {
            if (id != sefer.sefer_id)
            {
                return NotFound();
            }
            
         
                    // Update the Firma and save changes
                    _context.Update(sefer);
                    await _context.SaveChangesAsync();
                
          
                TempData["basarli_Firma_edit"] = $"{sefer.sefer_id} idli sefer guncelide";
                return RedirectToAction(nameof(List));
          

        }

        // GET: FirmaController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("SessionUser") is null)
            {
                return NotFound();
            }
            // Handle cases where the ID is null
            if (id == null)
            {
                return NotFound();
            }

            var sefers = await _context.Sefers.FirstOrDefaultAsync(m => m.sefer_id == id);

            if (sefers == null)
            {
                return NotFound();
            }

            return View(sefers);
        }

        // POST: FirmaController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sefers = await _context.Sefers.FindAsync(id);

            if (sefers == null)
            {
                return NotFound();
            }

            // Delete related Sefers records
            var sefersToDelete = _context.Rezervasyons.Where(s => s.sefer_id == id);
            _context.Rezervasyons.RemoveRange(sefersToDelete);

            // Delete the Firma record
            _context.Sefers.Remove(sefers);

            await _context.SaveChangesAsync();
           // TempData["basarli_Firma_delete"] = $"{firma.firma_adi} adlı firma silendi";
            return RedirectToAction(nameof(List));
        }
        // GET: FirmaController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("SessionUser") is null)
            {

                return NotFound();
            }
            // Handle cases where the ID is null or the Firmas collection is null
            if (id == null || _context.Sefers == null)
            {
                return NotFound();
            }

            var sefers = await _context.Sefers.FirstOrDefaultAsync(m => m.sefer_id == id);

            if (sefers == null)
            {
                return NotFound();
            }

            return View(sefers);
        }

    }
}
